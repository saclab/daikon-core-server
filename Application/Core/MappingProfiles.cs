using Application.BackgroundTasks.GeneSync.DTO;
using Application.Genes.DTOs;
using Application.Projects.DTOs;
using Application.Screens.DTOs;
using Application.Votes.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<Gene, Gene>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneCSV, Gene>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneCSV, GenePublicData>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneVulnerabilityCSV, GeneVulnerability>().ForMember(x => x.Id, opt => opt.Ignore());


      CreateMap<GeneVulnerability, GeneVulnerability>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneEssentiality, GeneEssentiality>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneHypomorph, GeneHypomorph>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneProteinProduction, GeneProteinProduction>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneProteinActivityAssay, GeneProteinActivityAssay>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneCRISPRiStrain, GeneCRISPRiStrain>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneResistanceMutation, GeneResistanceMutation>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GeneUnpublishedStructures, GeneUnpublishedStructures>().ForMember(x => x.Id, opt => opt.Ignore());
      CreateMap<GenePublicData, GenePublicData>().ForMember(x => x.Id, opt => opt.Ignore());


      CreateMap<Project, Project>();

      CreateMap<Screen, ScreenDTO>();
      CreateMap<ScreenSequence, ScreenSequenceDTO>();
      CreateMap<Hit, HitDTO>();
      CreateMap<Vote, VoteDTO>();

      CreateMap<Compound, Compound>();

    }

  }
}