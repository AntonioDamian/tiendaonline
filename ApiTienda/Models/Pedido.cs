using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Linped> LineasPedido { get; set; }

    }
}
