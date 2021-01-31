using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Statistics.Domain.Tests
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void TestAddAverage()
        {
            var intSample = new Sample<int>();

            int total = 0;
            int count = 0;

            var averageMoq = new Moq.Mock<IStatistic<int>>();

            averageMoq.Setup(s => s.RecordValue(It.IsAny<int>()))
                      .Callback((int v) => {total += v; ++ count;});

            intSample.SetStatistic(averageMoq.Object);

            intSample.Add(0)
                .Add(1)
                .Add(2)
                .Add(3);

            Assert.AreEqual(6, total);
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void TestAddList()
        {
            var valuesToAdd = new List<int>()
            {
                9,8,7,6,5,4,3,2,1
            };
            var sample = new Sample<int>();
            var resultValues = new List<int>();

            var listStatisticMoq = new Moq.Mock<IStatistic<int>>();

            listStatisticMoq.Setup(s => s.RecordValue(It.IsAny<int>()))
                            .Callback((int v) => resultValues.Add(v));

            sample.SetStatistic(listStatisticMoq.Object);

            valuesToAdd.ForEach(v => sample.Add(v));

            CollectionAssert.AreEqual(valuesToAdd, resultValues);
        }
    }
}
