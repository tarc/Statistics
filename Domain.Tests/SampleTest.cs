using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Statistics.Sample.Tests
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void TestCtor()
        {
            var sample = new Sample.Sample<int>();
        }
    }
}
