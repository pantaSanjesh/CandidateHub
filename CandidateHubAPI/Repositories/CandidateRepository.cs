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
                _context.Entry(existingCandidate).CurrentValues.SetValues(candidate);
            }
            else
            {
                await _context.Candidates.AddAsync(candidate);
            }
            await _context.SaveChangesAsync();
        }
    }

}
