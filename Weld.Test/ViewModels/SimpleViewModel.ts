/// <reference path="../typings/jquery/jquery.d.ts" />
class SimpleViewModel 
{
    static Enabled: string = "Enabled";
    static get $Enabled() : JQuery {
        return $("#Enabled");
    }
    static FirstName: string = "FirstName";
    static get $FirstName() : JQuery {
        return $("#FirstName");
    }
}