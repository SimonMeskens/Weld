class AccountController
{
    Store(x: number)
    {
        var url = "/Account/Store";
        var data = { x: x };
        $.ajax({
            url: url,
            data: data,
        });
    }
}