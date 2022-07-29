using System;

namespace JogosNet.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        public int LocadoraId { get; set; }
        public int JogoId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
