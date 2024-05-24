using HrManagement.Application.Dtos;
using MediatR;

namespace HrManagement.Application.Candidate.Queries.GetCandidates
{
    public record GetCandidatesQuerie : IRequest<GetCandidatesQuerieResult>;
    public record GetCandidatesQuerieResult(IEnumerable<CandidateDto> Candidates);
}
