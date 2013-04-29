$(document).ready(function () {
    var showResult = function (result) {
        $("#theSpan").text("The sum is " + result);
    };
    HomeController.prototype.Sum(2, 3, showResult);
});
