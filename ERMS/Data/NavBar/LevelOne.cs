using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMS.Data.NavBar
{
    public class LevelOne
    {
        public int Id { get; set; }
        public string LevelName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public LevelOne()
        {
            LevelTwos = new List<LevelTwo>();
        }

        public List<LevelTwo> LevelTwos { get; private set; }

        public LevelOne(string levelName,string controller,string action)
            :this()
        {
            LevelName = levelName;
            Controller = controller;
            Action = action;
        }


        public void AddLevelTwo(LevelTwo levelTwo)
        {
            LevelTwos.Add(levelTwo);
        }
    }
}
