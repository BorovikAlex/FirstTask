using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PositionModel
    {
        public int PositionID { get; set; }

        [Required(ErrorMessage = "PositionName is required.")]
        public string PositionName { get; set; }

        public virtual ICollection<ProgrammerModel> Programmers { get; set; }
    }
}
