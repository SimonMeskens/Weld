/// <reference path="../typings/jquery/jquery.d.ts" />
class ChildViewModel 
{
    static SomethingMore: string = "SomethingMore";
    static get $SomethingMore() : JQuery {
        return $("#SomethingMore");
    }
    static Enabled: string = "Enabled";
    static get $Enabled() : JQuery {
        return $("#Enabled");
    }
    static FirstName: string = "FirstName";
    static get $FirstName() : JQuery {
        return $("#FirstName");
    }
}