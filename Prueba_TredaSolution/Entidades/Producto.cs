using System.ComponentModel.DataAnnotations;

namespace Prueba_Tecnica_Treda.Entidades
{
    public class Producto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int SKU { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public int TiendaId { get; set; }
        [Required]
        public Tienda Tienda { get; set; }
    }
}
