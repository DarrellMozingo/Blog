﻿using System.Web.Mvc;
using JTemplates.Models;

namespace JTemplates.Controllers
{
	public class JTemplatesController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult LookupPeopleByZip(string zip)
		{
			return Json(Person.GetMatches(zip));
		}
	}
}