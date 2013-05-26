var MethodWithReturnValue = (function () {
    function MethodWithReturnValue() { }
    MethodWithReturnValue.prototype.Sum = function (x, y, callback) {
        var url = "/MethodWithReturnValue/Sum";
        var data = {
            x: x,
            y: y
        };
        $.ajax({
            url: url,
            data: data,
            success: callback
        });
    };
    return MethodWithReturnValue;
})();
