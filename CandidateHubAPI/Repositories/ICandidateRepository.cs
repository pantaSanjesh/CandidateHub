using CandidateHubAPI.Models;

namespace CandidateHubAPI.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);
        Task AddOrUpdateCandidateAsync(Candidate candidate);
    }
}
