function GetCanvasSize() {
    var canvas = document.getElementById('canvas');

    var dom = canvas.getBoundingClientRect();
    return {
        left: dom.left,
        height: dom.height,
        top: dom.top,
        width: dom.width
    }

}

function CallRender(image) {
    render(image)
    console.log("render(image)")
}
