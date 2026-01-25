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
            // Mapear do domínio para DTO
            CreateMap<Cliente, ClienteReadDto>();
            CreateMap<Endereco, EnderecoDto>();

            // Mapear do DTO para domínio
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<EnderecoDto, Endereco>();
        }
    }
}