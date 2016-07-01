using System;
using System.IO;
using Xunit;
using CollegeCoursePrerequisites;
public class CollegeCatalogueShould
{
    [Fact]
    public void CreateANewCollegueCatalogueObject()
    {
        //Arrange
        CollegeCatalogue catalogue = new CollegeCatalogue();
        Assert.NotNull(catalogue.CourseCatalogue);
    }

    [Fact]
    public void NotAddEmptyLinesToCourseCatalogue()
    {
        string[] inputArray = {""};
        CollegeCatalogue catalogue = new CollegeCatalogue();
        catalogue.LoadCourseCatalogue(inputArray);
        Assert.Empty(catalogue.CourseCatalogue);
        
    }

    [Fact]
    public void NotAddNullLinesToCourseCatalogue()
    {
        string[] inputArray = {};
        CollegeCatalogue catalogue = new CollegeCatalogue();
        catalogue.LoadCourseCatalogue(inputArray);
        Assert.Empty(catalogue.CourseCatalogue);
    }

    [Fact]
    public void ParseInputArrayWithPrerequisite()
    {
        string[] inputArray = {"Introduction to Fire: "};
        CollegeCatalogue catalogue = new CollegeCatalogue();
        catalogue.LoadCourseCatalogue(inputArray);
        Assert.Contains("Introduction to Fire", catalogue.CourseCatalogue.Keys);
    }
    
    [Fact]
    public void ParseInputArrayWithCourseAndPrerequisiteKey()
    {
        string[] inputArray = {"History of Cubicle Siege Engines: Rubber Band Catapults 101"};
        CollegeCatalogue catalogue = new CollegeCatalogue();
        catalogue.LoadCourseCatalogue(inputArray);
        Assert.Contains("Rubber Band Catapults 101", catalogue.CourseCatalogue.Keys);
    }

    [Fact]
    public void ParseInputArrayWithCourseAndPrerequisiteValue()
    {
        string[] inputArray = {"History of Cubicle Siege Engines: Rubber Band Catapults 101"};
        CollegeCatalogue catalogue = new CollegeCatalogue();
        catalogue.LoadCourseCatalogue(inputArray);
        Assert.Contains("History of Cubicle Siege Engines", catalogue.CourseCatalogue["Rubber Band Catapults 101"]);
    }

    [Fact]
    public void ParseInputArrayOrderNotImportantKey()
    {
        string[] inputArray = {"Advanced Office Warfare: History of Cubicle Siege Engines", "History of Cubicle Siege Engines: Rubber Band Catapults 101", "Rubber Band Catapults 101: "};
        CollegeCatalogue catalogue = new CollegeCatalogue();
        catalogue.LoadCourseCatalogue(inputArray);
        Assert.Contains("Rubber Band Catapults 101", catalogue.CourseCatalogue.Keys);
    }

    [Fact]
    public void ParseInputArrayOrderNotImportantValues()
    {
        string[] inputArray = {"Advanced Office Warfare: History of Cubicle Siege Engines", "History of Cubicle Siege Engines: Rubber Band Catapults 101", "Rubber Band Catapults 101: "};
        CollegeCatalogue catalogue = new CollegeCatalogue();
        catalogue.LoadCourseCatalogue(inputArray);
        Assert.Contains("Advanced Office Warfare", catalogue.CourseCatalogue["Rubber Band Catapults 101"]);
    }
}
