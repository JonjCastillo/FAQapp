using FAQapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FAQapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private QuestionContext ctx { get; set; }
        public HomeController(ILogger<HomeController> logger, QuestionContext context)
        {
            _logger = logger;
            ctx = context;
        }


        //public IActionResult HistoryCategory()
        //{
        //    var questions = ctx.Questions.Where(q => q.Category == "History").OrderBy(q => q.QuestionText).ToList();
        //    return View("Index", questions);
        //}

        //public IActionResult BStopic()
        //{
        //    var questions = ctx.Questions.Where(q => q.Topic == "Bootstrap").OrderBy(q => q.QuestionText).ToList();
        //    return View("Index", questions);
        //}

        //public IActionResult CSharpTopic()
        //{
        //    var questions = ctx.Questions.Where(q => q.Topic == "C#").OrderBy(q => q.QuestionText).ToList();
        //    return View("Index", questions);
        //}

        //public IActionResult JavaScriptTopic()
        //{
        //    var questions = ctx.Questions.Where(q => q.Topic == "JavaScript").OrderBy(q => q.QuestionText).ToList();
        //    return View("Index", questions);
        //}

        public IActionResult Index()
        {
            var questions = ctx.Questions.OrderBy(q => q.QuestionText).ToList();
            return View(questions);
        }

        //public IActionResult GeneralCategory()
        //{
        //    var questions = ctx.Questions.Where(q => q.Category == "General").OrderBy(q => q.QuestionText).ToList();
        //    return View("Index", questions);
        //}

        private List<Question> GetQuestionsByCategory(string category)
        {
            var questions = ctx.Questions.Where(q => q.Category!.ToLower() == category).OrderBy(q => q.QuestionText).ToList();
            return questions;
        }

        [Route("Home/category/{category}")]
        public IActionResult Category( string category ) {
            var questions = GetQuestionsByCategory(category);
            ViewData["Category"] = category;
            return View("Index", questions);
        }
        
        [Route("Home/category/{category}/topic/{topic}")]
        public IActionResult CategoryWithTopic( string category, string topic) {
            var questionsByCat = GetQuestionsByCategory(category);
            var questions = questionsByCat.Where(q => q.Topic?.ToLower() == topic).OrderBy(q => q.QuestionText).ToList();
            ViewData["Category"] = category;
            ViewData["Topic"] = topic;
            return View("Index", questions);
        }

        [Route("Home/topic/{topic}")]

        public IActionResult Topic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                return RedirectToAction("Index");
            }
            //var questions = GetQuestionsByTopic(topic);
            var questions = ctx.Questions.Where(q => q.Topic!.ToLower() == topic).OrderBy(q => q.QuestionText).ToList();

            ViewData["Topic"] = topic;
            return View("Index", questions);
        }

        [Route("Home/topic/{topic}/category/{category}")]
        public IActionResult TopicWithCategory(string topic, string category)
        {
            if (string.IsNullOrEmpty(topic))
            {
                return RedirectToAction("Index");
            }
            var questionsByCat = GetQuestionsByCategory(category);
            var questions = questionsByCat.Where(q => q.Topic?.ToLower() == topic).ToList();
            ViewData["Topic"] = topic;
            ViewData["Category"] = category;
            return View("Index", questions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
