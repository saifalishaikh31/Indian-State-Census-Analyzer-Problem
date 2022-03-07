using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusAnalyzerProject;
using IndianStateCensusAnalyzerProject.POCO;


namespace IndianStateCensusAnalyzerProject
{
    public class CensusAnalyzer
    {
        public static int a = 10;
        public enum Country
        {
            INDIA, US, BRAZIL
        }


        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
