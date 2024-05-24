using Moq;
using Microsoft.EntityFrameworkCore;
using HrManagement.Application.Data;
using HrManagement.Domain.ValuesObjects;
using HrManagement.Application.Candidate.Commands.CreateCandidate;
using HrManagement.Domain.Models;
using HrManagement.Application.Dtos;

public class CreateCandidatHandlerTests
{
    private readonly Mock<IApplicationDbContext> _mockDbContext;
    private readonly CreateCandidateCommandHandler _handler;

    public CreateCandidatHandlerTests()
    {
        _mockDbContext = new Mock<IApplicationDbContext>();
        var mockDbSet = new Mock<DbSet<Candidate>>();

        // setup mock DbSet
        _mockDbContext.Setup(db => db.Candidates).Returns(mockDbSet.Object);

        // setup mock SaveChangesAsync to simulate database write
        _mockDbContext.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1); // simulate one entity being added

        _handler = new CreateCandidateCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldCreateCandidateAsync()
    {
        // Arrange
        var command = new CreateCandidateCommand(new CandidateDto
        {
            Id = new Email("example@example.com"),
            FirstName = "John",
            LastName = "Doe",
            Comments = "New candidate"
        });

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("example@example.com", result.Email);
        _mockDbContext.Verify(db => db.Candidates.Add(It.IsAny<Candidate>()), Times.Once);
        _mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
