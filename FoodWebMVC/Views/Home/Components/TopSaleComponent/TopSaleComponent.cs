﻿using FoodWebMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodWebMVC.Views.Home.Components.TopSaleComponent;

public class TopSaleComponent : ViewComponent
{
	private readonly IProductRepository _repo;

	public TopSaleComponent(IProductRepository repo)
	{
		_repo = repo;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var obj = await _repo.GetListAsync(x => x.ProductDiscount > 0, x => x.OrderByDescending(x => x.ProductId),
			take: 8);
		return View("TopSaleComponent", obj);
	}
}