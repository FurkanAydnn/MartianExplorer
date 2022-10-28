using System.Text.RegularExpressions;

namespace MartianExplorer.Models.Entitites
{
    public class LocationRequest
    {
        public string MoveCommand { get; set; }

        public static bool Validate(LocationRequest locationRequest)
        {
            Regex rgx = new Regex("[^RLM][^rlm]");
            if (rgx.IsMatch(locationRequest.MoveCommand))
            {
                return false;
            }

            return true;
        }
    }
}
