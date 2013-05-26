using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Weld.Test.Scenarios;

namespace Weld.Test
{
    [TestFixture]
    class JSonTests
    {
        [Test]
        public void GenericJSonSample()
        {
            TestHelper.TestSampleType<JSonResultSample>();
        }

        [Test]
        public void JSonSample()
        {
            TestHelper.TestSampleType<NormalJSonResultSample>();
        }

    }
}
