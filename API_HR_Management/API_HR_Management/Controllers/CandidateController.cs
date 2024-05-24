using HrManagement.Application.Candidate.Commands.CreateCandidate;
using HrManagement.Application.Candidate.Commands.UpdateCandidate;
using HrManagement.Application.Candidate.Queries;
using HrManagement.Application.Candidate.Queries.GetCandidates;
using HrManagement.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API_HR_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController(ISender mediator) : ControllerBase
    {
        private readonly ISender _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllCandidatesAsync()
        {
            try
            {
                var query = new GetCandidatesQuerie();
                var result = await _mediator.Send(query);
                return Ok(result.Candidates);
            }
            catch(Exception ex)
            { 
                return BadRequest(ex.Message);
            }
           
        }

        //Endpoint for updating or creating candidate 
        //if candidate already exists = > update 
        //if it doesn't exists => create a new candidate 
        //since id is email so it cannot be changed 

        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertCandidateAsync([FromBody] CandidateDto candidatDto)
        {
            try
            {
                if (candidatDto == null)
                {
                    return BadRequest("Invalid candidate data.");
                }
                //Update Candidate
                var candidatExistCommand = new GetCandidateByIdQuerie(candidatDto.Id);
                var resultCandidateFromDb = await _mediator.Send(candidatExistCommand);

                if (resultCandidateFromDb.CandidatDto is not null)
                {
                    var updateCommand = new UpdateCandidateCommand(resultCandidateFromDb.CandidatDto, candidatDto);
                    var updateResult = await _mediator.Send(updateCommand);
                    if (!updateResult.IsSuccess)
                    {
                        return NotFound($"Candidate with Email {candidatDto.Id} is not found.");
                    }
                    return Ok("Candidate updated successfully.");
                }
                //Create Candidate
                var createCommand = new CreateCandidateCommand(candidatDto);
                var createdId = await _mediator.Send(createCommand);
                return Created("Created Succes with Id", createdId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
