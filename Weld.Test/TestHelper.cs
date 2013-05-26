using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Weld.Test
{
    class TestHelper
    {
        public static void TestSampleType<T>(string folder = "Scenarios")
        {
            var processor = new TypeScriptProcessor();
            //switch between testing and writing expectations
            var writeExpectations = false;

            var name = typeof (T).Name;
            var fileName = String.Format("{0}.ts",name);
            var filePath = String.Format("./../../{0}/{1}", folder, fileName);
            var expectContent = File.ReadAllText(filePath);

            
            var result = processor.Process(typeof (T));

            if (!writeExpectations)
            {
                Assert.AreEqual(fileName, result.FileName);
                Assert.AreEqual(expectContent, result.Content);    
            }
            else
            {
                File.WriteAllText(filePath, result.Content);
            }
            
        }
    }
}
