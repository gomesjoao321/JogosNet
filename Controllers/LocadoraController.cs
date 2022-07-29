using AutoMapper;
using JogosNet.Data;
using JogosNet.Data.Dtos;
using JogosNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JogosNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocadoraController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public LocadoraController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaLocadora([FromBody] CreateLocadoraDto locadoraDto)
        {
            Locadora locadora= _mapper.Map<Locadora>(locadoraDto);
            _context.Locadoras.Add(locadora);
             _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaLocadorasPorId), new { Id = locadora.Id }, locadora);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaLocadorasPorId(int id)
        {
            Locadora locadora= _context.Locadoras.FirstOrDefault(locadora=> locadora.Id == id);
            if (locadora != null)
            {
                ReadLocadoraDto locadoraDto = _mapper.Map<ReadLocadoraDto>(locadora);
                return Ok(locadoraDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaLocadora(int id, [FromBody] UpdateLocadoraDto locadoraDto)
        {
            Locadora locadora = _context.Locadoras.FirstOrDefault(locadora=> locadora.Id == id);
            if (locadora== null)
            {
                return NotFound();
            }
            _mapper.Map(locadoraDto, locadora);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaLocadora(int id)
        {
            Locadora locadora= _context.Locadoras.FirstOrDefault(locadora=> locadora.Id == id);
            if (locadora == null)
            {
                return NotFound();
            }
            _context.Remove(locadora);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
