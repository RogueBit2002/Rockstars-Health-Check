namespace HealthCheck.Models
{
    public class Survey
    {
        public List<string> Questions { get; set; }
        public string link { get; set; }
        public Boolean anonymous { get; set; }


        public Survey(List<string> questions, string link, Boolean anonymous)
        {
            this.Questions = questions;
            this.link = link;
            this.anonymous = anonymous;
        }
    }
}
