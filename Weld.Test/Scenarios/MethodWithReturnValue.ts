class MethodWithReturnValue
{
    Sum(x: number, y: number, callback: (data: number) => any)
    {
        var url = "/MethodWithReturnValue/Sum";
        var data = { x: x, y: y };
        $.ajax({
            url: url,
            data: data,
            success: callback,
        });
    }
}