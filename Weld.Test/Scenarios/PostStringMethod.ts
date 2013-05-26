/// <reference path="../typings/jquery/jquery.d.ts" />
class PostStringMethod
{
    Echo(value: string, callback: (data: string) => any)
    {
        var url = "/PostStringMethod/Echo";
        var data = { value: value };
        $.ajax({
            url: url,
            type : "POST",
            data: data,
            success: callback,
        });
    }
}
