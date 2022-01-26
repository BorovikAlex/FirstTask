using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class PositionModel
    {
        public int PositionID { get; set; }

        public string PositionName { get; set; }

        public ICollection<ProgrammerModel> Programmers { get; set; }
    }
}
