namespace JN_Aplicacion.Entities
{
    public class PersonaObj
    {
        public int ID_USUARIO { get; set; }
        public int ID_TIPO { get; set; } 
        public string NOMBRE { get; set; } = string.Empty;
        public string APELLIDO { get; set; } = string.Empty;
        public string CONTRASENA { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
