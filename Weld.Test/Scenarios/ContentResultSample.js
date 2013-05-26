var ContentResultSample = (function () {
    function ContentResultSample() { }
    ContentResultSample.prototype.Store = function (x, callback) {
        var url = "/ContentResultSample/Store";
        var data = {
            x: x
        };
        $.ajax({
            url: url,
            data: data,
            success: callback
        });
    };
    return ContentResultSample;
})();
