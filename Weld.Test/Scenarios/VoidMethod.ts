class VoidMethod
{
    Store(x: number)
    {
        var url = "/VoidMethod/Store";
        var data = { x: x };
        $.ajax({
            url: url,
            data: data,
        });
    }
}