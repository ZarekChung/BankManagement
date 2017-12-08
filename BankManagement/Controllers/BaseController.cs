using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagement.Models;

namespace BankManagement.Controllers
{
	public class BaseController : Controller
	{
		protected CustomerDataCountRepository CustomerDataCountRepo = RepositoryHelper.GetCustomerDataCountRepository();

		protected 客戶資料Repository 客戶資料Repo = RepositoryHelper.Get客戶資料Repository();

		protected 客戶聯絡人Repository 客戶聯絡人Repo = RepositoryHelper.Get客戶聯絡人Repository();

		protected 客戶銀行資訊Repository 客戶銀行資訊Repo = RepositoryHelper.Get客戶銀行資訊Repository();
	

		protected override void HandleUnknownAction(string actionName)
		{
		   this.Redirect("/").ExecuteResult(this.ControllerContext);
			//base.HandleUnknownAction(actionName);	
		}
	}
}