using MartianExplorer.Helpers;
using System;
using System.Linq;

namespace MartianExplorer.Models.Entitites
{
    public class Explorer : ValidatableBase
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Direction Direction { get; set; }

        public static ValidationResult Validate(Explorer explorer)
        {
            var result = new ValidationResult() { IsValid = true };

            var values = explorer.RawData.Split(' ');

            if (values.Length != 3)
            {
                result.IsValid = false;
                result.Message = "Explorer parameters count must be 3.";
            }
            else if (!values.Take(2).Any(x => int.TryParse(x, out var y)))
            {
                result.IsValid = false;
                result.Message = "First two parameters must be an integer.";
            }
            else if (!values.Last().ToUpper().TryGetValueFromDisplay<Direction>(out var dir))
            {
                result.IsValid = false;
                result.Message = "Direction must be one of (N, E, S, W)";
            }

            return result;
        }
    }
}