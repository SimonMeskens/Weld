var PostStringMethod = (function () {
    function PostStringMethod() { }
    PostStringMethod.prototype.Echo = function (value, callback) {
        var url = "/PostStringMethod/Echo";
        var data = {
            value: value
        };
        $.ajax({
            url: url,
            type: "POST",
            data: data,
            success: callback
        });
    };
    return PostStringMethod;
})();
