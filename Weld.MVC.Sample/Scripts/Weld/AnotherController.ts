/// <reference path="../typings/jquery/jquery.d.ts" />
class AnotherController
{
    TakeFive(callback: (data: number) => any)
    {
        var url = "/Another/TakeFive";
        var data = {  };
        $.ajax({
            url: url,
            data: data,
            success: callback,
        });
    }
}
