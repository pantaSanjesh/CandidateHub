using CandidateHubAPI.Controllers;
using CandidateHubAPI.Dtos;
using CandidateHubAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class CandidateControllerTests
{
    private readonly Mock<ICandidateService> _serviceMock;
    private readonly CandidateController _controller;

    public CandidateControllerTests()
    {
        _serviceMock = new Mock<ICandidateService>();
        _controller = new CandidateController(_serviceMock.Object); 
    }

    [Fact]
    public async Task AddOrUpdateCandidate_ShouldReturnOk_WhenCandidateIsAddedOrUpdated()
    {
        // Arrange
        var candidateDto = new CandidateDto
        {
            Email = "user@example.com",
            FirstName = "Sanjesh",
            LastName = "Panta",
            PhoneNumber = "1234567890",
            LinkedInProfile = "https://linkedin.com/in/sanjeshpanta",
            GitHubProfile = "https://github.com/sanjeshpanta",
            PreferredCallTime = "Afternoon",
            Comments = "New Candidate"
        };

        _serviceMock.Setup(s => s.AddOrUpdateCandidateAsync(candidateDto))
                    .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.AddOrUpdateCandidate(candidateDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result); 
        Assert.Equal("Candidate information added/updated successfully.", okResult.Value);
        _serviceMock.Verify(s => s.AddOrUpdateCandidateAsync(candidateDto), Times.Once); 
    }

    [Fact]
    public async Task AddOrUpdateCandidate_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var candidateDto = new CandidateDto(); 
        _controller.ModelState.AddModelError("Email", "The Email field is required."); 

        // Act
        var result = await _controller.AddOrUpdateCandidate(candidateDto);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result); 
        Assert.IsType<SerializableError>(badRequestResult.Value); 
        _serviceMock.Verify(s => s.AddOrUpdateCandidateAsync(It.IsAny<CandidateDto>()), Times.Never); 
    }
}
