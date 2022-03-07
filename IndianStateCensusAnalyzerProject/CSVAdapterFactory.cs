using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusAnalyzerProject;
using IndianStateCensusAnalyzerProject.POCO;

namespace IndianStateCensusAnalyzerProject
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyzer.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyzer.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyzerException("No Such Country", CensusAnalyzerException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
