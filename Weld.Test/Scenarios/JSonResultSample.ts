/// <reference path="../typings/jquery/jquery.d.ts" />
class JSonResultSample
{
    GetPerson(id: number, callback: (data: Person) => any)
    {
        var url = "/JSonResultSample/GetPerson";
        var data = { id: id };
        $.ajax({
            url: url,
            type : "POST",
            data: data,
            success: callback,
        });
    }
}

interface Person
{
    FirstName: string;
    LastName: string;
    Age: number;
    Male: bool;
}