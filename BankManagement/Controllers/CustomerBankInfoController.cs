using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankManagement.Models;

namespace BankManagement.Controllers
{
	public class CustomerBankInfoController : BaseController
	{
		// GET: CustomerBankInfo
		public ActionResult Index()
		{
			var data = 客戶銀行資訊Repo.All();

			return View(data);
		}

		// GET: CustomerBankInfo/Details/5
		public ActionResult Details(int id)
		{

			var data = 客戶銀行資訊Repo.Find(id);
			
			return View(data);
		}

		// GET: CustomerBankInfo/Create
		public ActionResult Create()
		{
			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱");
			return View();
		}

		// POST: CustomerBankInfo/Create
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(客戶銀行資訊 data)
		{
			if (ModelState.IsValid)
			{
				客戶銀行資訊Repo.Add(data);
				客戶銀行資訊Repo.UnitOfWork.Commit();
				return RedirectToAction("Index");
			}

			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", data.客戶Id);
			return View(data);
		}

		// GET: CustomerBankInfo/Edit/5
		public ActionResult Edit(int id)
		{

			var item = 客戶銀行資訊Repo.Find(id);


			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", item.客戶Id);
			return View(item);
		}

		// POST: CustomerBankInfo/Edit/5
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, FormCollection formValue)
		{
			var item = 客戶銀行資訊Repo.Find(id);

			if (ModelState.IsValid)
			{

				if (UpdateAllData(null,null,item, formValue))
				{
					客戶銀行資訊Repo.UnitOfWork.Commit();
					return RedirectToAction("Index");
				}
			}
			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", item.客戶Id);
			return View(item);

		}

		// GET: CustomerBankInfo/Delete/5
		public ActionResult Delete(int id)
		{
			var data = 客戶銀行資訊Repo.Find(id);
			客戶銀行資訊Repo.Delete(data);
			客戶銀行資訊Repo.UnitOfWork.Commit();

			return RedirectToAction("Index");
		}

		
	}
}
