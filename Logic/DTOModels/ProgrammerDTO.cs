
namespace Logic.DTOModels
{
    public class ProgrammerDTO
    {
        public int ProgrammerID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int PositionID { get; set; }

        public virtual PositionDTO? Position { get; set; }
    }
}
