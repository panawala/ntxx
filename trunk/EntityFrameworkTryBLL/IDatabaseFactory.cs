using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DataContext;

namespace EntityFrameworkTryBLL
{
    public interface IDatabaseFactory : IDisposable
    {
        NorthwindContext Get();
    }
}
