using System.ComponentModel.DataAnnotations;

namespace ServidorAPI.Modelo
{
    public class Plato
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }        
        public decimal Precio { get; set; }
    }
}
