﻿using Medic.Contexts;
using Medic.Contexts.Contracts;
using Medic.Contexts.Seeders;
using Medic.Entities;
using Medic.Import;
using Medic.Import.Contracts;
using Medic.Infrastructure;
using Medic.Mappers;
using Medic.Mappers.Contracts;
using Medic.XMLImportHelper;
using Medic.XMLImportHelper.Contracts;
using Medic.XMLImportHelper.Enumerations;
using Medic.XMLParser;
using Medic.XMLParser.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using CLPR = Medic.Models.CLPR;
using CP = Medic.Models.CP;

namespace Medic.FileImport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddUserSecrets<Program>();

                IConfigurationRoot configuration = configurationBuilder.Build();

                DbContextOptionsBuilder<MedicContext> builder = new DbContextOptionsBuilder<MedicContext>();
                builder.UseSqlServer(configuration[Constants.ConnectionString]);
                builder.EnableSensitiveDataLogging();

                using MedicContext context = new MedicContext(builder.Options);
                IMedicContextSeeder medicContextSeeder = new MedicContextSeeder(context);
                medicContextSeeder.Seed();

                AMapperConfiguration mapConfiguration = new AMapperConfiguration();
                IMappable mapper = new AMapper(mapConfiguration.CreateConfiguration());

                string cpDirectory, clprDirectory;
                bool doesCpDirectoryExist = true, doesCLPRDirectoryExist = true;

                CP.CPFile test1 = new CP.CPFile();
                CLPR.HospitalPractice test2 = new CLPR.HospitalPractice();

                XmlSerializer test1p = new XmlSerializer(test1.GetType());
                XmlSerializer test2p = new XmlSerializer(test2.GetType());

                test1p.Serialize(new StreamWriter(@"C:\Users\Emo\Desktop\cpfile.xml"), test1);
                test2p.Serialize(new StreamWriter(@"C:\Users\Emo\Desktop\clpr.xml"), test2);
                return;

                while (true)
                {
                    Console.WriteLine("Enter directory for CP files");
                    cpDirectory = Console.ReadLine();
                    Console.WriteLine("Enter directory for CLPR files");
                    clprDirectory = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(cpDirectory))
                    {
                        doesCpDirectoryExist = Directory.Exists(cpDirectory);
                    }

                    if (!string.IsNullOrWhiteSpace(clprDirectory))
                    {
                        doesCLPRDirectoryExist = Directory.Exists(clprDirectory);
                    }

                    
                    if (doesCpDirectoryExist && doesCLPRDirectoryExist)
                    {
                        break;
                    }
                    else
                    {
                        if (!doesCpDirectoryExist)
                        {
                            Console.WriteLine("CP directory does not exist.");
                        }

                        if (!doesCLPRDirectoryExist)
                        {
                            Console.WriteLine("CLPR directory does not exist.");
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(cpDirectory))
                {
                    ReadCpFiles(mapper, builder, cpDirectory);
                }

                if (!string.IsNullOrWhiteSpace(clprDirectory))
                {
                    ReadCLPRFiles(mapper, builder, clprDirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ReadCpFiles(IMappable mapper, DbContextOptionsBuilder<MedicContext> builder, string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.xml");
            CP.CPFile cpFile;
            CPFile cpFileEntity;
            IMedicXmlParser medicXmlParser = new DefaultMedicXmlParser(new GetXmlParameters());

            int counter = 1;

            foreach (string file in files)
            {
                using FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);
                
                cpFile = medicXmlParser.ParseXML<CP.CPFile>(sr);

                cpFileEntity = mapper.Map<CPFile, CP.CPFile>(cpFile);

                using MedicContext medicContext = new MedicContext(builder.Options);
                using IImportMedicFile importMedicFile = new ImportMedicFile(medicContext);

                importMedicFile.ImportCPFile(cpFileEntity);

                Console.WriteLine($"{file} - imported, ({counter++}/{files.Length}).");
                cpFileEntity = null;
                cpFile = null;
            }
        }

        private static void ReadCLPRFiles(IMappable mapper, DbContextOptionsBuilder<MedicContext> builder, string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.xml");
            CLPR.HospitalPractice clprFile;
            HospitalPractice hospitalPracticeEntity;
            IMedicXmlParser medicXmlParser = new DefaultMedicXmlParser(new GetXmlParameters());

            int counter = 1;

            foreach (string file in files)
            {
                using FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);
                
                clprFile = medicXmlParser.ParseXML<CLPR.HospitalPractice>(sr);

                hospitalPracticeEntity = mapper.Map<HospitalPractice, CLPR.HospitalPractice>(clprFile);

                using MedicContext medicContext = new MedicContext(builder.Options);
                using IImportMedicFile importMedicFile = new ImportMedicFile(medicContext);

                importMedicFile.ImportHospitalPractice(hospitalPracticeEntity);

                Console.WriteLine($"{file} - imported, ({counter++}/{files.Length}).");
                hospitalPracticeEntity = null;
                clprFile = null;
            }
        }
    }
}