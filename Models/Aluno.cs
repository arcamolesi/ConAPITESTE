using System.ComponentModel.DataAnnotations;

namespace ConAPITESTE.Models
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string disciplina { get; set; }
        public float nota1 { get; set; }
        public float nota2 { get; set; }
    }
}
