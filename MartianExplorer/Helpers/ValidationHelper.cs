using MartianExplorer.Exceptions;
using MartianExplorer.Models.Entitites;

namespace MartianExplorer.Helpers
{
    public static class ValidationHelper
    {
        public static ValidationResult Validate<T>(this T input)
        {
            switch (input)
            {
                case MartianSurface:
                    return MartianSurface.Validate((dynamic)input);
                case Explorer:
                    return Explorer.Validate((dynamic)input);
                case MoveCommand:
                    return MoveCommand.Validate((dynamic)input);
                default:
                    return new ValidationResult() { IsValid = false };
            }
        }
    }
}