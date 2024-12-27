using CandidateHubAPI.Dtos;

namespace CandidateHubAPI.Interface
{
    public interface ICandidateService
    {
        Task AddOrUpdateCandidateAsync(CandidateDto candidateDto);
    }
}
