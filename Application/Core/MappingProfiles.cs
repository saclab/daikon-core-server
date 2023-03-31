using System.Linq;
using Application.BackgroundTasks.GeneSync.DTO;
using Application.Genes.DTOs;
using Application.Projects.DTOs;
using Application.Screens.DTOs;
using Application.Votes.DTOs;
using AutoMapper;
using Domain;
using Domain.Core;

namespace Application.Core
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {

      /* !CRITICAL SECURITY CODE: */
      /* Ignore Metadata Properties for auto mapping*/
      /* How? Use reflection to dynamically get the member names of the Metadata class 
      and exclude them from being mapped in the MappingProfiles class. */

      var metadataProperties = typeof(Metadata).GetProperties().Select(p => p.Name);
      ShouldMapProperty = p => !metadataProperties.Contains(p.Name);

      /* Other Maps */

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
      CreateMap<GeneExternalId, GeneExternalId>().ForMember(x => x.Id, opt => opt.Ignore());



      CreateMap<Project, Project>();

      CreateMap<Screen, ScreenDTO>();
      CreateMap<ScreenSequence, ScreenSequenceDTO>();
      CreateMap<Hit, HitDTO>();
      CreateMap<Vote, VoteDTO>();

      CreateMap<ScreenDTO, Screen>();

      CreateMap<Compound, Compound>();

    }

  }
}