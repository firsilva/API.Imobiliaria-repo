using API.Imobiliaria.SharedKernel.Model;

namespace API.Imobiliaria.Aplicacao.Usuario
{
    public interface IUsuarioService
    {
        Task<ResponseModel> AutenticarUsuario(string usuario);
        Task<ResponseModel> SalvarNovoUsuario(string usuario);
        Task<string> GerarHashSenhaUsuario(string senha);
        Task<ResponseModel> BuscarUsuarioPorEmail(string usuario);
        Task<ResponseModel> AtualizarUsuario(string usuario);
        Task<ResponseModel> ExcluirUsuario(string usuario);
    }
}
