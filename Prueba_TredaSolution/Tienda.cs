﻿using System.ComponentModel.DataAnnotations;

namespace Prueba_TredaSolution
{
    public class Tienda
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaDeApertura { get; set; }
        [Required]
        public ICollection<Producto> Productos { get; set; }
    }
}
