using ExoApi.Interfaces;
using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]// Formato de resposta
    [Route("api/[controller]")] // rota de acesso da api ; api/livro
    [ApiController]// identifica que é um controller
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _ilivroRepository; // proriedade privade de somente leitura
        public LivroController(ILivroRepository ilivroRepository)
        {
            _ilivroRepository = ilivroRepository;
        }
        [HttpGet]
        public IActionResult Listar() 
        {
            try
            {
                return Ok(_ilivroRepository.Ler());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        
        public IActionResult Cadastrar(Livro livro) 
        {
            try
            {
                _ilivroRepository.Cadastrar(livro);
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(int id, Livro livro) 
        {
            try
            {
                _ilivroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpDelete]    
        public IActionResult Delete(int id) 
        {
            try
            {
                _ilivroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("(id)")]
        public IActionResult GetById(int id) 
        {
            try
            {
                Livro livro= _ilivroRepository.BuscarPorId(id);
                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("(titulo/{titulo}")]
        public IActionResult GetByTitulo(string titulo) 
        {
            try
            {
                Livro livro= _ilivroRepository.BuscarPorTitulo(titulo);
                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
// CRUD ; Create, Read, Update e Delete