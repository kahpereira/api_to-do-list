using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio2.Domain.Entity
{
    [Table("Tarefas")]
    public class ToDoList
    {
        [Key]
        public int IdTarefa { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [StringLength(255)]
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public int? Prioridade { get; set; }
    }
}
