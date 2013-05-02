/// <reference path="../typings/jquery/jquery.d.ts" />
class TraditionalForArrays
{
    Store(x: number[])
    {
        var url = "/TraditionalForArrays/Store";
        var data = { x: x };
        $.ajax({
            url: url,
            data: data,
            traditional: true,
        });
    }
}