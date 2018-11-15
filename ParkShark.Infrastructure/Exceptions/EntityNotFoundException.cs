using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Infrastructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string additionalContext, string className, string id)
            : base($"During {additionalContext}, the following entity was not found: {className} with id = {id}")
        {
        }
    }
}
