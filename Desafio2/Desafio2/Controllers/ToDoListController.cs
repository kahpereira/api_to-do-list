using Desafio2.Domain.DTO;
using Desafio2.Domain.Entity;
using Desafio2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ToDoListService todolistService;
        public ToDoListController(ToDoListService todolistService)
        {
            this.todolistService = todolistService;
        }

        [HttpGet]
        public IEnumerable<ToDoList> Get()
        {
            return todolistService.ListarTodos();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = todolistService.PesquisarPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoListCreateRequest postModel)
        {

            if (ModelState.IsValid)
            {
                var retorno = todolistService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno.Mensagem);
                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] StatusUpdateRequest putModel)
        {
       
            if (ModelState.IsValid)
            {
                var retorno = todolistService.Editar(id, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}/prioridade")]

        public IActionResult PutPrioridade(int id, [FromBody] PrioridadeUpdateRequest putModel)
        {

            if (ModelState.IsValid)
            {
                var retorno = todolistService.EditarPrioridade(id, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id)
        {
            var retorno = todolistService.Deletar(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();
        }
    }
}
