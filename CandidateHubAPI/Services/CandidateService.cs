using CandidateHubAPI.Dtos;
using CandidateHubAPI.Interface;
using CandidateHubAPI.Models;
using CandidateHubAPI.Repositories;

namespace CandidateHubAPI.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task AddOrUpdateCandidateAsync(CandidateDto candidateDto)
        {
            var candidate = new Candidate
            {
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                PhoneNumber = candidateDto.PhoneNumber,
                Email = candidateDto.Email,
                PreferredCallTime = candidateDto.PreferredCallTime,
                LinkedInProfile = candidateDto.LinkedInProfile,
                GitHubProfile = candidateDto.GitHubProfile,
                Comments = candidateDto.Comments
            };
            await _repository.AddOrUpdateCandidateAsync(candidate);
        }
    }

}
