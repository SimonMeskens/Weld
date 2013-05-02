/// <reference path="../typings/jquery/jquery.d.ts" />
class HomeController
{
    Sum(x: number, y: number, callback: (data: number) => any)
    {
        var url = "/Home/Sum";
        var data = { x: x, y: y };
        $.ajax({
            url: url,
            data: data,
            success: callback,
        });
    }
    Store(x: number)
    {
        var url = "/Home/Store";
        var data = { x: x };
        $.ajax({
            url: url,
            data: data,
        });
    }
}