using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMS.Data.NavBar
{
    public class LevelTwo
    {
        public int Id { get; set; }
        public string LevelName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public LevelTwo()
        {

        }

        public LevelTwo(string levelName, string controller, string action)
            :this()
        {
            LevelName = levelName;
            Controller = controller;
            Action = action;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}
