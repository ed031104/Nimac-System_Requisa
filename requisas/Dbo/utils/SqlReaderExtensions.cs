using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo.utils
{
    public static class SqlReaderExtensions
    {
        public static T validateTypeData<T>(this SqlDataReader reader, string columnName)
        {
            var value = reader[columnName];
            return value == DBNull.Value ? default(T) : (T)value;
        }
    }
}
