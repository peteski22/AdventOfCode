namespace AdventOfCode2018Tests
{
    using AdventOfCode2018;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Day02Tests
    {
        private readonly string path = @"C:\src\AdventOfCode\AdventOfCode2018Tests\resources\Day02.input";

        [TestMethod]
        public void ShouldGetCorrectChecksum()
        {
            var result = Day02.GetChecksum(path);
            Assert.AreEqual(5681, result);
        }

        [TestMethod]
        public void ShouldGetCharactersWhereOnlySingleCharDifference()
        {
            var result = Day02.GetCharactersWhereOnlySingleCharDifference(path);
            Assert.AreEqual("uqyoeizfvmbstpkgncjwld", result);
        }
    }
}
