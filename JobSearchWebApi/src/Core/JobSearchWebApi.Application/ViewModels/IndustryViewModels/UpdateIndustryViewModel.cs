using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.ViewModels.IndustryViewModels
{
    public class UpdateIndustryViewModel
    {
        public int Id { get; set; }
        public string IndustryName { get; set; }
        public string Icon { get; set; }
    }
}
