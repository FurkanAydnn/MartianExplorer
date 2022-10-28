using MartianExplorer.Models.Entitites;
namespace MartianExplorer.Helpers
{
    public static class ValidationHelper
    {
        public static bool Validate<T>(this T input)
        {
            switch (input)
            {
                case MartianSurface:
                    return MartianSurface.Validate((dynamic)input);
                case Explorer:
                    return Explorer.Validate((dynamic)input);
                case LocationRequest:
                    return LocationRequest.Validate((dynamic)input);
                default:
                    return false;
            }
        }
    }
}
