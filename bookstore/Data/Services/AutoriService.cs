using bookstore.Data.Base;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.Services
{
    public class AutoriService :EntityBaseRepository<Autor>, IAutoriService
    {
        public AutoriService(AppDbContext context) : base(context) { }
    }
}
