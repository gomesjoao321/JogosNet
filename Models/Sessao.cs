using System;
using System.ComponentModel.DataAnnotations;

namespace JogosNet.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Locadora Locadora{ get; set; }
        public virtual Jogo Jogo { get; set; }
        public int JogoId { get; set; }
        public int LocadoraId{ get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
