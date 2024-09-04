using Clinica_Medica.API.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Clinica_Medica.API.Context
{
    public class BDCLinicaMedica : DbContext
    {
        public BDCLinicaMedica(DbContextOptions<BDCLinicaMedica> options) : base(options) 
        {

        }

        public DbSet<CLI_USUARIO> CLI_USUARIO { get; set; }
        public DbSet<CLI_MEDICOS> CLI_MEDICOS { get; set; }


    }
}
