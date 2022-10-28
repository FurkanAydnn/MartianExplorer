using MartianExplorer.Helpers;
using System.Linq;

namespace MartianExplorer.Models.Entitites
{
    public class MartianSurface
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string RawData { get; set; }

        public static bool Validate(MartianSurface martianSurface)
        {
            var values = martianSurface.RawData.Split(' ');

            if (values.Length != 2)
            {
                ConsoleHelper.WriteLetterByLetter("Mars field size parameters count must be 2.");
                return false;
            }

            if (!values.All(x => int.TryParse(x, out var y)))
            {
                ConsoleHelper.WriteLetterByLetter("All Mars field size parameters must be an integer.");
                return false;
            }

            return true;
        }
    }
}
