
using HrManagement.Application.Dtos;
using MediatR;

namespace HrManagement.Application.Candidate.Queries
{
        public record GetCandidateByIdQuerie(Domain.ValuesObjects.Email Email) : IRequest<GetCandidateByIdQuerieResult>;
        public record GetCandidateByIdQuerieResult(CandidateDto CandidatDto);
}
