using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    public class PositionModel
    {
        public int PositionID { get; set; }

        [Required(ErrorMessage = "PositionName is required.")]
        public string PositionName { get; set; }

        public ICollection<ProgrammerModel> Programmers { get; set; }
    }
}
