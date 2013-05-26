/// <reference path="../typings/jquery/jquery.d.ts" />
class ContentResultSample
{
    Store(x: number, callback: (data: string) => any)
    {
        var url = "/ContentResultSample/Store";
        var data = { x: x };
        $.ajax({
            url: url,
            data: data,
            success: callback,
        });
    }
}
