﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankManagement.Controllers
{
	public class CustomerDataCountController : BaseController
	{
		// GET: CustomerDataCount
		public ActionResult Index()
		{
			var data = CustomerDataCountRepo.All();
			return View(data);
		}
	}
}