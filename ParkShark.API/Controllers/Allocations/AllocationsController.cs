using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkShark.Services.Services.Allocations;

namespace ParkShark.API.Controllers.Allocations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationsController : ControllerBase
    {
        private readonly AllocationMapper _allocationMapper;
        private readonly IAllocationService _allocationService;

        public AllocationsController(AllocationMapper allocationMapper, IAllocationService allocationService)
        {
            _allocationMapper = allocationMapper;
            _allocationService = allocationService;
        }

        [HttpPost]
        public ActionResult<AllocationDto> StartAllocation([FromBody]AllocationDto allocationDto)
        {
            var newAllocation = _allocationMapper.DtoToDomain(allocationDto);
            newAllocation = _allocationService.StartAllocation(newAllocation);
            return Created($"api/Allocations/{newAllocation.Id}", newAllocation.Id);
        }
    }


}
