using System;
using System.IO;

namespace CollegeCoursePrerequisites
{
    public class InputFile
    {
        public InputFile(string path)
        {
            Path = path;
        }

        public string Path { get; }
        public string[] InputArray { get; private set;}

        public void readFile()
        {
            try 
            {
                InputArray = File.ReadAllLines(Path);
            }
            catch(Exception e) when (e is FileNotFoundException || e is ArgumentException)
            {
                if (e is FileNotFoundException) 
                {
                    Console.WriteLine("The file was not found");
                    throw new FileNotFoundException(@"The file was not found",e);
                }
                else if (e is ArgumentException) 
                {
                    Console.WriteLine("The path is invalid");
                    throw new ArgumentException(@"The file was not found",e);
                }
            }
        }

        public void printFile() 
        {
            foreach (string line in InputArray)
            {
                Console.WriteLine(line);
            }
        }
        
    }
}
