using HrManagement.Application.Data;
using HrManagement.Application.Dtos;
using HrManagement.Domain.ValuesObjects;
using Mapster;
using MediatR;

namespace HrManagement.Application.Candidate.Queries.GetCandidateById
{
    public class GetCandidateByIdQuerieHandler(IApplicationDbContext dbContext) : IRequestHandler<GetCandidateByIdQuerie, GetCandidateByIdQuerieResult>
    {
        public async Task<GetCandidateByIdQuerieResult> Handle(GetCandidateByIdQuerie query, CancellationToken cancellationToken)
        {
            var candidateId = Email.Of(query.Email.Value);
            var candidate = await dbContext.Candidates.FindAsync([candidateId, cancellationToken], cancellationToken: cancellationToken);
            var canidateDto = candidate.Adapt<CandidateDto>();
            return new GetCandidateByIdQuerieResult(canidateDto);
        }
    }
}
