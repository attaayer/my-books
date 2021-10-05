using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rewrite_repo.Data.Models;
using rewrite_repo.Data.Services;
using rewrite_repo.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rewrite_repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        public RepoService _allocationsService;

        public RepoController(RepoService allocationsService)
        {
            _allocationsService = allocationsService;
        }

        [HttpPost("add-allocation")]
        public IActionResult AddAllocation([FromBody] RepoVM allocation)
        {
            _allocationsService.AddAllocation(allocation);
            return Ok();
        }


        [HttpGet("get-all-allocations")]
        public IActionResult GetAllAllocations()
        {
            var allAllocations = _allocationsService.GetAllAllocations();
            return Ok(allAllocations);
        }


        [HttpGet("get-allocation-by-Id/{id}")]
        public IActionResult GetAllocationById(int id)
        {
            var _allocation = _allocationsService.GetAllocationById(id);
            if (_allocation != null)
            {
                return Ok(_allocation);
            }
            else
            {
                return NotFound(); // This will give 404 error much better with IActionResult.
            }
            //return Ok(_allocation);
        }

        [HttpGet("get-allocation-type-by-Id/{id}")]
        public ActionResult<Repo> GetAllocationTypeById(int id)
        {
            var _allocation = _allocationsService.GetAllocationById(id);
            if (_allocation != null)
            {
                //return Ok(_allocation);
                return _allocation;
            }
            else
            {
                return NotFound(); // This will give 404 error much better with IActionResult.
            }
            //return Ok(_allocation);
        }

        [HttpGet("get-a-allocation-by-Id/{id}")]
        public Repo GetAAllocationById(int id)
        {
            var _allocation = _allocationsService.GetAllocationById(id);
            //return Ok(allocation);

            if ( _allocation != null)
            {
                return _allocation;
            }
            else
            { 
                return null; // Even this is returning 204 something but empty data but still something.
            }
        }

        [HttpPut("upd-allocation-by-Id/{id}")]
        public IActionResult UpdAllocationById(int id,[FromBody]RepoVM allocation)
        {
            var updallocation = _allocationsService.UpdateAllocationById(id, allocation);
            return Ok(updallocation);
        }

        [HttpDelete("del-allocation-by-Id/{id}")]
        public IActionResult DelAllocationById(int id)
        {
            _allocationsService.DeleteAllocationById(id);
            return Ok();
        }
    }
}
