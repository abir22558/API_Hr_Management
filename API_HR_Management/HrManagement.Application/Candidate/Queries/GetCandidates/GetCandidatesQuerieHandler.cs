using HrManagement.Application.Data;
using HrManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Application.Candidate.Queries.GetCandidates
{
    public  class GetCandidatesQuerieHandler(IApplicationDbContext dbContext) : IRequestHandler<GetCandidatesQuerie, GetCandidatesQuerieResult>
    {
        public async Task<GetCandidatesQuerieResult> Handle(GetCandidatesQuerie request, CancellationToken cancellationToken)
        {
            var candidats = await dbContext.Candidates
                                            .AsNoTracking()
                                            .OrderByDescending(c => c.CreatedAt)
                                            .ToListAsync(cancellationToken: cancellationToken);

            return new GetCandidatesQuerieResult(MapCandidatesToDtos(candidats));
        }

            private static List<CandidateDto> MapCandidatesToDtos(List<Domain.Models.Candidate> candidats)
            {
                var candidateDtos = new List<CandidateDto>();

                foreach (var candidat in candidats)
                {
                    var dto = new CandidateDto
                    {
                        Id = candidat.Id,
                        FirstName = candidat.FirstName,
                        LastName = candidat.LastName,
                        PhoneNumber = candidat.PhoneNumber,
                        CallTimeInterval = candidat.CallTimeInterval,
                        LinkedInUrl = candidat.LinkedInUrl,
                        GitHubUrl = candidat.GitHubUrl,
                        Comments = candidat.Comments
                    };

                    candidateDtos.Add(dto);
                }

                return candidateDtos;
            }
        }
    
}
