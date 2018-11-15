using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;

namespace ParkShark.Model
{
    public class ModelCreationCheckClass
    {
        public void CheckFilledIn(object inputValue, string errorMessageIfNotFilledIn, object objectOfClass)
        {
            if (inputValue is int)
            {
                if ((int) inputValue == 0)
                throw new EntityNotValidException($"{errorMessageIfNotFilledIn} is required", objectOfClass);
            }
            if (inputValue is decimal)
            {
                if ((decimal)inputValue == 0)
                    throw new EntityNotValidException($"{errorMessageIfNotFilledIn} is required", objectOfClass);
            }
            if (inputValue == null)
                throw new EntityNotValidException($"{errorMessageIfNotFilledIn} is required", objectOfClass);

        }
    }
}
