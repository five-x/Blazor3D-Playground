using BlazorWebGLJSInvoke.JSObject;
using BlazorWebGLJSInvoke.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace BlazorWebGLJSInvoke.Pages
{
    public class IndexComponent : ComponentBase
    {
        [Inject]
        IJSRuntime JS { get; set; }
        private IJSObjectReference module;

        internal SurveyPrompt surveyPrompt { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Console.WriteLine();
            await TickerChanged();
            //return base.OnAfterRenderAsync(firstRender);
        }
        public async ValueTask TickerChanged()
        {
            var size = await JS.InvokeAsync<object>("GetCanvasSize");
            CanvasSize deserializedProduct = JsonConvert.DeserializeObject<CanvasSize>(size.ToString());

            var imageOriginal = new Bitmap("Img/t11.jpg");
            var newImg = new Bitmap(imageOriginal, new Size((int)deserializedProduct.width, (int)deserializedProduct.height));
            using (MemoryStream ms = new MemoryStream())
            {
                newImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                _ = JS.InvokeVoidAsync("render", ms.ToArray());
            }
        }
    }
}
