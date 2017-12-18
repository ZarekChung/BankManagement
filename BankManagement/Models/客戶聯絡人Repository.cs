using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BankManagement.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
		public 客戶聯絡人 Find(int Id)
		{
			return this.All().FirstOrDefault(p => p.Id == Id);
		}
		public IQueryable<客戶聯絡人> FindType(string type)
		{
			var data = this.All().Where(p => p.職稱 == type);
			if (!data.Any())
			{
				data = this.All();
			}
			return data;
		}

		public 客戶聯絡人 UpdateAll(客戶聯絡人 data)
		{
			var item = this.Find(data.Id);
			item.客戶Id = data.客戶Id;
			item.Email = data.Email;
			item.姓名 = data.姓名;
			item.客戶資料 = data.客戶資料;
			item.職稱 = data.職稱;
			item.手機 = data.手機;
			item.電話 = data.電話;

			return item;
		}

		public SelectList JobList(string type)
		{
			var jobList = (from p in this.All()
				select new
				{
					Value = p.職稱,
					Text = p.職稱
				}).Distinct().OrderBy(p => p.Value);
			//if (type.Equals("")) return new SelectList(jobList, "Value", "Text");
				return new SelectList(jobList, "Value", "Text", type); ;
		}
		/*
		public SelectList JobList()
		{
			var jobList = (from p in this.All()
				select new
				{
					Value = p.職稱,
					Text = p.職稱
				}).Distinct().OrderBy(p => p.Value);
			return new SelectList(jobList, "Value", "Text"); ;
		}
		*/
		public override void Delete(客戶聯絡人 entity)
		{
			entity.isDeleted = true;
		}

		public override IQueryable<客戶聯絡人> All()
		{
			return base.All().Where(p => p.isDeleted == false);
		}


	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}