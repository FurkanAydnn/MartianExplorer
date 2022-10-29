using System.ComponentModel.DataAnnotations;

namespace MartianExplorer.Models.Entitites
{
    public enum Direction
    {
        [Display(Name = "N")]
        North,
        [Display(Name = "E")]
        East,
        [Display(Name = "S")]
        South,
        [Display(Name = "W") ]
        West
    }
}