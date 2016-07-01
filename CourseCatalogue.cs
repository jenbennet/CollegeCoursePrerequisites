using System;
using System.Collections.Generic;

namespace CollegeCoursePrerequisites
{
    public class CollegeCatalogue 
    {
        public CollegeCatalogue ()
        {
            CourseCatalogue = new Dictionary<string, List<string>>();
        }

        public  Dictionary<string, List<string>> CourseCatalogue { get; private set; }

        public bool loadCourseCatalogue(string[] courseArray)
        {
            foreach(string item in courseArray)
            {
                if (String.IsNullOrEmpty(item))
                {
                    continue;
                }

                char[] delimiter = {':'};
                string[] splitItem = item.Split(delimiter, System.StringSplitOptions.RemoveEmptyEntries);
                string course = splitItem[0].Trim();
                string prerequisite = splitItem[1].Trim();
                
                if ( String.IsNullOrEmpty(prerequisite) ) 
                {
                    addPrerequisite(course);
                }
                else 
                {
                    if (! addCourse(course, prerequisite) ) 
                    {
                        CourseCatalogue.Clear();
                        return false;
                    }
                }
            }

            return true;
        }

        private bool addCourse(string course, string prerequisite )
        {
            //check for circular references
            if (prerequisite == course)
            {
                return false;
            }

            //the prerequisite exists in the hash
            if( CourseCatalogue.ContainsKey(prerequisite))
            {
                CourseCatalogue[prerequisite].Add(course);
            }
            //the curse exists as prerequist and needs to be moved to a new prerequisite as a course
            else if ( CourseCatalogue.ContainsKey(course)) 
            {
                //check for circular reference
                if (CourseCatalogue[course].Contains(prerequisite)) 
                {
                    return false;
                }

                CourseCatalogue[prerequisite] = CourseCatalogue[course];
                CourseCatalogue[prerequisite].Add(course);
                CourseCatalogue.Remove(course);
            }
            else 
            {
                string key = findCourse(prerequisite);
                
                //check for circular references
                if (key == course)
                {
                    return false;
                }

                //the prerequisite already exists as a course in the hash
                if ( ! String.IsNullOrEmpty(key) )
                {
                    CourseCatalogue[key].Add(course);
                }
                //the prerequisite and the course don't exist in the hash table
                else
                {
                    CourseCatalogue[prerequisite] = new List<string>();
                    CourseCatalogue[prerequisite].Add(course);            
                }
            }

            return true;
        }

        private void addPrerequisite(string prerequisite)
        {
            if (! CourseCatalogue.ContainsKey(prerequisite) )
            {
                CourseCatalogue[prerequisite] = new List<string>();
            }
        }

        private string findCourse(string course)
        {
            foreach (string key in CourseCatalogue.Keys )
            {
                if( CourseCatalogue[key].Contains(course) )
                {
                    return key;
                }
            }

            return "";
        }

        public void printCatalogue() 
        {
            string output = String.Join(", ", CourseCatalogue.Keys);

            foreach (string key in CourseCatalogue.Keys )
            {
                for (int i = 0; i < CourseCatalogue[key].Count; i++)
                {
                    output += ", ";
                    output += CourseCatalogue[key][i];
                }
            }

            Console.WriteLine(output);
        }


    }
}