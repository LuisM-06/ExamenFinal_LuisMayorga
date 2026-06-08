namespace ExamenFinal_LuisMayorga.Models
{
    public class Bebida : Producto
    {
        public int VolumenMl { get; set; }
        public string Tipo { get; set; } = string.Empty;

        public Bebida()
        {
        }

        public Bebida(string codigo, string nombre, decimal precioBase, int volumenMl, string tipo)
            : base(codigo, nombre, precioBase)
        {
            VolumenMl = volumenMl;
            Tipo = tipo;
        }
    }
}
