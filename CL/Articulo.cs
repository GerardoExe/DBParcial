namespace CL
{
    public class Articulo
    {
        public int ID_Articulo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Unidad { get; set; } = string.Empty;//Ej: unidad, kg, litro
    }
}
