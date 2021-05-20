using Desafio2.DAL;
using Desafio2.Domain.DTO;
using Desafio2.Domain.Entity;
using Desafio2.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio2.Services
{
    public class ToDoListService
    {
        private readonly AppDbContext _dbContext;
        public ToDoListService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ServiceResponse<ToDoList> CadastrarNovo(ToDoListCreateRequest model)
        {
            if (model.Prioridade == null)
            {
                model.Prioridade = 5;
            }
            else if (model.Prioridade < 1 || model.Prioridade > 5)
            {
                return new ServiceResponse<ToDoList>("Escolha entre 1 a 5");
            }

            var CadastroTarefa = new ToDoList()
            {
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Status = false,
                Prioridade = model.Prioridade
            };

            _dbContext.Add(CadastroTarefa);
            _dbContext.SaveChanges();

            return new ServiceResponse<ToDoList>(CadastroTarefa);
        }
        public List<ToDoList> ListarTodos()
        {
            return _dbContext.Tarefas.ToList();
        }

        public ServiceResponse<ToDoList> PesquisarPorId(int id)
        {
            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);
            if (resultado == null)
                return new ServiceResponse<ToDoList>("Não encontrado!");
            else
                return new ServiceResponse<ToDoList>(resultado);
        }

        public ServiceResponse<ToDoList> Editar(int id, StatusUpdateRequest model)
        {
            
            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

            if (resultado == null)
                return new ServiceResponse<ToDoList>("Tarefa não encontrada!");

            resultado.Status = true;
            _dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<ToDoList>(resultado);
        }
        public ServiceResponse<ToDoList> EditarPrioridade(int id, PrioridadeUpdateRequest model)
        {

            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

            if (resultado == null)
                return new ServiceResponse<ToDoList>("Tarefa não encontrada!");

            resultado.Prioridade = model.Prioridade;
            _dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<ToDoList>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        { 
            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

            if (resultado == null)
                return new ServiceResponse<bool>("Tarefa não encontrada!");

            _dbContext.Tarefas.Remove(resultado);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);
        }

    }
}
