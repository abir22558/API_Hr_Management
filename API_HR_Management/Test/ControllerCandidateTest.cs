using MediatR;
using Microsoft.AspNetCore.Mvc;
using HrManagement.Application.Candidate.Queries.GetCandidates;
using Moq;
using API_HR_Management.Controllers;
using HrManagement.Application.Dtos;
using HrManagement.Domain.ValuesObjects;
using HrManagement.Application.Candidate.Queries;
using HrManagement.Application.Candidate.Commands.CreateCandidate;
using HrManagement.Application.Candidate.Commands.UpdateCandidate;

namespace Test
{
    public class CandidatControllerTests
    {
        private readonly Mock<ISender> _mockMediator;
        private readonly CandidateController _controller;

        public CandidatControllerTests()
        {
            _mockMediator = new Mock<ISender>();
            _controller = new CandidateController(_mockMediator.Object);
        }

        [Fact]
        public async Task UpsertCandidateAsync_WhenCandidateDoesNotExist_ShouldCreateCandidateAsync()
        {
            // Arrange
            var candidatDto = new CandidateDto { Id = new Email("example@example.com"), FirstName = "John", LastName = "Doe", Comments = "Test" };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetCandidateByIdQuerie>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCandidateByIdQuerieResult(null));
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateCandidateCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CreateCandidateCandidateResult(candidatDto.Id.Value));

            // Act
            var result = await _controller.UpsertCandidateAsync(candidatDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
            _mockMediator.Verify(m => m.Send(It.IsAny<CreateCandidateCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpsertCandidateAsync_WhenCandidateExists_ShouldUpdateCandidateAsync()
        {
            // Arrange
            var existingCandidatDto = new CandidateDto { Id = new Email("example@example.com"), FirstName = "John", LastName = "Doe", Comments = "Existing" };
            var newCandidatDto = new CandidateDto { Id = new Email("example@example.com"), FirstName = "Jane", LastName = "Smith", Comments = "Updated" };

            _mockMediator.Setup(m => m.Send(It.IsAny<GetCandidateByIdQuerie>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCandidateByIdQuerieResult(existingCandidatDto));
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateCandidateCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UpdateCandidateCommandResult(true));

            // Act
            var result = await _controller.UpsertCandidateAsync(newCandidatDto);

            // Assert
            var contentResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, contentResult.StatusCode);
            _mockMediator.Verify(m => m.Send(It.IsAny<UpdateCandidateCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetAllCandidatesAsync_ShouldReturnCandidatesAsync()
        {
            // Arrange
            var candidates = new List<CandidateDto>
            {
            new CandidateDto { Id =new  Email("example1@example.com" ), FirstName = "John", LastName = "Doe", Comments = "Test" },
            new CandidateDto { Id = new Email("example2@example.com" ), FirstName = "Jane", LastName = "Smith", Comments = "Test" }
        };

            _mockMediator.Setup(m => m.Send(It.IsAny<GetCandidatesQuerie>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCandidatesQuerieResult(candidates));

            // Act
            var result = await _controller.GetAllCandidatesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CandidateDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            _mockMediator.Verify(m => m.Send(It.IsAny<GetCandidatesQuerie>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }

}
