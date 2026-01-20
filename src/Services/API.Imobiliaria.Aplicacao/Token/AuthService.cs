using API.Imobiliaria.Aplicacao.Dto;
using API.Imobiliaria.Data.Context;
using System.Security.Claims;
using System.Text;

namespace API.Imobiliaria.Aplicacao.Token
{
    public class AuthService //: IAuthService
    {
    //    private readonly ImobiliariaContext _context;
    //    private readonly IConfiguration _configuration;

    //    public AuthService(ImobiliariaContext context, IConfiguration configuration)
    //    {
    //        _context = context;
    //        _configuration = configuration;
    //    }

    //    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginDto)
    //    {
    //        var usuario = await _context.Usuarios
    //            .Include(u => u.Role)
    //            .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

    //        if (usuario == null)
    //            throw new Exception("Usuário não encontrado");

    //        var hasher = new PasswordHasher<Usuario>();
    //        var result = hasher.VerifyHashedPassword(usuario, usuario.SenhaHash, loginDto.Senha);

    //        if (result == PasswordVerificationResult.Failed)
    //            throw new Exception("Senha inválida");

    //        return GerarToken(usuario);
    //    }

    //    private LoginResponseDto GerarToken(Usuario usuario)
    //    {
    //        var jwtKey = _configuration["Jwt:Key"];
    //        var jwtIssuer = _configuration["Jwt:Issuer"];
    //        var jwtAudience = _configuration["Jwt:Audience"];
    //        var jwtExpireMinutes = Convert.ToInt32(_configuration["Jwt:ExpireMinutes"]);

    //        var claims = new[]
    //        {
    //        new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
    //        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
    //        new Claim(ClaimTypes.Role, usuario.Role.Nome),
    //        new Claim("nome", usuario.Nome)
    //    };

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
    //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(
    //            issuer: jwtIssuer,
    //            audience: jwtAudience,
    //            claims: claims,
    //            expires: DateTime.UtcNow.AddMinutes(jwtExpireMinutes),
    //            signingCredentials: creds
    //        );

    //        return new LoginResponseDto
    //        {
    //            Token = new JwtSecurityTokenHandler().WriteToken(token),
    //            ExpiraEm = token.ValidTo
    //        };
    //    }
    }
}
