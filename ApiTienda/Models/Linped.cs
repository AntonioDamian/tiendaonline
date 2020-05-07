﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{

    // Lineas de pedido

    public class Linped
    {
        // Clave primaria compuesta definida en MySQLDbContext
        
        [ForeignKey("Pedido")]
        public int PedidoID { get; set; }
        public int Linea { get; set; }
        [ForeignKey("Articulo")]
        public string ArticuloID { get; set; }
        public decimal Importe { get; set; }
        public int Cantidad { get; set; }
    }
}
