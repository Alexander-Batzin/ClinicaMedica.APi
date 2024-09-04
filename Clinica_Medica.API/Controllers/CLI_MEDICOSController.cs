using Clinica_Medica.API.Context;
using Clinica_Medica.API.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica_Medica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLI_MEDICOSController : ControllerBase
    {
        private readonly BDCLinicaMedica medico;

        public CLI_MEDICOSController(BDCLinicaMedica medico)
        {
            this.medico = medico;
        }

        [HttpGet]
        public async Task<List<CLI_MEDICOS>> Listar()
        {
           return await medico.CLI_MEDICOS.ToListAsync();
        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<CLI_MEDICOS>> BuscarPorId(int Id)
        {
            var resultado = await medico.CLI_MEDICOS.FirstOrDefaultAsync(x => x.MED_id == Id);
            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CLI_MEDICOS>> Insertar(CLI_MEDICOS m)
        {
            try
            {
                await medico.CLI_MEDICOS.AddAsync(m);
                await medico.SaveChangesAsync();
                m.MED_id = await medico.CLI_MEDICOS.MaxAsync(x => x.MED_id);

                return m;


            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CLI_MEDICOS>> Actualizar(CLI_MEDICOS m)
        {
            if(m == null || m.MED_id == 0)
                return BadRequest("No Contiene Datos");

            CLI_MEDICOS temp = await medico.CLI_MEDICOS.FirstOrDefaultAsync(x => x.MED_id == m.MED_id);
            if (temp == null)
                return NotFound();
            try
            {
                temp.USR_id = m.USR_id;
                temp.MED_nombre = m.MED_nombre;
                temp.MED_apellido = m.MED_apellido;
                temp.MED_tipo = m.MED_tipo;
                temp.MED_telefono = m.MED_telefono;
                temp.MED_correo = m.MED_correo;
                temp.MED_numero_colegiado = m.MED_numero_colegiado;
                medico.CLI_MEDICOS.Update(temp);
                await medico.SaveChangesAsync();

                return temp;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int Id)
        {
            CLI_MEDICOS temp = await medico.CLI_MEDICOS.FirstOrDefaultAsync(x => x.MED_id == Id);
            if (temp == null) 
                return NotFound();
            try
            {
                medico.CLI_MEDICOS.Remove(temp);
                await medico.SaveChangesAsync();
                return (true);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
