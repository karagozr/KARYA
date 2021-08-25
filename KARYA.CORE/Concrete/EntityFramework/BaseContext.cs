using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Concrete.EntityFramework
{
    public abstract class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<DbContext> options):base(options)
        {

        }
    }
}
