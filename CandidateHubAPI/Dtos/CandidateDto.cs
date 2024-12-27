using System.ComponentModel.DataAnnotations;

namespace CandidateHubAPI.Dtos
{
    public class CandidateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string PreferredCallTime { get; set; }
        public string LinkedInProfile { get; set; }
        public string GitHubProfile { get; set; }
        [Required]
        public string Comments { get; set; }
    }

}
