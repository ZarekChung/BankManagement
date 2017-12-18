using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing.Constraints;
using System.Web.Mvc;
using BankManagement.Models;
using Microsoft.Ajax.Utilities;

namespace BankManagement.Controllers
{
	public class BaseController : Controller
	{
		protected CustomerDataCountRepository CustomerDataCountRepo = RepositoryHelper.GetCustomerDataCountRepository();

		protected 客戶資料Repository 客戶資料Repo = RepositoryHelper.Get客戶資料Repository();

		protected 客戶聯絡人Repository 客戶聯絡人Repo = RepositoryHelper.Get客戶聯絡人Repository();

		protected 客戶銀行資訊Repository 客戶銀行資訊Repo = RepositoryHelper.Get客戶銀行資訊Repository();

		protected 客戶分類Repository 客戶分類Repo = RepositoryHelper.Get客戶分類Repository();

		protected override void HandleUnknownAction(string actionName)
		{
		   this.Redirect("/").ExecuteResult(this.ControllerContext);
			//base.HandleUnknownAction(actionName);	
		}

		public bool UpdateAllData(客戶資料 data客戶資料, 客戶聯絡人 data客戶聯絡人, 客戶銀行資訊 data客戶銀行資訊, FormCollection item)
		{
			bool result = false;
			if (data客戶資料 != null)
			{
				 result = TryUpdateModel(data客戶資料, "", item.AllKeys, new string[] { "ModifyUid" });
			}
			else if (data客戶聯絡人 != null)
			{
				 result = TryUpdateModel(data客戶聯絡人, "", item.AllKeys, new string[] { "ModifyUid" });
			}
			else
			{
				 result = TryUpdateModel(data客戶銀行資訊, "", item.AllKeys, new string[] { "ModifyUid" });
			}
			return result;
		}

	}
}