namespace AdventOfCode2018Tests
{
    using AdventOfCode2018;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class Day03Tests
    {
        private readonly string path = @"C:\src\AdventOfCode\AdventOfCode2018Tests\resources\Day03.input";

        [TestMethod]
        public void ShouldGetCorrectNumberOfConflicts()
        {
            const int fabricSize = 1000;
            var result = Day03.GetNumberOfConflictsAndRemainingCleanClaims(path, fabricSize);
            Assert.AreEqual(104126, result.Item1);
        }

        [TestMethod]
        public void ShouldGetTheOnlyConflictFreeId()
        {
            const int fabricSize = 1000;
            var result = Day03.GetNumberOfConflictsAndRemainingCleanClaims(path, fabricSize);
            Assert.AreEqual(1, result.Item2.Count);
            Assert.AreEqual("695", result.Item2.First());
        }
    }
}
