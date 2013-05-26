$(document).ready(function () {
    var showResult = function (result) {
        $("#theSpan").text("The sum is " + result);
    };
    HomeController.prototype.Sum(2, 3, showResult);
    HomeController.prototype.GetPerson(function (p) {
    });
});
