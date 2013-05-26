var AccountController = (function () {
    function AccountController() { }
    AccountController.prototype.Store = function (x) {
        var url = "/Account/Store";
        var data = {
            x: x
        };
        $.ajax({
            url: url,
            data: data
        });
    };
    return AccountController;
})();
