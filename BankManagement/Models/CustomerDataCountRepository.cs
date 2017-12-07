using System;
using System.Linq;
using System.Collections.Generic;
	
namespace BankManagement.Models
{   
	public  class CustomerDataCountRepository : EFRepository<CustomerDataCount>, ICustomerDataCountRepository
	{
	}

	public  interface ICustomerDataCountRepository : IRepository<CustomerDataCount>
	{

	}
}