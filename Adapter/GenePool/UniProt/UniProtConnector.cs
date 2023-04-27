using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.GenePool.UniProt.Configuration;
using CsvHelper.Configuration;
using Domain;
using Microsoft.Extensions.Logging;

namespace Adapter.GenePool.UniProt
{
  public class UniProtConnector : IGenePoolAdapter
  {

    private static string _ADAPTER_NAME = "UniProtConnector";
    private static string _ADAPTER_TYPE = "GenePoolAdapter";
    private static string _ADAPTER_VERSION = "1.0.0";
    private readonly ILogger<UniProtConnector> _logger;

    private UniProtAdapterGeneSyncConfiguration Conf { get; set; }
    private CsvConfiguration _uniProtCSVConfig;


    public UniProtConnector()
    {
      _logger = new LoggerFactory().CreateLogger<UniProtConnector>();


      _uniProtCSVConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        Delimiter = Microsoft.VisualBasic.Constants.vbTab,
        HasHeaderRecord = true,
        // TrimOptions = TrimOptions.Trim,
        // Mode = CsvMode.RFC4180,
        MissingFieldFound = null,
        HeaderValidated = null,
        Encoding = Encoding.UTF8,
      };
    }


    public string GetAdapterName()
    {
      return _ADAPTER_NAME;
    }

    public string GetAdapterType()
    {
      return _ADAPTER_TYPE;
    }

    public string GetAdapterVersion()
    {
      return _ADAPTER_VERSION;
    }

    public void Init(IGeneSyncAdapterConfiguration configuration)
    {
      if (configuration == null)
      {
        throw new ArgumentNullException(nameof(configuration));
      }

      if (configuration.GetType() != typeof(UniProtAdapterGeneSyncConfiguration))
      {
        throw new ArgumentException("Configuration is not of type UniProtAdapterGeneSyncConfiguration");
      }

      Conf = (UniProtAdapterGeneSyncConfiguration)configuration;
    }

    public Task<List<Gene>> FetchGenes()
    {
      List<Gene> FormattedGenes = new List<Gene>();

      //return FormattedGenes;
      return Task.FromResult(FormattedGenes);
    }


  }
}