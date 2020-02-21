using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        public FuncionarioController()
        { 

            _FuncionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> ListarFuncionarios()
        {
            return _FuncionarioRepository.ListarFuncionarios();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
          FuncionarioDomain funcionario =  _FuncionarioRepository.BuscarPorId(id);
           
            if (funcionario == null) { 
            return NotFound("Funcionário não encontrado");
            }
            
            return Ok(funcionario);

        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionario)
        {

            _FuncionarioRepository.Cadastrar(funcionario);

            return StatusCode(201, new { menssagem = "Funcionario cadastrado" });
            
        }

        [HttpPut]
        
        public IActionResult Alter(FuncionarioDomain funcionarios)

        {

            FuncionarioDomain funcionario = _FuncionarioRepository.BuscarPorId(funcionarios.ID_Funcionario);

            if (funcionario == null)
            {
                return NotFound(new { erro = "Funcionário não encontrado." });
            }
            try
            {
              _FuncionarioRepository.AlterarViaCorpo(funcionarios);

                return NoContent();
            }
            catch (System.Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AlterById(int id, FuncionarioDomain funcionarios)
        {
         FuncionarioDomain funcionario = _FuncionarioRepository.BuscarPorId(funcionarios.ID_Funcionario);

            if (funcionarios == null)
            {
                return NotFound(new { erro = "Funcionário não encontrado, impossível de editá-lo." });
            }
            try
            {
                _FuncionarioRepository.AlterarViaUrl(id,funcionarios);
            }
            catch (System.Exception erro)
            {

                return NotFound(erro);
            }
            return Ok(funcionarios);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FuncionarioDomain funcionario = _FuncionarioRepository.BuscarPorId(id);

            if (funcionario != null)
            {
                _FuncionarioRepository.Deletar(id);

                return Ok("Funcionario excluído com sucesso.");
               
            }
            try
            {
                return NotFound("Não foi possível excluir esse usuário.");
            }
            catch (System.Exception erro)
            {

                return NotFound(erro);
            }
        }


        [HttpGet("RetornarNome/{nome}")]
        public IActionResult OrdenarporNome(string nome)
        {
            return StatusCode(200, _FuncionarioRepository.RetornarNome(nome));
            //return StatusCode(200, _funcionarioRepository.BuscarPorNome(nome));
        }

        [HttpGet("RetornarFunASC/{ordemnsASC}")]
        public IActionResult RetornarFunASC(string ordemnsASC)
        {
            if (ordemnsASC == "ASC")
            {
                return StatusCode(200, _FuncionarioRepository.RetornarFunASC());
            }
            else
            {
                return StatusCode(400);
            }
        }


      }
    }
