using Microsoft.EntityFrameworkCore;
using Projeto_back.Model;

namespace Projeto_back.Data{
    public class AlunoContext : DbContext{
        public AlunoContext(DbContextOptions<AlunoContext>options) 
            : base(options){

        }

        public DbSet<Aluno> Alunos{get; set;}
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}