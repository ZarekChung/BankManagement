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

		protected override void HandleUnknownAction(string actionName)
		{
		   this.Redirect("/").ExecuteResult(this.ControllerContext);
			//base.HandleUnknownAction(actionName);	
		}
	}
}