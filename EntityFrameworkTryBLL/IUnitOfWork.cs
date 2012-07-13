using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTryBLL
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
