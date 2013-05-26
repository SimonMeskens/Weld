/// <reference path="../typings/jquery/jquery.d.ts" />
class NormalJSonResultSample
{
    GetPerson(id: number, callback: (data: any) => any)
    {
        var url = "/NormalJSonResultSample/GetPerson";
        var data = { id: id };
        $.ajax({
            url: url,
            type : "POST",
            data: data,
            success: callback,
        });
    }
}
