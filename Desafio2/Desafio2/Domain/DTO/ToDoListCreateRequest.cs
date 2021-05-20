using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio2.Domain.DTO
{
    public class ToDoListCreateRequest
    {
		[Required(AllowEmptyStrings = false, ErrorMessage = "O Título é obrigatório!")]
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public int? Prioridade { get; set; }
	}
}
