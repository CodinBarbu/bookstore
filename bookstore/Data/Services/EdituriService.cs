using bookstore.Data.Base;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.Services
{
    public class EdituriService:EntityBaseRepository<Editura>,IEdituriService
    {
        public EdituriService(AppDbContext context): base(context)
        {

        }
    }
}
