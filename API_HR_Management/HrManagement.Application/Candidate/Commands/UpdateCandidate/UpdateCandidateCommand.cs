
using FluentValidation;
using HrManagement.Application.Dtos;
using MediatR;

namespace HrManagement.Application.Candidate.Commands.UpdateCandidate
{
   
    public record UpdateCandidateCommand(CandidateDto CandidateDtoFromDb, CandidateDto CandidateDto) : IRequest<UpdateCandidateCommandResult>;

    public record UpdateCandidateCommandResult(bool IsSuccess);

    public class UpdateCandidateCommandValidator : AbstractValidator<UpdateCandidateCommand>
    {
        public UpdateCandidateCommandValidator()
        {
            RuleFor(x => x.CandidateDto.Id).NotEmpty().WithMessage("email is required");
            RuleFor(x => x.CandidateDto.Comments).NotEmpty().WithMessage("Comments is required");
            RuleFor(x => x.CandidateDto.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.CandidateDto.LastName).NotEmpty().WithMessage("LastName is required");
        }
    }
}
