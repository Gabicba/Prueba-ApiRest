using AutoMapper;
using ApiEncode2.DTOs;
using ApiEncode2.Models;
namespace ApiEncode2.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<ProductoCreateDTO, Producto>();
            CreateMap<Producto, ProductoDTO>()
                  .ForMember(dest => dest.CategoriaNombre, opt => opt.MapFrom(src => src.Categoria.Nombre));


            CreateMap<ProductoDTO, Producto>();

            

        }
    }
  
}
