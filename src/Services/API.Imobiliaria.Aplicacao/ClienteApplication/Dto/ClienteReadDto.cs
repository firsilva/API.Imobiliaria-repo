using API.Imobiliaria.Aplicacao.Dto;

namespace API.Imobiliaria.Aplicacao.ClienteApplication.Dto
{
    public class ClienteReadDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
