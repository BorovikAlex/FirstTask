using FirstTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Data
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

            var positions = new Position[]
            {
            new Position{PositionName="Software Engineer"},
            new Position{PositionName="Marketing Manager"},
            new Position{PositionName="HR Manager"}
            };
            foreach (Position c in positions)
            {
                context.Positions.Add(c);

            }

            context.SaveChanges();
            var programmers = new Programmer[]
            {
            new Programmer{Name="Alex",LastName="Baravikou",PositionID=1}

            };
            foreach (Programmer s in programmers)
            {
                context.Programmers.Add(s);
            }
            context.SaveChanges();

        }
    }
}
