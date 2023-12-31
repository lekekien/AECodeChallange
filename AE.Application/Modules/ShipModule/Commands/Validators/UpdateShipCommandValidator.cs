﻿using AE.Application.Modules.ShipModule.Commands.CommandModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Commands.Validators
{
    public class UpdateShipCommandValidator : AbstractValidator<UpdateShipCommand>
    {
        public UpdateShipCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required !");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required !");
            RuleFor(x => x.Latitude).InclusiveBetween(-90, 90).WithMessage("Latitude must be a number between -90 and 90 !");
            RuleFor(x => x.Longtitude).InclusiveBetween(-180, 180).WithMessage("Longtitude between -180 and 180 !");
            RuleFor(x => x.Velocity).NotEmpty().WithMessage("Velocity is required !");
        }
    }
}
