using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{
    public class AdminService : IAdmin
    {
        private LibraryContext _context;

        public AdminService(LibraryContext context)
        {
            _context = context;
        }

        public Admin GetByUsername(string username)
        {
            return _context.Admins.FirstOrDefault(user => user.Username == username);
        }
    }
}
