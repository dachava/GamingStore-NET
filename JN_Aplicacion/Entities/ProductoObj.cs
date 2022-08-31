namespace JN_Aplicacion_Proyecto.Entities
{
    public class ProductoObj
    {

        public int ID_PRODUCTO { get; set; } = 0;
        public int ID_TIPO { get; set; }
        public string EMPRESA { get; set; } = string.Empty;
        public string NOMBRE { get; set; } = string.Empty;
        public string DESCRIPCION { get; set; } = string.Empty;
        public int PRECIO { get; set; } = 0;
        public string IMAGE_URL { get; set; } = string.Empty;
        
    }
}
