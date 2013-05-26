var CustomUrl = (function () {
    function CustomUrl() { }
    CustomUrl.prototype.Method = function (value) {
        var url = "Custom";
        var data = {
            value: value
        };
        $.ajax({
            url: url,
            data: data
        });
    };
    return CustomUrl;
})();
