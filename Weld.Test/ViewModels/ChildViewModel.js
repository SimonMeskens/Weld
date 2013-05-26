var ChildViewModel = (function () {
    function ChildViewModel() { }
    ChildViewModel.SomethingMore = "SomethingMore";
    Object.defineProperty(ChildViewModel, "$SomethingMore", {
        get: function () {
            return $("#SomethingMore");
        },
        enumerable: true,
        configurable: true
    });
    ChildViewModel.Enabled = "Enabled";
    Object.defineProperty(ChildViewModel, "$Enabled", {
        get: function () {
            return $("#Enabled");
        },
        enumerable: true,
        configurable: true
    });
    ChildViewModel.FirstName = "FirstName";
    Object.defineProperty(ChildViewModel, "$FirstName", {
        get: function () {
            return $("#FirstName");
        },
        enumerable: true,
        configurable: true
    });
    return ChildViewModel;
})();
