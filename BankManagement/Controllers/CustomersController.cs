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
	public class CustomersController : BaseController
	{
		private CustomerDataEntities db = new CustomerDataEntities();

		// GET: Customers
		public ActionResult Index()
		{
			var data = 客戶聯絡人Repo.All();
			return View(data);
		}

		// GET: Customers/Details/5
		public ActionResult Details(int id)
		{
			var data = 客戶聯絡人Repo.Find(id);
			return View(data);
		}

		// GET: Customers/Create
		public ActionResult Create()
		{
			ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
			return View();
		}

		// POST: Customers/Create
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(客戶聯絡人 data)
		{
			if (ModelState.IsValid)
			{
				客戶聯絡人Repo.Add(data);
				客戶聯絡人Repo.UnitOfWork.Commit();
				return RedirectToAction("Index");
			}

		
			return View(data);
		}

		// GET: Customers/Edit/5
		public ActionResult Edit(int id)
		{
		
			var data = 客戶聯絡人Repo.Find(id);
			ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", data.客戶Id);
			return View(data);
		}

		// POST: Customers/Edit/5
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(客戶聯絡人 data)
		{
			if (ModelState.IsValid)
			{
				var item = 客戶聯絡人Repo.UpdateAll(data);

				客戶聯絡人Repo.UnitOfWork.Commit();
				return RedirectToAction("Index");

				TempData["客戶聯絡人Item"] = item;
			}
			return View(data);
		}

		// GET: Customers/Delete/5
		public ActionResult Delete(int id)
		{
			var item = 客戶聯絡人Repo.Find(id);
			客戶聯絡人Repo.Delete(item);
			客戶聯絡人Repo.UnitOfWork.Commit();
			return RedirectToAction("Index");
		}

	

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
