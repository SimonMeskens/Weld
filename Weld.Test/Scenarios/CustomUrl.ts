/// <reference path="../typings/jquery/jquery.d.ts" />
class CustomUrl
{
    Method(value: string)
    {
        var url = "Custom";
        var data = { value: value };
        $.ajax({
            url: url,
            data: data,
        });
    }
}
