using Business.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		private readonly IMessageService _messageService;

		public ContactController(IContactService contactService, IMessageService messageService)
		{
			_contactService = contactService;
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(MessageDTO p)
		{
			p.CreateDate= DateTime.Now;	
			_messageService.Insert(p);
			return RedirectToAction("Index","Home");
		}
	}
}
