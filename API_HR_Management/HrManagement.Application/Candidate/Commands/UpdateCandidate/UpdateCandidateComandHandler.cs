
using HrManagement.Application.Data;
using HrManagement.Application.Dtos;
using HrManagement.Domain.ValuesObjects;
using MediatR;

namespace HrManagement.Application.Candidate.Commands.UpdateCandidate
{
    public class UpdateCandidateComandHandler(IApplicationDbContext dbContext) :
         IRequestHandler<UpdateCandidateCommand, UpdateCandidateCommandResult>
    {
        public async Task<UpdateCandidateCommandResult> Handle(UpdateCandidateCommand command, CancellationToken cancellationToken)
        {
            var candidateId = Email.Of(command.CandidateDto.Id.Value);
            var candidate = await dbContext.Candidates.FindAsync([candidateId, cancellationToken], cancellationToken: cancellationToken);

            if (candidate == null)
            {
                throw new Exception("Candidate Not found");
            }

            UpdateCandidate(candidate, command.CandidateDto);
            dbContext.Candidates.Update(candidate);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateCandidateCommandResult(true);

        }

        private static void UpdateCandidate(Domain.Models.Candidate candidate, CandidateDto candidatDto)
        {
            candidate.Update(
                Email.Of(candidatDto.Id.Value)
                , candidatDto.FirstName,
                candidatDto.LastName,
                candidatDto.Comments,
                candidatDto.PhoneNumber is not null ? PhoneNumber.Of(candidatDto.PhoneNumber.Value) : null,
                candidatDto.CallTimeInterval is null ? null : CallTimeInterval.Of(candidatDto.CallTimeInterval),
                candidatDto.LinkedInUrl,
                candidatDto.GitHubUrl
                 );
        }
    }

}
