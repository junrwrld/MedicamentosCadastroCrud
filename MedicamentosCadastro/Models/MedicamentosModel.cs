using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MedicamentosCadastro.Models
{
    public class MedicamentosModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do Medicamento")]
        public string Medicamento { get; set; }

        [Required(ErrorMessage = "Digite o nome da Medida")]
        public string Medida { get; set; }

        [Required(ErrorMessage = "Digite a quantidade")]
        public int Quantidade { get; set; }

        public DateTime DataRecebimento { get; set; } = DateTime.Now;

    }
}
