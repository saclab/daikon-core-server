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
      CreateMap<Gene, Gene>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneCSV, Gene>().ForMember(x => x.Id, opt => opt.Ignore()); ;
      CreateMap<GeneCSV, GenePublicData>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneVulnerabilityCSV, GeneVulnerability>().ForMember(x => x.Id, opt => opt.Ignore());


      CreateMap<GeneVulnerability, GeneVulnerability>().ForMember(x => x.Id, opt => opt.Ignore());



      CreateMap<GenePublicData, GenePublicData>().ForMember(x => x.Id, opt => opt.Ignore());


      CreateMap<GeneNonPublicData, GeneNonPublicData>().ForMember(x => x.Id, opt => opt.Ignore());


    }

  }
}