using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCheck.viewModels
{ 
    public class SurveyViewModel
    {
        public List<string> Questions { get; set; }
        public string Link { get; set; }
        public bool Anonymous { get; set; }



        public SurveyViewModel(List<string> questions, string link, bool anonymous)
        {
            this.Questions = questions;
            this.Link = link;
            this.Anonymous = anonymous;
        }
    }
}
