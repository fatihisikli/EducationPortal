using EP.EL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DTO.EducationDto
{
    public class UpdateEducationUser
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

