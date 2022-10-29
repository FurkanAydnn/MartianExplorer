using MartianExplorer.Helpers;
using System.Linq;

namespace MartianExplorer.Models.Entitites
{
    public class MartianSurface : ValidatableBase
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public static ValidationResult Validate(MartianSurface martianSurface)
        {
            var result = new ValidationResult() { IsValid = true };

            var values = martianSurface.RawData.Split(' ');

            if (values.Length != 2)
            {
                result.IsValid = false;
                result.Message = "Mars field size parameters count must be 2.";
            }
            else if (!values.All(x => int.TryParse(x, out var y)))
            {
                result.IsValid = false;
                result.Message = "All Mars field size parameters must be an integer.";
            }

            return result;
        }
    }
}