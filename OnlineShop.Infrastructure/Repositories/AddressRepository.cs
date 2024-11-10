using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class AddressRepository(OnlineShopDBContext _context) : IAddressRepository
    {
        //add address
        public async Task<int> AddAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address.Id;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            return address;
        }

        public async Task<IEnumerable<Address>> GetByUserId(string id)
        {
            var addresses = await _context.Addresses.Where(a => a.CustomerId == id && a.IsDeleted == false).ToListAsync();
            return addresses;
        }

        public async Task UpdateAddressAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }
    }
}
