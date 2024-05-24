using HrManagement.Application.Data;
using HrManagement.Application.Dtos;
using HrManagement.Domain.ValuesObjects;
using MediatR;

namespace HrManagement.Application.Candidate.Commands.CreateCandidate
{
    public class CreateCandidateCommandHandler(IApplicationDbContext dbContext) :
       IRequestHandler<CreateCandidateCommand, CreateCandidateCandidateResult>
    {
        public async Task<CreateCandidateCandidateResult> Handle(CreateCandidateCommand command, CancellationToken cancellationToken)
        {
            var candidate = CreateCandidate(command.CandidateDto);
            dbContext.Candidates.Add(candidate);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateCandidateCandidateResult(candidate.Id.Value);
        }

        private static Domain.Models.Candidate CreateCandidate(CandidateDto candidatDto)
        {
            return Domain.Models.Candidate.Create(
                Email.Of(candidatDto.Id.Value),
                candidatDto.FirstName, candidatDto.LastName, candidatDto.Comments,
                candidatDto.PhoneNumber is not null ? PhoneNumber.Of(candidatDto.PhoneNumber.Value) : null,
                candidatDto.CallTimeInterval is null ? null : CallTimeInterval.Of(candidatDto.CallTimeInterval)
               , candidatDto.LinkedInUrl, candidatDto.GitHubUrl); ;
        }
    }
}
