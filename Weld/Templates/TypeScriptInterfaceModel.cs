using System;
using System.Collections.Generic;

namespace Weld.Templates
{
    public class TypeScriptInterfaceModel
    {
        public string TypeName { get; set; }

        public IList<Tuple<string, string>> PropertyNamesAndTypeScriptTypes;
    }
}