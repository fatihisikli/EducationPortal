using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DTO.EducationDto
{
    public class GetEducation
    {

        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public string EducationType { get; set; }
        public string EducationTime { get; set; }
        public double EducationPrice { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }

    }
}
