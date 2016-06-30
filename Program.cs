using System;

namespace CollegeCoursePrerequisites
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InputFile inputFile = new InputFile("/Users/Jen/Documents/Code/Packsize/CollegeCoursePrerequisites/TestFiles/input.txt");
            inputFile.readFile();

        }
    }
}
