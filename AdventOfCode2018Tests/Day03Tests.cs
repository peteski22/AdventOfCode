namespace AdventOfCode2018Tests
{
    using AdventOfCode2018;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Day03Tests
    {
        private readonly string path = @"C:\src\AdventOfCode\AdventOfCode2018Tests\resources\Day03.input";

        [TestMethod]
        public void ShouldGetCorrectNumberOfConflicts()
        {
            const int fabricSize = 1000;
            var result = Day03.GetNumberOfConflicts(path, fabricSize);
            Assert.AreEqual(85509, result); // TODO: Not actual correct answer
        }
    }
}
