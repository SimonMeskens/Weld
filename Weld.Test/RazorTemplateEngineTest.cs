using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Weld.Infra;
using Weld.Test.Models;

namespace Weld.Test
{
    [TestFixture]
    public class RazorTemplateEngineTest
    {
        [Test]
        public void GetPersonInterface()
        {
            var engine = new RazorTemplateEngine();
            var content = engine.GetTypeScriptInterface(typeof (Person));
            var filePath = String.Format("./../../Models/Person.ts");
            var expectContent = File.ReadAllText(filePath);
            Assert.AreEqual(expectContent,content);
        }
    }
}
