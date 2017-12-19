using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagement.Models;

namespace BankManagement.ActionFilters
{
	public class DropDownListByCustmerType :ActionFilterAttribute
	{
		protected 客戶分類Repository 客戶分類Repo = RepositoryHelper.Get客戶分類Repository();
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var customerTypeList = (from p in 客戶分類Repo.All()
				select new
				{
					Value = p.Id,
					Text = p.客戶分類名稱
				}).OrderBy(p => p.Value);
			filterContext.Controller.ViewBag.客戶分類Type = new SelectList(customerTypeList, "Value", "Text");
			base.OnActionExecuted(filterContext);
		}
	}
}