namespace ExamenFinal_LuisMayorga.Models
{
    public class Postre : Producto
    {
        public bool ContieneAzucar { get; set; }
        public string Porcion { get; set; } = string.Empty;

        public Postre()
        {
        }

        public Postre(string codigo, string nombre, decimal precioBase, bool contieneAzucar, string porcion)
            : base(codigo, nombre, precioBase)
        {
            ContieneAzucar = contieneAzucar;
            Porcion = porcion;
        }
    }
}
