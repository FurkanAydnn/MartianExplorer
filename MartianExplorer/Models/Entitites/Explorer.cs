using MartianExplorer.Helpers;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MartianExplorer.Models.Entitites
{
    public class Explorer
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Direction Direction { get; set; }
        public string RawData { get; set; }

        public static bool Validate(Explorer explorer)
        {
            var values = explorer.RawData.Split(' ');

            if (values.Length != 3)
            {
                ConsoleHelper.WriteLetterByLetter("Explorer parameters count must be 3.");
                return false;
            }

            if (!values.Take(2).Any(x => int.TryParse(x, out var y)))
            {
                ConsoleHelper.WriteLetterByLetter("First two parameters must be an integer.");
                return false;
            }

            if (!Enum.TryParse<Direction>(values.Last().ToUpper(), out var dir))
            {
                return false;
            }

            return true;
        }
    }
}
