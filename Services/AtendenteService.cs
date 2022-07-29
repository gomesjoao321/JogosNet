using AutoMapper;
using FluentResults;
using JogosNet.Data;
using JogosNet.Data.Dtos.Atendente;
using JogosNet.Models;
using System.Linq;

namespace JogosNet.Services
{
    public class AtendenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        
        public AtendenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadAtendenteDto AdicionaAtendente(CreateAtendenteDto dto)
        {
            Atendente atendente = _mapper.Map<Atendente>(dto);
            _context.Atendentes.Add(atendente);
            _context.SaveChanges();
            return _mapper.Map<ReadAtendenteDto>(atendente);
        }
        public ReadAtendenteDto RecuperaAtendente(int id)
        {
            Atendente atendente = _context.Atendentes.FirstOrDefault(atendente => atendente.Id == id);
            if (atendente != null)
            {
                ReadAtendenteDto atendenteDto = _mapper.Map<ReadAtendenteDto>(atendente);

                return atendenteDto;
            }
            return null;
        }
        internal Result DeletaAtendente(int id)
        {
            Atendente atendente= _context.Atendentes.FirstOrDefault(atendente => atendente.Id == id);
            if (atendente == null)
            {
                return Result.Fail("Atendente não encontrado");
            }
            _context.Remove(atendente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}