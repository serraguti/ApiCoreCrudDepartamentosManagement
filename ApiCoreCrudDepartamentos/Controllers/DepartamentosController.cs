using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> Get()
        {
            return await this.repo.GetDepartamentosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }

        //EXISTEN METODOS QUE SON POR DEFECTO PARA POST, PUT Y DELETE
        //LOS DOS PRIMEROS METODOS RECIBEN OBJETOS
        //EL METODO DELETE RECIBE UN ID, IGUAL QUE GET(ID)
        //SI QUISIERAMOS RECIBIR EL OBJETO POR PARAMETROS
        //DEBEMOS HACERLO CON [Route]
        //AL DEVOLVER UN ACTIONRESULT, PODEMOS PERSONALIZAR LA 
        //RESPUESTA EN LOS METODOS DE ACCION
        //return Ok();
        //return BadRequest();
        //return NotFound();

        [HttpPost]
        public async Task<ActionResult> 
            InsertDepartamento(Departamento departamento)
        {
            await this.repo.InsertarDepartamentoAsync
                (departamento.IdDepartamento, departamento.Nombre
                , departamento.Localidad);
            return Ok();
        }

        //SI DESEAMOS POR PARAMETROS
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult>
            InsertarDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.InsertarDepartamentoAsync
                (id, nombre, localidad);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartamento
            (Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return Ok();
        }
    }
}
