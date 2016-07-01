using System;

namespace CollegeCoursePrerequisites
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //InputFile inputFile = new InputFile("/Users/Jen/Documents/Code/Packsize/CollegeCoursePrerequisites/TestFiles/circular-input-file.txt");
            InputFile inputFile = new InputFile(args[0]);
            inputFile.ReadFile();

            CollegeCatalogue catalogue = new CollegeCatalogue();
            if ( catalogue.LoadCourseCatalogue(inputFile.InputArray) )
            {
                catalogue.PrintCatalogue();
            }
            else {
                Console.WriteLine("Unable to create a Course Catalogue: There was a circular reference in the input file.");
            }
        }
    }
}
