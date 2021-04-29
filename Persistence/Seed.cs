using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
      if (!userManager.Users.Any())
      {
        var users = new List<AppUser>
        {
          new AppUser
          {
            DisplayName = "Bob",
            UserName = "bob",
            Email = "bob@test.com"
          },
          new AppUser
          {
            DisplayName = "Tom",
            UserName = "tom",
            Email = "tom@test.com"
          },
          new AppUser
          {
            DisplayName = "Jane",
            UserName = "jane",
            Email = "jane@test.com"
          },
          new AppUser
          {
            DisplayName = "Sid",
            UserName = "sid",
            Email = "sid@tamu.edu"
          },
          new AppUser
          {
            DisplayName = "Siddhant Rath",
            UserName = "sidx",
            Email = "rath.siddhant@outlook.com"
          },
          new AppUser
          {
            DisplayName = "Saswati Panda",
            UserName = "panda",
            Email = "panda@tamu.edu"
          },

        };

        foreach (var user in users)
        {
          await userManager.CreateAsync(user, "P@ssw0rd");
        }




      }
      if (!roleManager.Roles.Any())
      {
        var roles = new List<AppRole>
        {
          new AppRole
          {
            Name = "root"
          },
          new AppRole
          {
            Name = "admin"
          },
          new AppRole
          {
           Name = "user"
          }
        };

        foreach (var role in roles)
        {
          await roleManager.CreateAsync(role);
        }
      }


      // Add sid@tamu.edu as admin
      var userSid = await userManager.FindByEmailAsync("sid@tamu.edu");
      var rolesOfSid = await userManager.GetRolesAsync(userSid);

      if (!rolesOfSid.Any())
      {
        await userManager.AddToRoleAsync(userSid, "admin");
      }

      // Add panda@tamu.edu as admin
      var userPanda = await userManager.FindByEmailAsync("panda@tamu.edu");
      var rolesOfPanda = await userManager.GetRolesAsync(userPanda);

      if (!rolesOfPanda.Any())
      {
        await userManager.AddToRoleAsync(userPanda, "admin");
      }
 


 
      if (!context.Genes.Any())
      {
        var genes = new List<Gene>
        {
          new Gene
          {
            AccessionNumber = "Rv1297",
            GeneName = "rho",
            Function = "Facilitates transcription termination by a mechanism that involves rho binding to the nascent RNA, activation of rho'S RNA-dependent ATPase activity, and release of the mRNA from the DNA template",
            Product = "Probable transcription termination factor Rho homolog",
            FunctionalCategory = "information pathways",
            GenePublicData = new GenePublicData
            {
              /* Section 1: General annotation */
              Type = "CDS",
              Proteomics = "Identified by proteomics (see Rosenkrands et al., 2000). Identified in the membrane fraction of M. tuberculosis H37Rv using 1D-SDS-PAGE and uLC-MS/MS (See Gu et al., 2003). Identified in the cell wall and cell membrane fractions of M. tuberculosis H37Rv using 2DLC/MS (See Mawuenyega et al., 2005). Identified by mass spectrometry in Triton X-114 extracts of M. tuberculosis H37Rv (See Malen et al., 2010). Identified by mass spectrometry in the membrane protein fraction and whole cell lysates of M. tuberculosis H37Rv but not the culture filtrate (See de Souza et al., 2011).",
              Mutant = "Essential gene for in vitro growth of H37Rv in a MtbYM rich medium, by Himar1 transposon mutagenesis (see Minato et al. 2019). Essential gene for in vitro growth of H37Rv, by analysis of saturated Himar1 transposon libraries (see DeJesus et al. 2017). Essential gene by Himar1 transposon mutagenesis in H37Rv strain (see Sassetti et al., 2003). Essential gene for in vitro growth of H37Rv, by Himar1 transposon mutagenesis (See Griffin et al., 2011).",
              Comments = "Rv1297, (MTCY373.17), len: 602 aa. Probable rho, transcription termination factor homolog, highly similar to many e.g. RHO_MYCLE|P45835 Mycobacterium leprae (610 aa), FASTA scores: (81.5% identity in 612 aa overlap). Contains 1 RNA recognition motif (RRM). Nucleotide position 1453608 in the genome sequence has been corrected, T:C resulting in G135G.",

              /* Section 2: Coordinates */
              Start = "1453204",
              End = "1455012",
              Orientation = "+",

              /* Section 3: Gene summary information */
              GeneLength = "1809 bp",
              Location = "1453204 bp",

              /* Section 4: Protein summary information */
              MolecularMass = "65101.4 Da",
              IsoelectricPoint = "5.4216",
              ProteinLength = "602 amino acids",

              /* Section 5: Structural information */
              PFAM = "P66028",

              /* Section 6: Orthologues */
              M_Leprae = "ML1132",
              M_Marinum = "MMAR_4100",
              M_Smegmatis = "MSMEG_4954",

              /* Section 7: Protein Databank */
              Cryo = "",
              XRay = "",
              Model = "",
              Ligand = ""
            }
          },
          new Gene
          {
            AccessionNumber = "Rv2794c",
            GeneName = "pptT",
            Function = "Biosynthesis of fatty acids and lipids. Transfers the 4'-phosphopantetheine moiety from coenzyme A to a SER of acyl-carrier protein. Catalyzes the formation of holo-ACP, which mediates the transfer of acyl fatty-acid intermediates during the biosynthesis of fatty acids and lipids [catalytic activity: CoA + APO-[acyl-carrier protein] = adenosine 3',5'-bisphosphate + holo-[acyl-carrier protein] ].",
            Product = "Phosphopantetheinyl transferase PptT (CoA:APO-[ACP]pantetheinephosphotransferase) (CoA:APO-[acyl-carrier protein]pantetheinephosphotransferase)",
            FunctionalCategory = "lipid metabolism",
          },
          new Gene
          {
            AccessionNumber = "Rv1240",
            GeneName = "mdh",
            Function = "Involved in the conversion of malate to oxaloacetate [catalytic activity: (S)-malate + NAD+ = oxaloacetate + NADH].",
            Product = "Probable malate dehydrogenase Mdh",
            FunctionalCategory = "intermediary metabolism and respiration",
          },
          new Gene
          {
            AccessionNumber = "Rv3457c",
            GeneName = "rpoA",
            Function = "DNA-dependent RNA polymerase catalyzes the transcription of DNA into RNA using the four ribonucleoside triphosphates as substrates. The amino-terminal portion is involved in the assembly of core RNAP, whereas the C-terminal is involved in interaction with transcriptional regulators [catalytic activity: N nucleoside triphosphate = N pyrophosphate + RNA(N)].",
            Product = "Probable DNA-directed RNA polymerase (alpha chain) RpoA (transcriptase alpha chain) (RNA polymerase alpha subunit) (DNA-directed RNA nucleotidyltransferase)",
            FunctionalCategory = "information pathways",
          },
          new Gene
          {
            AccessionNumber = "Rv2202c",
            GeneName = "adoK",
            Function = "Adenosine phosphorylation.",
            Product = "Adenosine kinase",
            FunctionalCategory = "intermediary metabolism and respiration",
          },
          new Gene
          {
            AccessionNumber = "Rv3279c",
            GeneName = "birA",
            Function = "BIRA acts both as a biotin-operon repressor and as the enzyme that synthesizes the corepressor, acetyl-CoA:carbon-dioxide ligase. This protein also activates biotin to form biotinyl-5'-adenylate and transfers the biotin moiety to biotin-accepting proteins [catalytic activity: ATP + biotin + APO-[acetyl-CoA:carbon-dioxide ligase (ADP forming)] = AMP + pyrophosphate + [acetyl-CoA:carbon-dioxide ligase (ADP forming)]].",
            Product = "Possible bifunctional protein BirA: biotin operon repressor + biotin--[acetyl-CoA-carboxylase] synthetase (biotin--protein ligase)",
            FunctionalCategory = "intermediary metabolism and respiration",
          },
          new Gene
          {
            AccessionNumber = "Rv0667",
            GeneName = "rpoB",
            Function = "Catalyzes the transcription of DNA into RNA using the four ribonucleoside triphosphates as substrates [catalytic activity: N nucleoside triphosphate = N diphosphate + new Genome {RNA}(N)].",
            Product = "DNA-directed RNA polymerase (beta chain) RpoB (transcriptase beta chain) (RNA polymerase beta subunit)",
            FunctionalCategory = "information pathways",
          },
          new Gene
          {
            AccessionNumber = "Rv0668",
            GeneName = "rpoC",
            Function = "Catalyzes the transcription of DNA into RNA using the four ribonucleoside triphosphates as substrates [catalytic activity: N nucleoside triphosphate = N diphosphate + new Genome {RNA}(N)]..",
            Product = "DNA-directed RNA polymerase (beta' chain) RpoC (transcriptase beta' chain) (RNA polymerase beta' subunit).",
            FunctionalCategory = "information pathways",
          },
          new Gene
          {
            AccessionNumber = "Rv1390",
            GeneName = "rpoZ",
            Function = "Promotes RNA polymerase assembly. Latches the N-and C-terminal regions of the beta' subunit thereby faciltating its interaction with the beta and alpha subunits [catalytic activity: N nucleoside triphosphate = N diphosphate + new Genome {RNA}N].",
            Product = "Probable DNA-directed RNA polymerase (omega chain) RpoZ (transcriptase omega chain) (RNA polymerase omega subunit)",
            FunctionalCategory = "information pathways",
          },
          new Gene
          {
            AccessionNumber = "Rv2523c",
            GeneName = "acpS",
            Function = "Biosynthesis of fatty acids and lipids. Transfers the 4'-phosphopantetheine moiety from coenzyme A to a SER of acyl-carrier protein. Catalyzes the formation of holo-ACP, which mediates the transfer of acyl fatty-acid intermediates during the biosynthesis of fatty acids and lipids [catalytic activity: CoA + APO-[acyl-carrier protein] = adenosine 3',5'-bisphosphate + holo-[acyl-carrier protein] ].",
            Product = "holo-[acyl-carrier protein] synthase AcpS (holo-ACP synthase) (CoA:APO-[ACP]pantetheinephosphotransferase) (CoA:APO-[acyl-carrier protein]pantetheinephosphotransferase)",
            FunctionalCategory = "lipid metabolism",
          }
        };

        await context.Genes.AddRangeAsync(genes);
        await context.SaveChangesAsync();
      }
    }
  }
}

