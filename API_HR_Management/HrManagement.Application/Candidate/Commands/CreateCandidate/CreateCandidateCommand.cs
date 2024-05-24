
using FluentValidation;
using HrManagement.Application.Dtos;

using MediatR;

namespace HrManagement.Application.Candidate.Commands.CreateCandidate
{
    public record CreateCandidateCommand(CandidateDto CandidateDto) : IRequest<CreateCandidateCandidateResult>;


    public record CreateCandidateCandidateResult(string Email);

    public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {
        public CreateCandidateCommandValidator()
        {
            RuleFor(x => x.CandidateDto.Id).NotEmpty().WithMessage("email is required");
            RuleFor(x => x.CandidateDto.Comments).NotEmpty().WithMessage("Comments is required");
            RuleFor(x => x.CandidateDto.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.CandidateDto.LastName).NotEmpty().WithMessage("LastName is required");
        }
    }

}
