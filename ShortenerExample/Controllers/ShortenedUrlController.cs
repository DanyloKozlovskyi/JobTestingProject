using Microsoft.AspNetCore.Mvc;
using ShortenerEntities;
using ShortenerExample.CustomModelBinders;
using ShortenerServiceContracts;
using ShortenerServiceContracts.DTO;
using System.IO;

namespace ShortenerExample.Controllers
{
    public class ShortenedUrlController : Controller
    {
        private readonly IShortenedUrlService _urlService;
        public User _user { get; set; } = new User()
        {

            UserId = new Guid("EA0075B4-E61D-48AF-86D8-6C931AA493DA"),
            UserName = "Ivan",
            Password = "abcdef1234"
        };
        // AddSingleton
        public ShortenedUrlController(IShortenedUrlService urlService)
        {
            _urlService = urlService;

        }
        [Route("/")]
        public async Task<IActionResult> Index(User? user)
        {
            _user = user;
            ViewBag.user = user;
            List<ShortenedUrlResponse> urls = await _urlService.GetAllUrls();
            return View(urls);
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.urlService = _urlService;

            return View();
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(ShortenedUrlAddRequest urlAddRequest)
        {
            ViewBag.user = _user;
            string[] p1 = urlAddRequest.LongUrl.Split("://");

            string code = string.Empty;

            for (int i = 0; i < p1.Length; i++)
            {
                string[] p2 = p1[i].Split(".");
                for (int j = 0; j < p2.Length; j++)
                {
                    if (p2[j].Length > 4)
                        code += p2[j].Substring(0, 4);
                    else
                        code += p2[j];

                    if (j != p2.Length - 1)
                        code += ".";
                }
                if (i != p1.Length - 1)
                    code += "://";
            }
            // code = code.Substring(0, code.Length - 4);
            urlAddRequest.Code = code;
            urlAddRequest.ShortUrl = urlAddRequest.Code;
            urlAddRequest.CreatedOnUtc = DateTime.UtcNow;
            urlAddRequest.UserId = ViewBag.user.UserId;
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).
                    Select(e => e.ErrorMessage).ToList();
                return View("Create");
            }
            ShortenedUrlResponse urlResponse = await _urlService.AddUrl(urlAddRequest);

            return RedirectToAction("Index", _user);
        }
        [HttpGet]
        [Route("[action]/{urlId}")]
        public async Task<IActionResult> Delete(Guid? urlId)
        {
            ShortenedUrlResponse? personResponse = await
                _urlService.GetUrlByUrlId(urlId);
            if (personResponse == null)
            {
                return RedirectToAction("Index", _user);
            }
            return View(personResponse.ToShortenedUrlUpdateRequest());
        }
        [HttpPost]
        [Route("[action]/{urlId}")]
        public async Task<IActionResult> Delete(ShortenedUrlUpdateRequest urlUpdateRequest)
        {
            ShortenedUrlResponse? urlResponse = await
                _urlService.GetUrlByUrlId(urlUpdateRequest.Id);
            if (urlResponse != null)
            {
                await _urlService.DeleteUrl(urlUpdateRequest.Id);
            }
            return RedirectToAction("Index", _user);
        }
        [Route("[action]")]
        public async Task<IActionResult> ShortUrlInfo(Guid? urlId)
        {
            ViewBag.user = _user;
            ShortenedUrlResponse url = await _urlService.GetUrlByUrlId(urlId);
            return View(url);
        }
    }
}
