using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Models;

namespace Customer.Services
{
    public interface ICustService
    {
        // "Müşteriler için yapılacak görevleri içerir"
        Task<IEnumerable<Cust>> GetCustItemsAsync();
        Task<bool> AddCustAsync(Cust newCust);
        Task<bool> UpdCustAsync(Cust updCust);
        Task<bool> DelCustAsync(Guid id);
    }
}