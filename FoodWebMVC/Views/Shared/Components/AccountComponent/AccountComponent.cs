﻿using Microsoft.AspNetCore.Mvc;

namespace FoodWebMVC.Views.Shared.Components.AccountComponent;

public class AccountComponent : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}