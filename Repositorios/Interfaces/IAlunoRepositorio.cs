using Projeto_back.Model;


namespace Repositorio.Interfaces {
    public interface IAlunoRepositorio{
        Task <List<Aluno>> ConsultarTodosAlunos();
        Task <Aluno> ConsultarAluno(int IdAluno);
        Task <Aluno> Adicionar(Aluno aluno);
        Task <Aluno> Atualizar(Aluno aluno, int IdAluno);
        Task <bool> Apagar(int IdAluno);

 }
}
