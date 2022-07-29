using JogosNet.Models;
using System;

namespace JogosNet.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Locadora Locadora{ get; set; }
        public Jogo Jogo{ get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
