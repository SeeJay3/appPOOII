using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        [Display(Name = "Município")]
        public string Municipio { get; set; }
        [Display(Name ="UF")]
        public string Uf { get; set; }
        [Display(Name ="CEP")]
        public string Cep { get; set; }
    }
}
