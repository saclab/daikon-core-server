using Application.Genes.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
        CreateMap<Gene, Gene>();
        CreateMap<Gene, GeneListDTO>();
        CreateMap<Gene, GeneViewDTO>();
        CreateMap<GenePublicData, GenePublicDataDTO>();
        CreateMap<GeneNonPublicData, GeneNonPublicDataDTO>();
    }

  }
}