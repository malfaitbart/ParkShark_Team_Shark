using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Infrastructure.Exceptions
{
    public class EntityNotValidException : Exception
    {
        public EntityNotValidException(string additionalContext, object entity)
            : base($"During {additionalContext}, the following entity was found to be invalid: {entity}")
        {
        }
    }
}
