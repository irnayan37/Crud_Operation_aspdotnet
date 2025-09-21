using Demo.Web.Models;
using Demo.Web.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IEmailUtililty _emailUtility;
        public TestController([FromKeyedServices("Setup1")] IEmailUtililty emailutility)
        {
            _emailUtility = emailutility;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Demo(DemoModel model)
        {

            _emailUtility.SendEmail(model.Email, "Welcome", "Welcome to our Website");

            return View(model);
        }
    }
}
/* 
 Dependency Injection কী?

Dependency Injection মানে হচ্ছে,
একটা class যদি অন্য কোনো class-এর উপরে নির্ভর করে, সেই নির্ভরশীলতা (dependency) আমরা 
সরাসরি new keyword দিয়ে না বানিয়ে বাইরে থেকে inject করে দিবো।
ASP.NET Core framework এ DI built-in ভাবে আছে।

🔹 কেন দরকার?

Loose Coupling → কোড maintain করা সহজ হয়।

Testability → Unit Test করার সময় mock dependency ব্যবহার করা যায়।

Reusability → একই service আলাদা জায়গায় ব্যবহার করা যায়।

🔹 ASP.NET Core এ কিভাবে কাজ করে?

ASP.NET Core এ DI container আছে (যাকে IoC Container বলে)। এই container এর মধ্যে dependency
গুলো register করতে হয়। তারপর যেই class সেই dependency চাইবে, framework automatically constructor 
এর মাধ্যমে inject করে দেবে।
 */