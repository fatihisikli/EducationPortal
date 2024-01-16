using EP.UI.Dtos.EducationDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EP.UI.Dtos.EducationUserDtos
{
    public class EducationwithEducationUser
    {
        public CreateEducationUserDto createEducationUserDto { get; set; }
        public List<SelectListItem> resultEducationDto { get; set; }
    }
}
