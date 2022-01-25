using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class Position
    {
        public int PositionID { get; set; }

        public string PositionName { get; set; }

        public ICollection<Programmer> Programmers { get; set; }
    }
}
