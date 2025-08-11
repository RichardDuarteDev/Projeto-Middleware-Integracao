using System;

namespace Cadastro_de_Funcionários.Models
{
    public class ClientesAPIModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        public string SituacaoClienteId { get; set; }







    }
}
