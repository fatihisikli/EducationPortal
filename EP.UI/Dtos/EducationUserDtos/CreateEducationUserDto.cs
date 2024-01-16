﻿using EP.EL;

namespace EP.UI.Dtos.EducationUserDtos
{
    public class CreateEducationUserDto
    {
        public int AppUserId { get; set; }
        public string PersonCount { get; set; }
        public string EducationUserName { get; set; }
        public string EducationUserType { get; set; }
        public DateTime EducationDate { get; set; }
        public string Status { get; set; }
    }
}
