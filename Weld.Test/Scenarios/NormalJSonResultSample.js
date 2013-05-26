var NormalJSonResultSample = (function () {
    function NormalJSonResultSample() { }
    NormalJSonResultSample.prototype.GetPerson = function (id, callback) {
        var url = "/NormalJSonResultSample/GetPerson";
        var data = {
            id: id
        };
        $.ajax({
            url: url,
            type: "POST",
            data: data,
            success: callback
        });
    };
    return NormalJSonResultSample;
})();
