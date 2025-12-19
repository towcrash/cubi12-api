using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.Models
{
    //Modelo de carrera
    public class Career : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; } = null!;
    }
}