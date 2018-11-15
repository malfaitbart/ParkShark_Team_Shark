using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Infrastructure.DtoMapper
{
    public abstract class Mapper<DTO, DOMAIN>
    {
        public abstract DTO DomainToDto(DOMAIN domainObject);
        public abstract DOMAIN DtoToDomain(DTO dtoObject);

    }
}
