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
            TestSampleType<ConstValues>();
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
            TestSampleType<StringMethod>();
        }

        [Test]
        public void CustomUrl()
        {
            TestSampleType<CustomUrl>();
        }

        [Test]
        public void VoidMethods()
        {
            TestSampleType<VoidMethod>();
        }

        [Test]
        public void PostStringMethod()
        {
            TestSampleType<PostStringMethod>();
        }

        [Test]
        public void BoolMethod()
        {
            TestSampleType<BoolMethod>();
        }

        [Test]
        public void AnyForUnknown()
        {
            TestSampleType<AnyForUnknown>();
        }


        [Test]
        public void MethodWithReturnValue()
        {
            TestSampleType<MethodWithReturnValue>();
        }

        [Test]
        public void ControllerIsOmittedFromUrl()
        {
            TestSampleType<AccountController>();
        }

        [Test]
        public void PartialViewController()
        {
            TestSampleType<PartialViewController>();
        }

        [Test]
        public void ContentResult()
        {
            TestSampleType<ContentResultSample>();
        }

        [Test]
        public void TraditionalForArrays()
        {
            TestSampleType<TraditionalForArrays>();
        }

        
        private void TestSampleType<T>()
        {
            var name = typeof (T).Name;
            var fileName = string.Format("{0}.ts",name);
            var expectContent = File.ReadAllText(string.Format("./../../Scenarios/{0}",fileName));

            
            var result = processor.Process(typeof (T));

            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(expectContent,result.Content);
        }
    }
}
