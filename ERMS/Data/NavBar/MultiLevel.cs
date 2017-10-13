using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMS.Data.NavBar
{
    public class MultiLevel
    {
        public int Id { get; set; }
        public string LevelName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string FontAwesome { get; set; }

        public List<LevelOne> LevelOnes { get; private set; }

        public MultiLevel()
        {
            LevelOnes = new List<LevelOne>();   
        }

        public MultiLevel(string levelName, string fontAwesome)
            : this()
        {
            LevelName = levelName;
            FontAwesome = fontAwesome;

        }


        protected void AddLevelOne(LevelOne levelOne)
        {
            LevelOnes.Add(levelOne);
        }
        public static List<MultiLevel> GetOptions()
        {
            var multiLevels = new List<MultiLevel>();
            
            // 1st Option
            var multiLevel = new MultiLevel("Dashboard", "fa fa-dashboard");
            var levelOne = new LevelOne("Letters", "Letters", "Index");



      //      multiLevel.AddLevelOne(levelOne);


            multiLevels.Add(multiLevel);

            return multiLevels;
        }
    }
}
