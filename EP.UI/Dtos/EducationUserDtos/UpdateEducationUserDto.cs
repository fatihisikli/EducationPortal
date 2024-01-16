using EP.EL;

namespace EP.UI.Dtos.EducationUserDtos
{
    public class UpdateEducationUserDto
    {
        public int EducationUserId { get; set; }
        public int AppUserId { get; set; }
        public string PersonCount { get; set; }
        public string EducationUserName { get; set; }
        public string EducationUserType { get; set; }
        public DateTime EducationDate { get; set; }
        public string Status { get; set; }
    }
}
