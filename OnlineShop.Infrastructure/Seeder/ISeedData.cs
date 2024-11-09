using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Seeder
{
    public interface ISeedData
    {
        Task Seed();
    }
}
