﻿using FoodWebMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodWebMVC.Views.Home.Components.SingleBannerComponent;

public class SingleBannerComponent : ViewComponent
{
	private readonly IBannerRepository _repo;

	public SingleBannerComponent(IBannerRepository repo)
	{
		_repo = repo;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var obj = await _repo.GetByIdAsync(6);
		return View("SingleBannerComponent", obj);
	}
}