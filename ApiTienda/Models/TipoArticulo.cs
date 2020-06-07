using System.ComponentModel.DataAnnotations;

namespace API_Tienda.Models
{
    public class TipoArticulo
    {
        [Key]
        public int TipoArticuloID { get; set; }
        public string Descripcion { get; set; }
    }
}
