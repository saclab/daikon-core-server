using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

/* CAUTION
*  
*  Data in the seed class are public and are commited to source control.
*  Do **NOT** put any sensitive information in this file.
*  The intention of the class is strictly for testing purposes only and will be removed on production builds
*/

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {

      /* Add Roles */
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

      /* Add test users */
      if (!userManager.Users.Any())
      {
        var users = new List<AppUser>
        {
          new AppUser
          {
            DisplayName = "Steve Berthel",
            UserName = "steve",
            Email = "steve.berthel@panoramaglobal.org"
          },
          new AppUser
          {
            DisplayName = "Betsy Russel",
            UserName = "betsy",
            Email = "betsy.russell@gatesmri.org"
          },
          new AppUser
          {
            DisplayName = "James Sacchettini",
            UserName = "jim",
            Email = "sacchett@tamu.edu"
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
        
        /* Add Test users as admins */
        string[] _admins = { "sid@tamu.edu", "panda@tamu.edu", "steve.berthel@panoramaglobal.org", "betsy.russell@gatesmri.org", "sacchett@tamu.edu" };

        foreach (var _admin in _admins)
        {
          System.Console.WriteLine(_admin);
          var _user = await userManager.FindByEmailAsync(_admin);
          var _roles = await userManager.GetRolesAsync(_user);
          if (!_roles.Any())
          {
            await userManager.AddToRoleAsync(_user, "admin");
          }
        }
      }



      /* Add test/sample genes */
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
                  },

                  GeneNonPublicData = new GeneNonPublicData
                  {
                    /* Section 1: Essentiality  */
                    Classification = "Classification Data",
                    EssentialityCondition = "Essentiality Condition Data",
                    Strain = "Strain Data",
                    Method = "Method Data",
                    Reference = "Reference Data",
                    Notes = "Notes Data",
                
                    /* Section 2: Protein Production List */
                    ProteinProduction = "Protein Production Data",
              
                    /* Section 3: Protein Activity Assay List */
                    ProteinActivityAssay = "Protein Activity Assay Data",

                    /* Section 4: Hypomorph, Knockdown strain, Phenotype List */
                    KnockdownStrain = "Knockdown Strain Data",
                    Phenotype = "Phenotype Data",

                    /* Section 5: CRISPRi Strain List */
                    CRISPRiStrain = "CRISPRiStrain Data",

                    /* Section 6: Resistance Mutations  */
                    Mutation = "Mutation Data",
                    Isolate = "Isolate Data",
                    ParentStrain = "ParentStrain Data",
                    CompoundSmiles = "CompoundSmiles Data",
                    ShiftInMIC = "ShiftInMIC Data",
                    Lab = "Lab Data",

                    /* Section 7: Vulnerability  */
                    Rank = "Rank Data",
                    U_Vi = "U_Vi Data",
                    I_Vi = "I_Vi Data",
                    Vi_Ratio = "Vi_Ratio Data",
                    VulnerabilityCondition = "Vulnerability Condition Data",
                    Operon = "Operon Data",
                    Confounded = "Confounded Data",
                    Shell_2015Operon = "Shell_2015Operon Data",

                    /* Section 8: Unpublished Structural Information  */
                    Organization = "Organization Data",
                    UnpublishedMethod = "UnpublishedMethod Data",
                    Resolution = "Resolution Data",
                    UnpublishedCondition = "UnpublishedCondition Data",
                    Ligand = "Ligand Data"
                    }

                },
                new Gene
                {
                  AccessionNumber = "Rv2794c",
                  GeneName = "pptT",
                  Function = "Biosynthesis of fatty acids and lipids. Transfers the 4'-phosphopantetheine moiety from coenzyme A to a SER of acyl-carrier protein. Catalyzes the formation of holo-ACP, which mediates the transfer of acyl fatty-acid intermediates during the biosynthesis of fatty acids and lipids [catalytic activity: CoA + APO-[acyl-carrier protein] = adenosine 3',5'-bisphosphate + holo-[acyl-carrier protein] ].",
                  Product = "Phosphopantetheinyl transferase PptT (CoA:APO-[ACP]pantetheinephosphotransferase) (CoA:APO-[acyl-carrier protein]pantetheinephosphotransferase)",
                  FunctionalCategory = "lipid metabolism",
                  GenePublicData = new GenePublicData
                  {
                    /* Section 1: General annotation */
                    Type = "CDS",
                    Proteomics = "Identified in the cell membrane fraction of M. tuberculosis H37Rv using 2DLC/MS (See Mawuenyega et al., 2005).",
                    Mutant = "Essential gene for in vitro growth of H37Rv in a MtbYM rich medium, by Himar1 transposon mutagenesis (see Minato et al. 2019). Essential gene for in vitro growth of H37Rv, by analysis of saturated Himar1 transposon libraries (see DeJesus et al. 2017). Essential gene in M. smegmatis and M. bovis BCG; C. glutamicum mutant does not produce corynomycolates, has altered colony morphology and slower growth rate compared to wild-type (See Chalut et al., 2006). Essential gene for in vitro growth of H37Rv, by Himar1 transposon mutagenesis (See Griffin et al., 2011).",
                    Comments = "Rv2794c, (MTV002.59c), len: 227 aa. PptT, phosphopantetheinyl transferase, equivalent to Q9Z5I5|ML1547|MLCB596.23 putative iron-chelating complex subunit from Mycobacterium leprae (227 aa), FASTA scores: opt: 1248, E(): 9.1e-77, (79.75% identity in 227 aa overlap). Also highly similar to various proteins e.g. Q9F0Q6|PPTA phosphopantetheinyl transferase from Streptomyces verticillus (246 aa), FASTA scores: opt: 692, E(): 2.8e-39, (46.65% identity in 225 aa overlap); O88029|SC5A7.23 hypothetical 24.5 KDA protein from Streptomyces coelicolor (226 aa), FASTA scores: opt: 679, E(): 2e-38, (46.9% identity in 226 aa overlap); O24813 DNA for L-proline 3-hydroxylase from Streptomyces sp. (208 aa), FASTA scores: opt: 631, E(): 3.2e-35, (48.1% identity in 208 aa overlap); etc.",

                    /* Section 2: Coordinates */
                    Start = "3103257",
                    End = "3103940",
                    Orientation = "-",

                    /* Section 3: Gene summary information */
                    GeneLength = "684 bp",
                    Location = "3103257 bp",

                    /* Section 4: Protein summary information */
                    MolecularMass = "24708.5 Da",
                    IsoelectricPoint = "6.6705",
                    ProteinLength = "227 amino acids",

                    /* Section 5: Structural information */
                    PFAM = "P66028",

                    /* Section 6: Orthologues */
                    M_Leprae = "ML1547",
                    M_Marinum = "MMAR_1916",
                    M_Smegmatis = "MSMEG_2648",

                  }
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

