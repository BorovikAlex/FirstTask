using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class DBInitializer
    {
        public static void Initialize(DBContext context)
        {

            context.Database.EnsureCreated();

            if (context.Programmers.Any())
            {
                return;   // DB has been seeded
            }

            var positions = new PositionModel[]
            {
                new PositionModel{PositionName="Software Engineer"},
                new PositionModel{PositionName="Marketing Manager"},
                new PositionModel{PositionName="HR Manager"}
            };
            foreach (PositionModel c in positions)
            {
                context.Positions.Add(c);

            }

            context.SaveChanges();
            var programmers = new ProgrammerModel[]
            {
                new ProgrammerModel{Name="Alex",LastName="Baravikou",PositionID=1}

            };
            foreach (ProgrammerModel s in programmers)
            {
                context.Programmers.Add(s);
            }
            context.SaveChanges();

        }
    }
}
