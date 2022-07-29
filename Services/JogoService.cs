using AutoMapper;
using FluentResults;
using JogosNet.Data;
using JogosNet.Data.Dtos;
using JogosNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace JogosNet.Services
{
    public class JogoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public JogoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadJogoDto AdicionaFilme(CreateJogoDto jogoDto)
        {
            Jogo jogo = _mapper.Map<Jogo>(jogoDto);
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
            return _mapper.Map<ReadJogoDto>(jogo);
        }

        public List<ReadJogoDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Jogo> jogos;
            if (classificacaoEtaria == null)
            {
                jogos = _context.Jogos.ToList();
            }
            else
            {
                jogos= _context
                .Jogos.Where(jogo=> jogo.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (jogos!= null)
            {
                List<ReadJogoDto> readDto = _mapper.Map<List<ReadJogoDto>>(jogos);
                return readDto;
            }
            return null;
        }

        public ReadJogoDto RecuperaJogosPorId(int id)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(jogo => jogo.Id == id);
            if (jogo != null)
            {
                ReadJogoDto jogoDto = _mapper.Map<ReadJogoDto>(jogo);

                return jogoDto;
            }
            return null;
        }
        public Result AtualizaJogo(int id, UpdateJogoDto jogoDto)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(jogo => jogo.Id == id);
            if (jogo == null)
            {
                return Result.Fail("Jogo não encontrado");
            }
            _mapper.Map(jogoDto, jogo);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(jogo => jogo.Id == id);
            if (jogo == null)
            {
                return Result.Fail("Jogo não encontrado");
            }
            _context.Remove(jogo);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}


