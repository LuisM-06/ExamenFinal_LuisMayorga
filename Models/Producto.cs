using System.Text.Json.Serialization;

namespace ExamenFinal_LuisMayorga.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$tipo")]
    [JsonDerivedType(typeof(Bebida), "bebida")]
    [JsonDerivedType(typeof(PlatoFuerte), "platoFuerte")]
    [JsonDerivedType(typeof(Postre), "postre")]
    public class Producto
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }

        public Producto()
        {
        }

        public Producto(string codigo, string nombre, decimal precioBase)
        {
            Codigo = codigo;
            Nombre = nombre;
            PrecioBase = precioBase;
        }
    }
}