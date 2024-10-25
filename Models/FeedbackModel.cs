using System.ComponentModel.DataAnnotations;

namespace FeedbackWebAPI.Models
{
    public class FeedbackModel
    {
        [Required]
        public int Feedback_id { get; set; }
        [Required]
        public int Feedback_score { get; set; }
    }
}
