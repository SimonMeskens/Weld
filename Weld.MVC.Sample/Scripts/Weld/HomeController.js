var HomeController = (function () {
    function HomeController() { }
    HomeController.prototype.Sum = function (x, y, callback) {
        var url = "/Home/Sum";
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
    HomeController.prototype.Store = function (x) {
        var url = "/Home/Store";
        var data = {
            x: x
        };
        $.ajax({
            url: url,
            data: data
        });
    };
    HomeController.prototype.GetPerson = function (callback) {
        var url = "/Home/GetPerson";
        var data = {
        };
        $.ajax({
            url: url,
            type: "POST",
            data: data,
            success: callback
        });
    };
    return HomeController;
})();
