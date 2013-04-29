using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class ConstValues
    {
        [ClientSide]
        public const int ConstValuesAreEasy = 4;

        [ClientSide]
        public const string StringValue = "Hello Typescript!";
    }
}