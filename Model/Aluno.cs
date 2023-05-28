using System.ComponentModel.DataAnnotations;
namespace Projeto_back.Model{
 public class Aluno{

   [Key]
    public int IdAluno {get; set;}
    public string? Nome {get; set;}
    public float CPF {get; set;}
    public float NumTelefone {get; set;}
 }   
}
