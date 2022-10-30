using System.Text.RegularExpressions;

namespace MartianExplorer.Models.Entitites
{
    public class MoveCommand : ValidatableBase
    {
        public string Command { get; set; }

        public static ValidationResult Validate(MoveCommand moveCommand)
        {
            var result = new ValidationResult() { IsValid = false };
            Regex rgx = new Regex("[^RLMrlm]");
            if (!rgx.IsMatch(moveCommand.RawData))
            {
               result.IsValid = true;
            }

            result.Message = "Unmatched character detected in move command";

            return result;
        }
    }
}