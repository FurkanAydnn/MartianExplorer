using MartianExplorer.Models.Entitites;
using NUnit.Framework;

namespace MartianExplorerTests.ValidatorTests
{
    public class MoveCommandValidateTests
    {
        [TestCase("mlrmlrmrlmrl")]
        [TestCase("MLRMRLMRLM")]
        public void HandleValidate_ValidArgs_ReturnsSuccess(string rawData)
        {
            //Given
            var moveCommand = new MoveCommand()
            {
                RawData = rawData
            };

            //When
            var val = MoveCommand.Validate(moveCommand);

            //Then
            Assert.That(val.IsValid, Is.True);
        }

        [TestCase("asdasd", ExpectedResult = "Unmatched character detected in move command")]
        public string HandleValidate_InvalidArgs_ReturnsFailure(string rawData)
        {
            //Given
            var moveCommand = new MoveCommand()
            {
                RawData = rawData
            };

            //When
            var val = MoveCommand.Validate(moveCommand);

            //Then
            Assert.That(val.IsValid, Is.False);

            return val.Message;
        }
    }
}