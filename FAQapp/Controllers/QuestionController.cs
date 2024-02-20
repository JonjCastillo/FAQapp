using System.Linq;
using FAQapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace FAQapp.Controllers
{
    public class QuestionController : Controller
    {
        private QuestionContext context { get; set; }

        public QuestionController(QuestionContext ctx)
        {
            context = ctx;
        }

        
    }
}
