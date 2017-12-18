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
		private CustomerDataEntities db = new CustomerDataEntities();
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			
			var jobList = (from p in db.客戶聯絡人
				select new
				{
					Value = p.職稱,
					Text = p.職稱
				}).Distinct().OrderBy(p => p.Value);

			filterContext.Controller.ViewBag.JobTitle = new SelectList(jobList, "Value", "Text");			
			//Doesn't work
			//filterContext.Controller.ViewBag.JobTitle = new 客戶聯絡人Repository().JobList();
			base.OnActionExecuted(filterContext);
		}
	}
}