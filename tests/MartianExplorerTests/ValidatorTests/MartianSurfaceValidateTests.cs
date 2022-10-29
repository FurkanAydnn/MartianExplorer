using MartianExplorer.Models.Entitites;
using NUnit.Framework;

namespace MartianExplorerTests.ValidatorTests
{
    public class MartianSurfaceValidateTests
    {
        [TestCase("1 2")]
        public void HandleValidate_ValidArgs_ReturnsSuccess(string rawData)
        {
            //Given
            var martianSurface = new MartianSurface()
            {
                RawData = rawData
            };

            //When
            var val = MartianSurface.Validate(martianSurface);

            //Then
            Assert.That(val.IsValid, Is.True);
        }

        [TestCase("12", ExpectedResult = "Mars field size parameters count must be 2.")]
        [TestCase("a b", ExpectedResult = "All Mars field size parameters must be an integer.")]
        public string HandleValidate_InvalidArgs_ReturnsFailure(string rawData)
        {
            //Given
            var martianSurface = new MartianSurface()
            {
                RawData = rawData
            };

            //When
            var val = MartianSurface.Validate(martianSurface);

            //Then
            Assert.That(val.IsValid, Is.False);

            return val.Message;
        }
    }
}