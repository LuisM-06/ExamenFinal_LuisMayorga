using System.Text.Json;
using ExamenFinal_LuisMayorga.Models;

namespace ExamenFinal_LuisMayorga.Services
{
    public class ProductoService
    {
        private readonly string rutaArchivo;
        private List<Producto> productos = new List<Producto>();

        public ProductoService()
        {
            string carpetaDatos = Path.Combine(AppContext.BaseDirectory, "Datos");

            if (!Directory.Exists(carpetaDatos))
            {
                Directory.CreateDirectory(carpetaDatos);
            }

            rutaArchivo = Path.Combine(carpetaDatos, "productos.json");

            CargarDesdeJson();
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }

        public int ObtenerTotalProductos()
        {
            return productos.Count;
        }

        public bool ExisteCodigo(string codigo)
        {
            return productos.Any(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            GuardarEnJson();
        }

        public List<Producto> BuscarProductos(string criterio, string textoBusqueda)
        {
            if (criterio == "Todos")
            {
                return productos;
            }

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                return productos;
            }

            textoBusqueda = textoBusqueda.Trim();

            if (criterio == "Codigo")
            {
                return productos
                    .Where(p => p.Codigo.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (criterio == "Nombre")
            {
                return productos
                    .Where(p => p.Nombre.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (criterio == "Tipo")
            {
                return productos
                    .Where(p => ObtenerTipoProducto(p).Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return productos;
        }

        public string ObtenerTipoProducto(Producto producto)
        {
            if (producto is Bebida)
            {
                return "Bebida";
            }

            if (producto is PlatoFuerte)
            {
                return "Plato fuerte";
            }

            if (producto is Postre)
            {
                return "Postre";
            }

            return "Producto";
        }

        private void GuardarEnJson()
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(productos, opciones);
            File.WriteAllText(rutaArchivo, json);
        }

        private void CargarDesdeJson()
        {
            if (!File.Exists(rutaArchivo))
            {
                productos = new List<Producto>();
                return;
            }

            string json = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                productos = new List<Producto>();
                return;
            }

            productos = JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
        }
    }
}
