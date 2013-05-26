using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using Weld.Test.Scenarios;
using Weld.Test.ViewModels;


namespace Weld.Test
{
    [TestFixture]
    public class TypeScriptWeldViewModelTest
    {
        [Test]
        public void SimpleViewModel()
        {
            TestHelper.TestSampleType<SimpleViewModel>("ViewModels");
        }

        [Test]
        public void ChildViewModel()
        {
            TestHelper.TestSampleType<ChildViewModel>("ViewModels");
        }

        [Test]
        public void NestedViewModel()
        {
            TestHelper.TestSampleType<NestedViewModel>("ViewModels");
        }
    }
}
