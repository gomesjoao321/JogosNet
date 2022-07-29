using AutoMapper;
using JogosNet.Data;
using JogosNet.Data.Dtos;
using JogosNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JogosNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public JogoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaJogo([FromBody] CreateJogoDto jogoDto)
        {
            Jogo jogo = _mapper.Map<Jogo>(jogoDto);
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaJogosPorId), new { Id = jogo.Id }, jogo);
         }
        [HttpGet]
        public IEnumerable<Jogo> RecuperaJogos()
        {
            return _context.Jogos;
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaJogosPorId(int id)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(jogo => jogo.Id == id);
            if (jogo != null)
            {
                ReadJogoDto jogoDto = _mapper.Map<ReadJogoDto>(jogo);
                return Ok(jogoDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaJogo(int id, [FromBody] UpdateJogoDto jogoDto)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(jogo => jogo.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }
            _mapper.Map(jogoDto, jogo);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaJogo(int id)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(jogo => jogo.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }
            _context.Remove(jogo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
