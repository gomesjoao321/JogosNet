using AutoMapper;
using JogosNet.Data;
using JogosNet.Data.Dtos.Atendente;
using JogosNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace JogosNet.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class AtendenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public AtendenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaAtendente([FromBody] CreateAtendenteDto dto)
        {
            Atendente atendente = _mapper.Map<Atendente>(dto);
            _context.Atendentes.Add(atendente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaAtendentePorId), new { Id = atendente.Id }, atendente);
        }
        [HttpGet("id")]
        public IActionResult RecuperaAtendentePorId(int id)
        {
            Atendente atendente = _context.Atendentes.FirstOrDefault(atendente => atendente.Id == id);
            if (atendente == null)
            {
                ReadAtendenteDto atendenteDto = _mapper.Map<ReadAtendenteDto>(atendente);
                return Ok(atendenteDto);
            }
            return NotFound();
        }
        [HttpDelete("id")]
        public IActionResult DeletaAtendente(int id)
        {
            Atendente atendente = _context.Atendentes.FirstOrDefault(atendente => atendente.Id == id);
            if (atendente == null)
            {
                return NotFound();
            }
            _context.Remove(atendente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
