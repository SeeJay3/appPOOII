using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {

        public int AlunoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [DisplayName("e-mail")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        [DisplayName("Município")]
        public string Municipio { get; set; }
        [DisplayName("UF")] 
        public string Uf { get; set; }
        [DisplayName("CEP")]
        public string Cep { get; set; }
    }
}
