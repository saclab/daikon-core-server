using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Elevated.Organisms
{
    public class StrainController : ApiControllerBaseElevated
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return HandleResult(await Mediator.Send(new Application.Strains.List.Query { }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Strain newStrain)
        {
            return HandleResult(await Mediator.Send(new Application.Strains.Create.Command { Strain = newStrain }));
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(Guid id, Strain editedStrain)
        {
            editedStrain.Id = id;
            return HandleResult(await Mediator.Send(new Application.Strains.Edit.Command { Strain = editedStrain }));
        }
        
        
    }
}