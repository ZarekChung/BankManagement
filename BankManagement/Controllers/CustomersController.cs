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
			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱");
			return View();
		}

		// POST: Customers/Create
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(客戶聯絡人 data)
		{
			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱");
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
			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", data.客戶Id);
			return View(data);
		}

		// POST: Customers/Edit/5
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, FormCollection formValue)
		{
			
			var item = 客戶聯絡人Repo.Find(id);
			ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", item.客戶Id);
			if (ModelState.IsValid)
			{
				
				if (UpdateAllData(null, item, null, formValue))
				{
					客戶聯絡人Repo.UnitOfWork.Commit();
					TempData["客戶聯絡人Item"] = item;
					return RedirectToAction("Index");
				}
				

			}
			return View(item);
		}

		// GET: Customers/Delete/5
		public ActionResult Delete(int id)
		{
			var item = 客戶聯絡人Repo.Find(id);
			客戶聯絡人Repo.Delete(item);
			客戶聯絡人Repo.UnitOfWork.Commit();
			return RedirectToAction("Index");
		}

	

	
	}
}
