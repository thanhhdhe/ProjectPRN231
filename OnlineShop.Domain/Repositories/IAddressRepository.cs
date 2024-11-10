using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task<int> AddAddressAsync(Address address);
        Task<Address> GetAddressByIdAsync(int id);
        Task<IEnumerable<Address>> GetByUserId(string id);
        Task UpdateAddressAsync(Address address);
    }
}
