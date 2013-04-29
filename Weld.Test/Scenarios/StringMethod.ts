class StringMethod
{
    Echo(value: string, callback: (data: string) => any)
    {
        var url = "/StringMethod/Echo";
        var data = { value: value };
        $.ajax({
            url: url,
            data: data,
            success: callback,
        });
    }
}