using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Infrastructure.DtoMapper
{
    //Great abstraction
    //Please call your generic types TDto and TDomain (as by convension)
    public abstract class Mapper<DTO, DOMAIN>
    {
        public abstract DTO DomainToDto(DOMAIN domainObject);
        public abstract DOMAIN DtoToDomain(DTO dtoObject);

    }
}
