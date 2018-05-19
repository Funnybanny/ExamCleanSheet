using BE;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAL
{
    public class DALFacade
    {
        public IServiceGateway<Customer> GetCustomerServiceGateway(DbConnection connection)
        {
            var instance = CustomerServiceGateway.Instance;
            instance.SetDbConnection(connection);
            return CustomerServiceGateway.Instance;
        }
    }
}
