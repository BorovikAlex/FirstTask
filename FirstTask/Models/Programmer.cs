using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class Programmer
    {
        public int ProgrammerID { get; set; }    

        public string Name { get; set; }

        public string LastName { get; set; }
  
        public int PositionID { get; set; }

        public Position Position { get; set; }
    }
}
