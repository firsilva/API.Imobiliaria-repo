using API.Imobiliaria.SharedKernel.Model;

namespace API.Imobiliaria.Aplicacao.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        public Task<ResponseModel> AtualizarUsuario(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> AutenticarUsuario(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> BuscarUsuarioPorEmail(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> ExcluirUsuario(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<string> GerarHashSenhaUsuario(string senha)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> SalvarNovoUsuario(string usuario)
        {
            throw new NotImplementedException();
        }
    }
}
