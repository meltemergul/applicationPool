using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using applicationPool.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace applicationPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private static readonly List<QuoteModel> Quotes = new List<QuoteModel>
        {
            new QuoteModel { Quote = "Life is what happens when you're busy making other plans.", Author = "John Lennon" },
            new QuoteModel { Quote = "The purpose of our lives is to be happy.", Author = "Dalai Lama" },
            new QuoteModel { Quote = "Get busy living or get busy dying.", Author = "Stephen King" },
            new QuoteModel { Quote = "You only live once, but if you do it right, once is enough.", Author = "Mae West" },
            new QuoteModel { Quote = "In three words I can sum up everything I've learned about life: it goes on.", Author = "Robert Frost" },
            new QuoteModel { Quote = "To live is the rarest thing in the world. Most people exist, that is all.", Author = "Oscar Wilde" },
            new QuoteModel { Quote = "Good friends, good books, and a sleepy conscience: this is the ideal life.", Author = "Mark Twain" },
            new QuoteModel { Quote = "Life is what we make it, always has been, always will be.", Author = "Grandma Moses" },
            new QuoteModel { Quote = "In the end, it's not the years in your life that count. It's the life in your years.", Author = "Abraham Lincoln" },
            new QuoteModel { Quote = "Success is not final, failure is not fatal: It is the courage to continue that counts.", Author = "Winston S. Churchill" },
            new QuoteModel { Quote = "You have within you right now, everything you need to deal with whatever the world can throw at you.", Author = "Brian Tracy" },
            new QuoteModel { Quote = "Believe you can and you're halfway there.", Author = "Theodore Roosevelt" },
            new QuoteModel { Quote = "The only impossible journey is the one you never begin.", Author = "Tony Robbins" },
            new QuoteModel { Quote = "Life is really simple, but we insist on making it complicated.", Author = "Confucius" },
            new QuoteModel { Quote = "May you live all the days of your life.", Author = "Jonathan Swift" }
        };

        [HttpGet]
        public ActionResult<QuoteModel> GetRandomQuote()
        {
            var random = new Random();
            int index = random.Next(Quotes.Count);
            return Quotes[index];
        }
    }
}

