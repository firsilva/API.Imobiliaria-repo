using API.Imobiliaria.Aplicacao.Dto;
using API.Imobiliaria.Dominio.Entidades;
using AutoMapper;

namespace API.Imobiliaria.Aplicacao.ClienteApplication.Mappings
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoDto>()
                .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.CEP));

            CreateMap<EnderecoDto, Endereco>()
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Rua))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))                
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Excluido, opt => opt.Ignore())
                .ForMember(dest => dest.DataRegistro, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacaoRegistro, opt => opt.Ignore())
                .ForMember(dest => dest.DataExclusao, opt => opt.Ignore());
        }
    }
}
