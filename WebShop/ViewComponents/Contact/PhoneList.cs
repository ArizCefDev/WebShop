using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.ViewComponents.Contact
{
	public class PhoneList : ViewComponent
	{
		private readonly IContactService _contactService;

		public PhoneList(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _contactService.GetAll();
			return View(values.Take(1));
		}
	}
}
