using FeedbackWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FeedbackWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly string connectionString;
        public FeedbackController(IConfiguration configuration) {
            connectionString = configuration["ConnectionStrings:SqlServerDb"] ?? "";
        }
        [HttpPost]
        public IActionResult CreateFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Feedback " +
                        "(Feedback_score) VALUES " +
                        "(@Feedback_score)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Feedback_score", feedbackModel.Feedback_score);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Feedback", "Sorry, but we have an exception.");
                return BadRequest(ex);
            }
            return Ok();
        } 
    }
}
