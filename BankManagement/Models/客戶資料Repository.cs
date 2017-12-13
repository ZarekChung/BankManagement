using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BankManagement.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
		public 客戶資料 Find(int Id)
		{
			return this.All().FirstOrDefault(p => p.Id == Id);
		}

		public override IQueryable<客戶資料> All()
		{
			return base.All().Where(p => p.isDeleted == false);
		}

		public override void Delete(客戶資料 entity)
		{
			entity.isDeleted = true;
		}
	}

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}