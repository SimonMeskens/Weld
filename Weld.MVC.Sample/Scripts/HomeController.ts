
/// <reference path="typings/jquery/jquery.d.ts" />

/// <reference path="Weld/HomeController.ts" />


$(document).ready(function () {
   
    var showResult = function (result) {
        $("#theSpan").text("The sum is " + result);
    }

    HomeController.prototype.Sum(2, 3, showResult);

    HomeController.prototype.GetPerson((p) =>
    {
        //alert(p.FirstName);
    });
});