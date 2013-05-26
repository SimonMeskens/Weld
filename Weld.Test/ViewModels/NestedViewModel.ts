/// <reference path="../typings/jquery/jquery.d.ts" />
class NestedViewModel 
{
    static Enabled: string = "Enabled";
    static get $Enabled() : JQuery {
        return $("#Enabled");
    }
    static FirstName: string = "FirstName";
    static get $FirstName() : JQuery {
        return $("#FirstName");
    }
    static Nested_Enabled: string = "Nested_Enabled";
    static get $Nested_Enabled() : JQuery {
        return $("#Nested_Enabled");
    }
    static Nested_FirstName: string = "Nested_FirstName";
    static get $Nested_FirstName() : JQuery {
        return $("#Nested_FirstName");
    }
}