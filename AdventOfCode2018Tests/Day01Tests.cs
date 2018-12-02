using AdventOfCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018Tests
{
    [TestClass]
    public class Day01Tests
    {
        private readonly string path = @"C:\src\AdventOfCode\AdventOfCode2018Tests\resources\Day01.txt";

        [TestMethod]
        public void ShouldCalculateCorrectFinalFrequency()
        {
            var result = Day01.GetFinalFrequency(path);
            Assert.AreEqual(466, result);
        }

        [TestMethod]
        public void ShouldCalculateFirstDuplicatedFrequency()
        {
            var result = Day01.GetFirstDuplicatedFrequency(path);
            Assert.AreEqual(750, result);
        }
    }
}
