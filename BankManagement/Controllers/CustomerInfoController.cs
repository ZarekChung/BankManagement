using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankManagement.ActionFilters;
using BankManagement.Models;

namespace BankManagement.Controllers
{
	public class CustomerInfoController : BaseController
	{
		// GET: CustomerInfo
		public ActionResult Index()
		{
			return View(客戶資料Repo.All());
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
			/*
			var CustomerTypeList = (from p in 客戶分類Repo.All()
				select new
				{
					Value = p.Id,
					Text = p.客戶分類名稱
				}).OrderBy(p => p.Value);
			ViewBag.客戶分類Type = new SelectList(CustomerTypeList, "Value", "Text");
			*/
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
			/*
			var CustomerTypeList = (from p in 客戶分類Repo.All()
				select new
				{
					Value = p.Id,
					Text = p.客戶分類名稱
				}).OrderBy(p => p.Value);
			ViewBag.客戶分類Type = new SelectList(CustomerTypeList, "Value", "Text");

			*/
			return View(data);
		}

		// GET: CustomerInfo/Edit/5
		[DropDownListByCustmerType]
		public ActionResult Edit(int id)
		{

			var data = 客戶資料Repo.Find(id);
			/*
			var CustomerTypeList = (from p in 客戶分類Repo.All()
				select new
				{
					Value = p.Id,
					Text = p.客戶分類名稱
				}).OrderBy(p => p.Value);
			ViewBag.客戶分類Type = new SelectList(CustomerTypeList, "Value", "Text");
			*/
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
			/*
			if (ModelState.IsValid)
			{
				
				if (UpdateAllData(item,null,null, formValue))
				{
					客戶資料Repo.UnitOfWork.Commit();
					return RedirectToAction("Index");
				}	
			}
			*/
			/*
			var CustomerTypeList = (from p in 客戶分類Repo.All()
				select new
				{
					Value = p.Id,
					Text = p.客戶分類名稱
				}).OrderBy(p => p.Value);
			ViewBag.客戶分類Type = new SelectList(CustomerTypeList, "Value", "Text");
			*/
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

		

		
	}
}
