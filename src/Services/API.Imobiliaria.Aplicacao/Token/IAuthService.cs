using API.Imobiliaria.Aplicacao.Dto;

namespace API.Imobiliaria.Aplicacao.Token
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginDto);
    }
}
