namespace ExamenFinal_LuisMayorga.Models
{
    public class PlatoFuerte : Producto
    {
        public string TipoCarne { get; set; } = string.Empty;
        public string Acompanamiento { get; set; } = string.Empty;

        public PlatoFuerte()
        {
        }

        public PlatoFuerte(string codigo, string nombre, decimal precioBase, string tipoCarne, string acompanamiento)
            : base(codigo, nombre, precioBase)
        {
            TipoCarne = tipoCarne;
            Acompanamiento = acompanamiento;
        }
    }
}
