using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IAdmin
    {
        Admin GetByUsername(string username);

    }
}
