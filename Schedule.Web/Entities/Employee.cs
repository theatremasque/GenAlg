namespace Schedule.Web.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int PersonId { get; set; }
        public int PositionId { get; set; }
        public int PluralityId { get; set; }
        public bool IsActive { get; set; }
        
    }
}
