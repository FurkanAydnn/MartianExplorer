using MartianExplorer.Models.Entitites;
using NUnit.Framework;

namespace MartianExplorerTests.ValidatorTests
{
    public class ExplorerValidateTests
    {
        [TestCase("1 2 N")]
        [TestCase("1 2 n")]
        public void HandleValidate_ValidArgs_ReturnsSuccess(string rawData)
        {
            //Given
            var explorer = new Explorer()
            {
                RawData = rawData
            };

            //When
            var val = Explorer.Validate(explorer);

            //Then
            Assert.That(val.IsValid, Is.True);
        }

        [TestCase("12n", ExpectedResult = "Explorer parameters count must be 3.")]
        [TestCase("a b n", ExpectedResult = "First two parameters must be an integer.")]
        [TestCase("1 2 4", ExpectedResult = "Direction must be one of (N, E, S, W)")]
        public string HandleValidate_InvalidArgs_ReturnsFailure(string rawData)
        {
            //Given
            var explorer = new Explorer()
            {
                RawData = rawData
            };

            //When
            var val = Explorer.Validate(explorer);

            //Then
            Assert.That(val.IsValid, Is.False);

            return val.Message;
        }
    }
}