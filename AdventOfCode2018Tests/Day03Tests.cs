namespace AdventOfCode2018Tests
{
    using AdventOfCode2018;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Day03Tests
    {
        private readonly string path = @"C:\src\AdventOfCode\AdventOfCode2018Tests\resources\Day03.input";

        [TestMethod]
        public void ShouldGetCorrectChecksum()
        {
            var result = Day03.GetNumberOfConflicts(path);
            Assert.AreEqual(4, result);
        }
    }
}
