var BoolMethod = (function () {
    function BoolMethod() { }
    BoolMethod.prototype.Store = function (value) {
        var url = "/BoolMethod/Store";
        var data = {
            value: value
        };
        $.ajax({
            url: url,
            data: data
        });
    };
    return BoolMethod;
})();
