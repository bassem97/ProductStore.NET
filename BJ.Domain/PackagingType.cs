using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BJ.Domain
{
    public enum PackagingType
    {
        [Display(Name = "Plastic")]
        Plastique = 0 ,
        
        [Display(Name = "Cardboard")]
        Carton = 10,
        
        Metal = 20,
        
    }
}