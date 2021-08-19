using Application.BackgroundTasks.GeneSync.DTO;
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
      CreateMap<GeneCSV, Gene>();
      CreateMap<GeneCSV, GenePublicData>();
      CreateMap<Gene, GeneListDTO>();
      CreateMap<Gene, GeneViewDTO>();
      

      CreateMap<GenePublicData, GenePublicData>();
      CreateMap<GenePublicData, GenePublicDataDTO>();

      CreateMap<GeneNonPublicData, GeneNonPublicData>();
      CreateMap<GeneNonPublicData, GeneNonPublicDataDTO>();

    }

  }
}