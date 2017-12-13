using System;
using System.Linq;
using System.Collections.Generic;
	
namespace BankManagement.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
		public 客戶銀行資訊 Find(int Id)
		{
			return this.All().FirstOrDefault(p => p.Id == Id);
		}

		public override IQueryable<客戶銀行資訊> All()
		{
			return base.All().Where(p => p.isDeleted == false);
		}

		public override void Delete(客戶銀行資訊 entity)
		{
			entity.isDeleted = true;
		}
	}

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}