using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using Weld.Test.Scenarios;


namespace Weld.Test
{
    [TestFixture]
    public class TypeScriptProcessorTest
    {
        readonly TypeScriptProcessor processor = new TypeScriptProcessor();

        [Test]
        public void ReturnNullForUnknown()
        {
            var result = processor.Process(typeof (int));
            Assert.IsNull(result);
        }
        
        [Test]
        public void ConstValues()
        {
            TestHelper.TestSampleType<ConstValues>();
        }


        [Test]
        public void ProcessAssembly()
        {
            var result = processor.ProcessAssembly(Assembly.GetExecutingAssembly());
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void StringMethods()
        {
            TestHelper.TestSampleType<StringMethod>();
        }

        [Test]
        public void CustomUrl()
        {
            TestHelper.TestSampleType<CustomUrl>();
        }

        [Test]
        public void VoidMethods()
        {
            TestHelper.TestSampleType<VoidMethod>();
        }

        [Test]
        public void PostStringMethod()
        {
            TestHelper.TestSampleType<PostStringMethod>();
        }

        [Test]
        public void BoolMethod()
        {
            TestHelper.TestSampleType<BoolMethod>();
        }

        [Test]
        public void AnyForUnknown()
        {
            TestHelper.TestSampleType<AnyForUnknown>();
        }


        [Test]
        public void MethodWithReturnValue()
        {
            TestHelper.TestSampleType<MethodWithReturnValue>();
        }

        [Test]
        public void ControllerIsOmittedFromUrl()
        {
            TestHelper.TestSampleType<AccountController>();
        }

        [Test]
        public void PartialViewController()
        {
            TestHelper.TestSampleType<PartialViewController>();
        }

        [Test]
        public void ContentResult()
        {
            TestHelper.TestSampleType<ContentResultSample>();
        }

        [Test]
        public void TraditionalForArrays()
        {
            TestHelper.TestSampleType<TraditionalForArrays>();
        }

        
    }
}
