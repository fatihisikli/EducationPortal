namespace EP.UI.Dtos.EducationDtos
{
    public class CreateEducationDto
    {
        public string EducationName { get; set; }
        public string EducationType { get; set; }
        public string EducationTime { get; set; }
        public double EducationPrice { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
