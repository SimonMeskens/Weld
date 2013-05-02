/// <reference path="../typings/jquery/jquery.d.ts" />
class PartialViewController
{
    Store(x: number, callback: (data: string) => any)
    {
        var url = "/PartialView/Store";
        var data = { x: x };
        $.ajax({
            url: url,
            data: data,
            success: callback,
        });
    }
}