using rewrite_repo.Data.Models;
using rewrite_repo.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rewrite_repo.Data.Services
{
    public class RepoService
    {
        private AppDbContext _context;
        public RepoService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAllocation(RepoVM allocation)
        {
            var _allocation = new Repo()
            {
                Name = allocation.Name,
                Amount = allocation.Amount.Value
            };

            _context.Allocations.Add(_allocation);
            _context.SaveChanges();
        }

        //Get all Allocations
        public List<Repo> GetAllAllocations() => _context.Allocations.ToList();

        //Get a Allocation by ID
        public Repo GetAllocationById(int allocationId) => _context.Allocations.FirstOrDefault(n => n.Id == allocationId);

        public Repo UpdateAllocationById(int allocationId, RepoVM allocation)
        {
            var _allocation = _context.Allocations.FirstOrDefault(n => n.Id == allocationId);
            if(_allocation != null)
            {
                _allocation.Name = allocation.Name;
                _allocation.Amount = allocation.Amount.Value;

                _context.SaveChanges();
            }

            return _allocation;
        }

        public void DeleteAllocationById(int allocationId)
        {
            var _allocation = _context.Allocations.FirstOrDefault(n => n.Id == allocationId);
            if(_allocation != null)
            {
                _context.Allocations.Remove(_allocation);
                _context.SaveChanges();
            }
        }


    }
}
