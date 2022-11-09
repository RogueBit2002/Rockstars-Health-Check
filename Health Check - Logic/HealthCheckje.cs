using HealthCheck.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCheck.Models
{
    public class HealthCheckje 
    {
        public List<string> Questions { get; set; }
        public string link { get; set; }
        public Boolean anonymous { get; set; }

        private readonly IHealthCheckDAL _DAL;


        public HealthCheckje(IHealthCheckDAL healthCheckDAL)
        {
            this._DAL = healthCheckDAL;
        }


        public HealthCheckje(List<string> questions, string link, Boolean anonymous)
        {
            this.Questions = questions;
            this.link = link;
            this.anonymous = anonymous;
        }


        public void GetQuestion()
        {
            _DAL.GetQuestion();
        }
    }
}
