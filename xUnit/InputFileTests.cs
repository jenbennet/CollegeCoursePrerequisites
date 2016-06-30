using System;
using System.IO;
using Xunit;
using CollegeCoursePrerequisites;
public class InputFileShould
{
    [Fact]
    public void RaiseExceptionWhenNullPath()
    {
        //Arrange
        string path = "";
        InputFile inputFile = new InputFile(path);

        //Act
        Exception e = Assert.Throws<ArgumentException>(() => { inputFile.readFile(); });

        //Assert
        Assert.Equal("The file was not found", e.Message);
    }

    [Fact]
    public void RaiseExceptionWhenFileNotFound()
    {
        //Arrange
        string path = "/Users/Jen/Documents/Code/Packsize/CollegeCoursePrerequisites/TestFiles/input.txt";
        InputFile inputFile = new InputFile(path);

        //Act
        Exception e = Assert.Throws<FileNotFoundException>(() => { inputFile.readFile(); });

        //Assert
        Assert.Equal("The file was not found", e.Message);
    }

    [Fact]
    public void ReadAllLinesIntoInputFileInputArray()
    {
        //Arrange
        //string[] names = new string[3] {"Matt", "Joanne", "Robert"};
        string[] expected = new string[3] {"Introduction to Paper Airplanes: ", "Advanced Throwing Techniques: Introduction to Paper Airplanes", ""};
        string path = "/Users/Jen/Documents/Code/Packsize/CollegeCoursePrerequisites/TestFiles/short-test.txt";
        InputFile inputFile = new InputFile(path);

        //Act
        inputFile.readFile();

        //Assert
        Assert.Equal(expected, inputFile.InputArray);
    }
}
