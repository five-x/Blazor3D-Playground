using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWebGLJSInvoke.Controllers
{
    public class ResizeController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IDistributedCache _cache;

        public ResizeController(IWebHostEnvironment env, IDistributedCache cache)
        {
            _fileProvider = env.WebRootFileProvider;
            _cache = cache;
        }

        [Route("/image/{width}/{height}/{*url}")]
        public async Task<IActionResult> ResizeImage(string url, int width, int height)
        {
            if (width < 0 || height < 0) { return BadRequest(); }

            var key = $"/{width}/{height}/{url}";
            var data = await _cache.GetAsync(key);
            if (data == null)
            {
                // resize image and cache it
            }

            return File(data, "image/jpg");
        }
    }
}
