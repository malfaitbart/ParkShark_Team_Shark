using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;

namespace ParkShark.Model
{
    public class ModelCreationCheckClass
    {
        public void CheckFilledIn(object inputValue, string errorMessageIfNotFilledIn)
        {
            if (inputValue == null)
                throw new EntityNotValidException($"{errorMessageIfNotFilledIn} is required", this);
        }
    }
}
