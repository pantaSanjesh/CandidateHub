using CandidateHubAPI.DbContext;
using CandidateHubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateHubAPI.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddOrUpdateCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await GetCandidateByEmailAsync(candidate.Email);
            if (existingCandidate != null)
            {

                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.GitHubProfile = candidate.GitHubProfile;
                existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                existingCandidate.PreferredCallTime = candidate.PreferredCallTime;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.Comments = candidate.Comments;

                _context.SaveChangesAsync();
            }
            else
            {
                await _context.Candidates.AddAsync(candidate);
                await _context.SaveChangesAsync();
            }

        }
    }

}
