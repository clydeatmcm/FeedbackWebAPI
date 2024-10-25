namespace FeedbackWebAPI.Models
{
    public class Feedback
    {
        public int Feedback_id { get; set; }
        public int Feedback_score { get; set; } = 0;
        public DateTime Feedback_createdAt { get; set; }
    }
}
