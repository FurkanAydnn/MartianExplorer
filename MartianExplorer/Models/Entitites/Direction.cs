using System.ComponentModel.DataAnnotations;

namespace MartianExplorer.Models.Entitites
{
    public enum Direction
    {
        [Display(Name = "N")]
        N,
        [Display(Name = "W")]
        W,
        [Display(Name = "S")]
        S,
        [Display(Name = "E") ]
        E
    }
}
