using AutoMapper;
using FluentResults;
using JogosNet.Data;
using JogosNet.Data.Dtos;
using JogosNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace JogosNet.Services
{
    public class LocadoraService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        
        public LocadoraService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public ReadLocadoraDto AdicionaLocadora(CreateLocadoraDto locadoraDto)
        {
            Locadora locadora = _mapper.Map<Locadora>(locadoraDto);
            _context.Locadoras.Add(locadora);
            _context.SaveChanges();
            return _mapper.Map<ReadLocadoraDto>(locadora);
        }
        
        public List<ReadLocadoraDto> RecuperaLocadora(string nomeDoJogo)
        {
            List<Locadora> locadoras = _context.Locadoras.ToList();
            if (locadoras == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoJogo))
            {
                IEnumerable<Locadora> query = from locadora in locadoras
                                              where locadora.Sessoes.Any(sessao =>
                                              sessao.Jogo.Titulo == nomeDoJogo)
                                              select locadora;
                locadoras = query.ToList();
            }
            return _mapper.Map<List<ReadLocadoraDto>>(locadoras);
        }
        
        public ReadLocadoraDto RecuperaLocadorasPorId(int id)
        {
            Locadora locadora = _context.Locadoras.FirstOrDefault(locadora => locadora.Id == id);
            if(locadora != null)
            {
                return _mapper.Map<ReadLocadoraDto>(locadora);
            }
            return null;
        }
        
        public Result AtualizaLocadora(int id, UpdateLocadoraDto locadoraDto)
        {
            Locadora locadora = _context.Locadoras.FirstOrDefault(locadora => locadora.Id == id);
            if(locadora == null)
            {
                return Result.Fail("Locadora não encontrada");
            }
            _mapper.Map(locadoraDto, locadora);
            _context.SaveChanges();
            return Result.Ok();
        }
        
        public Result DeletaLocadora(int id)
        {
            Locadora locadora = _context.Locadoras.FirstOrDefault(locadora => locadora.Id == id);
            if (locadora == null)
            {
                return Result.Fail("Locadora não encontrada");
            }
            _context.Remove(locadora);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
