using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using wwwPostgresSQL.Models;

namespace wwwPostgresSQL.Interfaces
{
    public interface IDataAccess
    {
        IEnumerable<DataModel> Execute(string query);
    }
}
