using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_back.Model;
using Repositorio.Interfaces;

namespace Projeto_back.Controllers{
   [Route("Api/[Controller]")] 
   [ApiController]

   public class AlunoController : ControllerBase{
        private readonly IAlunoRepositorio _alunoRepositorio;
        
        public AlunoController(IAlunoRepositorio alunoRepositorio){
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet("ConsultarTodosAlunos")]
        public async Task<List<Aluno>>ConsultarTodosAlunos(){

            List<Aluno> alunos = await _alunoRepositorio.ConsultarTodosAlunos();
            return alunos;
        }

        [HttpGet("Consultar")]
         public async Task<ActionResult<Aluno>>ConsultarAluno(int IdAluno){
            
            Aluno aluno = await _alunoRepositorio.ConsultarAluno(IdAluno);
            return aluno;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<Aluno>>Adicionar([FromBody] Aluno aluno){
           
            Aluno alunos = await _alunoRepositorio.Adicionar(aluno);
            return Ok(aluno);
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<Aluno>>Atualizar([FromBody] Aluno aluno, int IdAluno){
            
            
            Aluno alunos = await _alunoRepositorio.Atualizar(aluno, IdAluno);
            return Ok(aluno);
        }

        [HttpDelete("Apagar")]
        public async Task<ActionResult<Aluno>>Apagar(int IdAluno){
            
            bool Apagado = await _alunoRepositorio.Apagar(IdAluno);
            return Ok(Apagado);
        }
   }
}