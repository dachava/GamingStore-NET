namespace JN_Aplicacion_Proyecto.Entities
{
    public class CarritoObj
    {
        public int ID { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_USUARIO { get; set; }
        public string NOMBRE { get; set; } = string.Empty;
        public int PRECIO { get; set; } = 0;
    }
}
