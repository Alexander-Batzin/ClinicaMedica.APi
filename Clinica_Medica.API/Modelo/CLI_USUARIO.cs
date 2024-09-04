using System.ComponentModel.DataAnnotations;

namespace Clinica_Medica.API.Modelo
{
    public class CLI_USUARIO
    {
        [Key]
        public int USR_id { get; set; }
        public string USR_usuario { get; set; }
        public string USR_contrasena { get; set; }
        public DateTime? USR_fecha_eliminacion { get; set; } = null;
    }
}
