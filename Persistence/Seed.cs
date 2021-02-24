using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
//using Microsoft.AspNetCore.Identity;

namespace Persistence
{
  public class Seed
  {
    //public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    public static async Task SeedData(DataContext context)
    {
    //   if(!userManager.Users.Any())
    //   {
    //     var users = new List<AppUser>
    //     {
    //       new AppUser
    //       {
    //         DisplayName = "Bob",
    //         UserName = "bob",
    //         Email = "bob@test.com"
    //       },
    //       new AppUser
    //       {
    //         DisplayName = "Tom",
    //         UserName = "tom",
    //         Email = "tom@test.com"
    //       },
    //       new AppUser
    //       {
    //         DisplayName = "Jane",
    //         UserName = "jane",
    //         Email = "jane@test.com"
    //       },

    //     };

    //     foreach (var user in users)
    //     {
    //       await userManager.CreateAsync(user, "Pa$$w0rd");
    //     }


    //   }
      if (!context.Genomes.Any())
      {
        var genomes = new List<Genome>
        {
          new Genome 
          {
            AccessionNumber = "Rv1297",
            GeneName = "rho",
            Function = "Facilitates transcription termination by a mechanism that involves rho binding to the nascent RNA, activation of rho'S RNA-dependent ATPase activity, and release of the mRNA from the DNA template",
            Product = "Probable transcription termination factor Rho homolog",
            FunctionalCategory = "information pathways",
          },
          new Genome 
          {
            AccessionNumber = "Rv2794c",
            GeneName = "pptT",
            Function = "Biosynthesis of fatty acids and lipids. Transfers the 4'-phosphopantetheine moiety from coenzyme A to a SER of acyl-carrier protein. Catalyzes the formation of holo-ACP, which mediates the transfer of acyl fatty-acid intermediates during the biosynthesis of fatty acids and lipids [catalytic activity: CoA + APO-[acyl-carrier protein] = adenosine 3',5'-bisphosphate + holo-[acyl-carrier protein] ].",
            Product = "Phosphopantetheinyl transferase PptT (CoA:APO-[ACP]pantetheinephosphotransferase) (CoA:APO-[acyl-carrier protein]pantetheinephosphotransferase)",
            FunctionalCategory = "lipid metabolism",
          },
          new Genome 
          {
            AccessionNumber = "Rv1240",
            GeneName = "mdh",
            Function = "Involved in the conversion of malate to oxaloacetate [catalytic activity: (S)-malate + NAD+ = oxaloacetate + NADH].",
            Product = "Probable malate dehydrogenase Mdh",
            FunctionalCategory = "intermediary metabolism and respiration",
          },
          new Genome 
          {
            AccessionNumber = "Rv3457c",
            GeneName = "rpoA",
            Function = "DNA-dependent RNA polymerase catalyzes the transcription of DNA into RNA using the four ribonucleoside triphosphates as substrates. The amino-terminal portion is involved in the assembly of core RNAP, whereas the C-terminal is involved in interaction with transcriptional regulators [catalytic activity: N nucleoside triphosphate = N pyrophosphate + RNA(N)].",
            Product = "Probable DNA-directed RNA polymerase (alpha chain) RpoA (transcriptase alpha chain) (RNA polymerase alpha subunit) (DNA-directed RNA nucleotidyltransferase)",
            FunctionalCategory = "information pathways",
          },
          new Genome 
          {
            AccessionNumber = "Rv2202c",
            GeneName = "adoK",
            Function = "Adenosine phosphorylation.",
            Product = "Adenosine kinase",
            FunctionalCategory = "intermediary metabolism and respiration",
          },
          new Genome 
          {
            AccessionNumber = "Rv3279c",
            GeneName = "birA",
            Function = "BIRA acts both as a biotin-operon repressor and as the enzyme that synthesizes the corepressor, acetyl-CoA:carbon-dioxide ligase. This protein also activates biotin to form biotinyl-5'-adenylate and transfers the biotin moiety to biotin-accepting proteins [catalytic activity: ATP + biotin + APO-[acetyl-CoA:carbon-dioxide ligase (ADP forming)] = AMP + pyrophosphate + [acetyl-CoA:carbon-dioxide ligase (ADP forming)]].",
            Product = "Possible bifunctional protein BirA: biotin operon repressor + biotin--[acetyl-CoA-carboxylase] synthetase (biotin--protein ligase)",
            FunctionalCategory = "intermediary metabolism and respiration",
          },
          new Genome 
          {
            AccessionNumber = "Rv0667",
            GeneName = "rpoB",
            Function = "Catalyzes the transcription of DNA into RNA using the four ribonucleoside triphosphates as substrates [catalytic activity: N nucleoside triphosphate = N diphosphate + new Genome {RNA}(N)].",
            Product = "DNA-directed RNA polymerase (beta chain) RpoB (transcriptase beta chain) (RNA polymerase beta subunit)",
            FunctionalCategory = "information pathways",
          },
          new Genome 
          {
            AccessionNumber = "Rv0668",
            GeneName = "rpoC",
            Function = "Catalyzes the transcription of DNA into RNA using the four ribonucleoside triphosphates as substrates [catalytic activity: N nucleoside triphosphate = N diphosphate + new Genome {RNA}(N)]..",
            Product = "DNA-directed RNA polymerase (beta' chain) RpoC (transcriptase beta' chain) (RNA polymerase beta' subunit).",
            FunctionalCategory = "information pathways",
          },
          new Genome 
          {
            AccessionNumber = "Rv1390",
            GeneName = "rpoZ",
            Function = "Promotes RNA polymerase assembly. Latches the N-and C-terminal regions of the beta' subunit thereby faciltating its interaction with the beta and alpha subunits [catalytic activity: N nucleoside triphosphate = N diphosphate + new Genome {RNA}N].",
            Product = "Probable DNA-directed RNA polymerase (omega chain) RpoZ (transcriptase omega chain) (RNA polymerase omega subunit)",
            FunctionalCategory = "information pathways",
          },
          new Genome 
          {
            AccessionNumber = "Rv2523c",
            GeneName = "acpS",
            Function = "Biosynthesis of fatty acids and lipids. Transfers the 4'-phosphopantetheine moiety from coenzyme A to a SER of acyl-carrier protein. Catalyzes the formation of holo-ACP, which mediates the transfer of acyl fatty-acid intermediates during the biosynthesis of fatty acids and lipids [catalytic activity: CoA + APO-[acyl-carrier protein] = adenosine 3',5'-bisphosphate + holo-[acyl-carrier protein] ].",
            Product = "holo-[acyl-carrier protein] synthase AcpS (holo-ACP synthase) (CoA:APO-[ACP]pantetheinephosphotransferase) (CoA:APO-[acyl-carrier protein]pantetheinephosphotransferase)",
            FunctionalCategory = "lipid metabolism",
          }
        };

        await context.Genomes.AddRangeAsync(genomes);
        await context.SaveChangesAsync();
      }
    }
  }
}

