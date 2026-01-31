using API.Imobiliaria.Aplicacao.ClienteApplication.Dto;
using API.Imobiliaria.Aplicacao.Dto;
using API.Imobiliaria.Dominio.Entidades;
using AutoMapper;

namespace API.Imobiliaria.Aplicacao.ClienteApplication.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // DTO → Entidade
            CreateMap<Cliente, ClienteReadDto>();

            CreateMap<ClienteCreateDto, Cliente>()
                .ConstructUsing(dto =>
                    new Cliente(
                        dto.Nome,
                        dto.Email,
                        dto.Telefone,
                        dto.Documento,
                        null
                    )
                )
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioId, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Propostas, opt => opt.Ignore())
                .ForMember(dest => dest.Excluido, opt => opt.Ignore())
                .ForMember(dest => dest.DataRegistro, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacaoRegistro, opt => opt.Ignore())
                .ForMember(dest => dest.DataExclusao, opt => opt.Ignore());

        }
    }
}