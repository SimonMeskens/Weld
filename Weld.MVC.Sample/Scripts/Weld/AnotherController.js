var AnotherController = (function () {
    function AnotherController() { }
    AnotherController.prototype.TakeFive = function (callback) {
        var url = "/Another/TakeFive";
        var data = {
        };
        $.ajax({
            url: url,
            data: data,
            success: callback
        });
    };
    return AnotherController;
})();
