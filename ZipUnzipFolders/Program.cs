using System;
using System.IO;
using System.IO.Compression;

namespace ZipUnzipFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFolderPath = "C:\\Users\\rajdeep\\Desktop\\";
            string outputFolderPath = "C:\\Users\\rajdeep\\Desktop\\";

            Console.WriteLine("1. Zip a folder");
            Console.WriteLine("2. Unzip a folder");
            Console.WriteLine("Please select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    {
                        ZipFolder(inputFolderPath, outputFolderPath);
                        break;
                    }
                case 2:
                    {
                        UnZipFolder(inputFolderPath, outputFolderPath);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Something went wrong!");
                        break;
                    }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Method for unzipping a folder - RS
        /// </summary>
        /// <param name="inputFolderPath"></param>
        /// <param name="outputFolderPath"></param>
        public static void UnZipFolder(string inputFolderPath, string outputFolderPath)
        {
            Console.WriteLine();

            // Input folder name
            Console.WriteLine("Enter the zipped folder's name (From Desktop): ");
            string folderName = Console.ReadLine() + ".zip";

            Console.WriteLine();

            // Create storage paths
            inputFolderPath += folderName;
            outputFolderPath += folderName.Substring(0, folderName.IndexOf(".")) + "_UnZipped";

            if (!File.Exists(inputFolderPath))
            {
                Console.WriteLine("No such folder exists in the specified path!");
            }
            else
            {
                ZipFile.ExtractToDirectory(inputFolderPath, outputFolderPath);
                Console.WriteLine("Extraction completed successfully!");
            }
        }

        /// <summary>
        /// Method for zipping a folder
        /// </summary>
        /// <param name="inputFolderPath"></param>
        /// <param name="outputFolderPath"></param>
        public static void ZipFolder(string inputFolderPath, string outputFolderPath)
        {
            Console.WriteLine();

            // Input file name
            Console.WriteLine("Enter the folder's name (From Desktop): ");
            string folderName = Console.ReadLine();

            Console.WriteLine();

            // Create storage paths
            inputFolderPath += folderName;
            outputFolderPath += folderName + "_Zipped.zip";

            if(!Directory.Exists(inputFolderPath))
            {
                Console.WriteLine("No such folder exists in the specified path!");
            }
            else
            {
                ZipFile.CreateFromDirectory(inputFolderPath, outputFolderPath);
                Console.WriteLine("Compression completed successfully!");
            }
        }
    }
}
