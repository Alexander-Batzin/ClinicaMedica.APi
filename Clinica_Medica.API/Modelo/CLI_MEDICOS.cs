using System.ComponentModel.DataAnnotations;

namespace Clinica_Medica.API.Modelo
{
    public class CLI_MEDICOS
    {
        [Key]
        public int MED_id { get; set; }
        public int USR_id { get; set; }
        public string MED_nombre { get; set; }
        public string MED_apellido { get; set; }
        public string MED_tipo { get; set; }
        public int MED_telefono { get; set; }
        public string MED_correo { get; set; }
        public string MED_numero_colegiado { get; set; }
        public DateTime? MED_fecha_eliminacion { get; set; } = null;
    }

}