using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagement.Models;

namespace BankManagement.ActionFilters
{
	public class DropDownJobListAttribute :ActionFilterAttribute
	{
		protected 客戶聯絡人Repository 客戶聯絡人Repo = RepositoryHelper.Get客戶聯絡人Repository();
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			
			var 職稱 = (from p in 客戶聯絡人Repo.All()
				select new
				{
					Value = p.職稱,
					Text = p.職稱
				}).Distinct().OrderBy(p => p.Value);

			filterContext.Controller.ViewBag.職稱 = new SelectList(職稱, "Value", "Text");			
			//Doesn't work
			//filterContext.Controller.ViewBag.JobTitle = new 客戶聯絡人Repository().JobList();
			base.OnActionExecuted(filterContext);
		}
	}
}