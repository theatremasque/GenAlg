namespace Schedule.Web.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int Semester { get; set; }
        public int LectionHours { get; set; }
        public int PracticHours { get; set; }
        public int LabourHours { get; set; }
        public int SelfHours { get; set; }
        public int StudyPlanId { get; set; }
    }
}
