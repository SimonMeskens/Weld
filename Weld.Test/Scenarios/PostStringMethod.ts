class PostStringMethod
{
    Echo(value: string, callback: (data: string) => any)
    {
        var url = "/PostStringMethod/Echo";
        var data = { value: value };
        $.ajax({
            url: url,
            method : "POST",
            data: data,
            success: callback,
        });
    }
}