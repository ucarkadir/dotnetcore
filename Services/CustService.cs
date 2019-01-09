using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Data;
using Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Services
{
    public class CustService : ICustService
    {
        // bağılmı in conter ef çektik.
         private readonly ApplicationDbContext _context;

        public CustService(ApplicationDbContext context)
        {
            _context = context;
        }

        // müşteriler için görevleri yerine getiren methodları çağırdık. 
        public async Task<bool> AddCustAsync(Cust newCust)
        {
            newCust.ID =  Guid.NewGuid();
            newCust.Disabled = false;
            newCust.OpeningDate = DateTimeOffset.Now;

            _context.tCust.Add(newCust);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> UpdCustAsync(Cust updCust)
        {
            // update 
            var item = await _context.tCust
                .Where(x => x.ID == updCust.ID)
                .SingleOrDefaultAsync();
            
            if(item == null) return false; 

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
 

        public async Task<bool> DelCustAsync(Guid id)
        {
             var item = await _context.tCust
                .Where(x => x.ID == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.Disabled = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; 
        }

        public async Task<IEnumerable<Cust>> GetCustItemsAsync()
        {
            var custs = await _context.tCust
                .Where(x => x.Disabled == false)
                .OrderBy(x=>x.Name)
                .ToArrayAsync();
            
            return custs;
        }
    }
}