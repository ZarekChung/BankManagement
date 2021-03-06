﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankManagement.ActionFilters;
using BankManagement.Models;
using PagedList;

namespace BankManagement.Controllers
{
	public class CustomerInfoController : BaseController
	{

		// GET: CustomerInfo
		[DropDownListByCustmerType]
		public ActionResult Index(int page=1)
		{
			int currentPage = page < 1 ? 1 : page;
			var pagedData = 客戶資料Repo.All().OrderBy(p => p.Id).ToPagedList(currentPage, pageSize: 1);
		
			return View(pagedData);
		}

		[HttpPost]
		[DropDownListByCustmerType]
		public ActionResult Index(int? 客戶分類Type, int page = 1)
		{
			int currentPage = page < 1 ? 1 : page;
			var data = 客戶資料Repo.FindCustomerType(客戶分類Type);
		    var pagedData = data.OrderBy(p => p.Id).ToPagedList(currentPage, pageSize: 1);
			return View(pagedData);
		}		

		// GET: CustomerInfo/Details/5
		public ActionResult Details(int id)
		{

			var data = 客戶資料Repo.Find(id);

			return View(data);
		}

		// GET: CustomerInfo/Create
		[DropDownListByCustmerType]
		public ActionResult Create()
		{
			return View();
		}

		// POST: CustomerInfo/Create
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		[DropDownListByCustmerType]
		public ActionResult Create(客戶資料 data)
		{
			if (ModelState.IsValid)
			{
				客戶資料Repo.Add(data);
				客戶資料Repo.UnitOfWork.Commit();
				return RedirectToAction("Index");
			}
			return View(data);
		}

		// GET: CustomerInfo/Edit/5
		[DropDownListByCustmerType]
		public ActionResult Edit(int id)
		{

			var data = 客戶資料Repo.Find(id);
			return View(data);
		}

		// POST: CustomerInfo/Edit/5
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		[DropDownListByCustmerType]
		public ActionResult Edit(int id, FormCollection formValue)
		{
			var item = 客戶資料Repo.Find(id);
			if (TryUpdateModel(item))
			{
				客戶資料Repo.UnitOfWork.Commit();
				return RedirectToAction("Index");
			}
			return View(item);
		}

		// GET: CustomerInfo/Delete/5
		public ActionResult Delete(int id)
		{

			var data = 客戶資料Repo.Find(id);
			客戶資料Repo.Delete(data);
			客戶資料Repo.UnitOfWork.Commit();

			return RedirectToAction("Index");
		}


		public ActionResult CountCustomerInfo()
		{
			var data = CustomerDataCountRepo.All();
			return View(data);
		}

		

		
	}
}
