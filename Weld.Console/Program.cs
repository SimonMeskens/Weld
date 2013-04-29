using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Weld.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("***   Weld 1.0          ***");
            System.Console.WriteLine("***   Martijn Muurman   ***");
                
            if (args.Length < 1 || args.Length > 2)
            {
                System.Console.WriteLine("usage :  Weld assemblyName [outputfoldername]");
                return;
            }

            var folderName = GetOrCreateFolderAndGetName(args);

            var fileName = Path.GetFullPath(args[0]);
            var assembly = Assembly.LoadFrom(fileName);
           
            System.Console.WriteLine("processing {0}",fileName);

            var processor = new TypeScriptProcessor();

            var results = processor.ProcessAssembly(assembly);
            System.Console.WriteLine("found {0} decorated types", results.Count);


            foreach (var result in results)
            {
                var fullFileName = Path.Combine(folderName, result.FileName);
                System.Console.WriteLine("Writing file {0}", fullFileName);
                File.WriteAllText(fullFileName, result.Content);
            }
        }

        private static string GetOrCreateFolderAndGetName(string[] args)
        {
            var folderName = Path.GetFullPath(args[1]);
            if (args.Length == 2)
            {
                if (!Directory.Exists(folderName))
                {
                    System.Console.WriteLine(string.Format("No directory found at {0}. Creating it", args[1]),
                                                "outputfoldername");
                 
                }
                else
                {
                    //clear the folder
                    System.Console.WriteLine(string.Format("Clearing directory found at {0}. ", args[1]),
                                             "outputfoldername");
                    Directory.Delete(folderName, true);
                    Thread.Sleep(50);//wait for the del to kick in
                }
                Directory.CreateDirectory(folderName);
                if (!Directory.Exists(folderName))
                {
                    throw new ArgumentException("WTF");
                }
            }
            else
            {
                folderName = Path.GetFullPath(".");
            }
            return folderName;
        }
    }
}
