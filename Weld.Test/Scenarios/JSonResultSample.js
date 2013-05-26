var JSonResultSample = (function () {
    function JSonResultSample() { }
    JSonResultSample.prototype.GetPerson = function (id, callback) {
        var url = "/JSonResultSample/GetPerson";
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
    return JSonResultSample;
})();
