using Microsoft.EntityFrameworkCore;
using Projeto_back.Model;
using Projeto_back.Data;
using Repositorio.Interfaces;

namespace Projeto_back.Repositorios{

    public class AlunoRepositorio : IAlunoRepositorio
    {   
        private readonly AlunoContext _dbContext;
        public AlunoRepositorio(AlunoContext dbContext){
            _dbContext = dbContext;
        }

        public async Task<Aluno> ConsultarAluno(int id)
        {
            return await _dbContext.Alunos.FirstOrDefaultAsync(x => x.IdAluno == id);
        }

        public async Task<List<Aluno>> ConsultarTodosAlunos()
        {
            try{
                List<Aluno> x = _dbContext.Alunos.ToList();
                return x;
            }
            catch(Exception e){
                Console.WriteLine(e);
            }

            return null;
           
        }
        public async Task<Aluno> Adicionar(Aluno aluno)
        {
            await _dbContext.Alunos.AddAsync(aluno);
            await _dbContext.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> Atualizar(Aluno aluno, int IdAluno)
        {
            Aluno alunoPorId = await ConsultarAluno(IdAluno);
            if(alunoPorId == null){
                throw new Exception($"O aluno do Id: {IdAluno} não foi encontrado");
            }

            alunoPorId.Nome = aluno.Nome;
            alunoPorId.CPF = aluno.CPF;
            alunoPorId.NumTelefone = aluno.NumTelefone;

            _dbContext.Alunos.Update(alunoPorId);
            await _dbContext.SaveChangesAsync();

            return alunoPorId;
        }

        public async Task<bool> Apagar(int IdAluno)
        {
             Aluno alunoPorId = await ConsultarAluno(IdAluno);
            if(alunoPorId == null){
                throw new Exception($"O aluno do Id: {IdAluno} não foi encontrado");
            }
            
            _dbContext.Alunos.Remove(alunoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

    }
}