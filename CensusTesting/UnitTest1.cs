using System;
using System.Collections.Generic;
using IndianStateCensusAnalyzerProject;
using IndianStateCensusAnalyzerProject.POCO;
using static IndianStateCensusAnalyzerProject.CensusAnalyzer;
using NUnit.Framework;
namespace CensusTesting
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\WwrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"D:\BridgeLabz\Indian-State-Census-Analyzer-Problem\IndianStateCensusAnalyzerProject\CSVFiles\WwrongIndiaStateCode.csv";
        static string wrongIndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqm";
        static string wrongIndianStateCodeHeaders = "Cuntry,SrNo,State Name,TIN,StateCode";

        IndianStateCensusAnalyzerProject.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyzer.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
          
         }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        [Test]
        public void GivenCorrectIndianCensusDataFileButWrongDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenCorrectIndianCensusDataFileButWrongCsvHeader_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, wrongIndianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}