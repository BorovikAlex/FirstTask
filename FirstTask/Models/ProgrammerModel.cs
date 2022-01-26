using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class ProgrammerModel
    {
        public int ProgrammerID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        public int PositionID { get; set; }

        public PositionModel Position { get; set; }
    }
}
