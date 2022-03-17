using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XandaDeck.Core.Helpers;
using XandaDeck.Core.Services;
using XandaDeck.Data.Contexts;
using XandaDeck.Data.Models;

namespace XandaDeck.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly RecaptchaService _recaptchaService;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context,
            IConfiguration configuration,
            RecaptchaService recaptchaService,
            IWebHostEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _recaptchaService = recaptchaService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            Contact contact = new();

            ViewData["contact"] = contact;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([Bind("ContactId,DateAdded,Address,CompanyName,EmailAddress,FullNames,PhoneNumber,Message,Token")] Contact contact)
        {
            var pageName = "Contact Us";

            //await SetSessionAsync(pageName);

            ViewData["title"] = pageName;

            var verifiedRecaptcha = _recaptchaService.VerifyRecaptcha(contact.Token);

            if (!verifiedRecaptcha.Result.success && verifiedRecaptcha.Result.score <= 0.5)
            {
                ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                ViewBag.Message = "You failed the CAPTCHA!";
                return View(contact);
            }

            if (string.IsNullOrEmpty(contact.FullName))
            {
                ViewBag.Message = "Full name is required!";
                return View(contact);
            }

            if (string.IsNullOrEmpty(contact.CompanyName))
            {
                ViewBag.Message = "Your company name is required!";
                return View(contact);
            }

            if (string.IsNullOrEmpty(contact.Address))
            {
                ViewBag.Message = "Your address is required!";
                return View(contact);
            }

            if (!CommonHelper.IsValidEmail(contact.EmailAddress))
            {
                ViewBag.Message = "Invalid e-mail address!";
                return View(contact);
            }

            if (string.IsNullOrEmpty(contact.PhoneNumber) || !CommonHelper.IsNumeric(contact.PhoneNumber))
            {
                ViewBag.Message = "Phone number is invalid or not supplied!";
                return View(contact);
            }

            if (string.IsNullOrEmpty(contact.Message))
            {
                ViewBag.Message = "Empty message can't be sent!";
                return View(contact);
            }

            if (CommonHelper.IsValidEmail(contact.EmailAddress))
            {
                try
                {
                    _context.Add(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException /* ex */)
                {

                    ViewBag.Message = "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.";
                    return View();
                }

                ////string strPath = null;
                //var path = Path.Combine(_environment.WebRootPath, "templates");
                //var template = Path.Combine(path, "enquiry-notification.html");

                //var subject = "New Inquiry";
                //var date = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");

                //var builder = new StringBuilder();
                //using (StreamReader SourceReader = System.IO.File.OpenText(template))
                //{
                //    builder.Append(SourceReader.ReadToEnd());
                //}

                //string messageBody = string.Format(builder.ToString(),
                //    subject,
                //    contactView.FullName,
                //    contactView.Email,
                //    contactView.Phone,
                //    date,
                //    contactView.Message
                //    );

                //EmailRequest emailRequest = new EmailRequest
                //{
                //    RecieverEmailAddress = contactView.Email,
                //    Subject = subject,
                //    Body = messageBody
                //};

                //string result = _emailSender.SendEmailAsync(emailRequest);

                ViewBag.Success = "Your inquiry has been forwarded.";
                return RedirectToAction(nameof(Contact));
            }
            else
            {
                ViewBag.Message = "Invalid e-mail address!";
            }

            return View(contact);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Support([Bind("ContactId,DateAdded,Address,CompanyName,EmailAddress,FullNames,PhoneNumber,Message,Token")] SupportTicket supportTicket)
        {
            var pageName = "Contact Us";

            //await SetSessionAsync(pageName);

            ViewData["title"] = pageName;

            var verifiedRecaptcha = _recaptchaService.VerifyRecaptcha(supportTicket.Token);

            if (!verifiedRecaptcha.Result.success && verifiedRecaptcha.Result.score <= 0.5)
            {
                ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                ViewBag.Message = "You failed the CAPTCHA!";
                return View(supportTicket);
            }

            if (string.IsNullOrEmpty(supportTicket.FullName))
            {
                ViewBag.Message = "Full name is required!";
                return View(supportTicket);
            }

            if (string.IsNullOrEmpty(supportTicket.CompanyName))
            {
                ViewBag.Message = "Your company name is required!";
                return View(supportTicket);
            }

            if (string.IsNullOrEmpty(supportTicket.Address))
            {
                ViewBag.Message = "Your address is required!";
                return View(supportTicket);
            }

            if (!CommonHelper.IsValidEmail(supportTicket.EmailAddress))
            {
                ViewBag.Message = "Invalid e-mail address!";
                return View(supportTicket);
            }

            if (string.IsNullOrEmpty(supportTicket.PhoneNumber) || !CommonHelper.IsNumeric(supportTicket.PhoneNumber))
            {
                ViewBag.Message = "Phone number is invalid or not supplied!";
                return View(supportTicket);
            }

            if (string.IsNullOrEmpty(supportTicket.Message))
            {
                ViewBag.Message = "Empty message can't be sent!";
                return View(supportTicket);
            }

            if (CommonHelper.IsValidEmail(supportTicket.EmailAddress))
            {
                try
                {
                    _context.Add(supportTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException /* ex */)
                {

                    ViewBag.Message = "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.";
                    return View();
                }

                ////string strPath = null;
                //var path = Path.Combine(_environment.WebRootPath, "templates");
                //var template = Path.Combine(path, "inquiry-notification.html");

                //var subject = "New Inquiry";
                //var date = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");

                //var builder = new StringBuilder();
                //using (StreamReader SourceReader = System.IO.File.OpenText(template))
                //{
                //    builder.Append(SourceReader.ReadToEnd());
                //}

                //string messageBody = string.Format(builder.ToString(),
                //    subject,
                //    contactView.FullName,
                //    contactView.Email,
                //    contactView.Phone,
                //    date,
                //    contactView.Message
                //    );

                //EmailRequest emailRequest = new EmailRequest
                //{
                //    RecieverEmailAddress = contactView.Email,
                //    Subject = subject,
                //    Body = messageBody
                //};

                //string result = _emailSender.SendEmailAsync(emailRequest);

                ViewBag.Success = "Your inquiry has been forwarded.";
                return RedirectToAction(nameof(Contact));
            }
            else
            {
                ViewBag.Message = "Invalid e-mail address!";
            }

            return View(supportTicket);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Pricing()
        {
            return View();
        }

        public IActionResult Resources()
        {
            return View();
        }

        public IActionResult Support()
        {
            SupportTicket supportTicket = new();

            return View(supportTicket);
        }

        public async Task<IActionResult> Download(string fileName)
        {
            var pageName = "Resources";

            //await SetSessionAsync(pageName);

            ViewData["title"] = pageName;

            var path = Path.Combine(
                               _environment.WebRootPath, "resources", fileName);
            if (!System.IO.File.Exists(path))
            {
                return View();
            }
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, FileUploadService.GetContentType(path), Path.GetFileName(path));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
