class AnyForUnknown
{
    StoreUnknownType(value: any)
    {
        var url = "/AnyForUnknown/StoreUnknownType";
        var data = { value: value };
        $.ajax({
            url: url,
            data: data,
        });
    }
}