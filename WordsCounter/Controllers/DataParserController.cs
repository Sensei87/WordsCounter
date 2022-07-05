using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WordsCounter.Models;
using WordsCounter.Repository;

namespace WordsCounter.Controllers
{
    public class DataParserController : Controller
    {
       
        IParser _parser;

        public DataParserController( IParser _parser)
        {
            this._parser = _parser;
           
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult RepetWords()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RepetWords(string reference)
        {
            var result = FindWords(reference, 1);

            return View("Result", result);
        }

        public IActionResult TwoWords()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TwoWords(string reference)
        {
            var result = FindWords(reference, 2);
            return View("Result", result);
        }

        public IActionResult ThreeWords()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThreeWords(string reference)
        {
            var result = FindWords(reference, 3);
            return View("Result", result);
        }

        public IActionResult Privacy()
        {

            return View("Privacy");
        }

        List<string> FindWords(string reference, int wordCount)
        {
            var list = _parser.Pars(reference);
            List<string> finalData = new List<string>();
            var result = new List<string>();
            string data = "";
            string percent = "";

            foreach (var n in list)
                data += n;

            switch (wordCount)
            {
                case 1:
                    {
                        finalData = _parser.OneMutchesOfWord(data);
                        break;
                    }
                case 2:
                    {
                        finalData = _parser.TwoMutchesOfWords(data);
                        break;
                    }
                case 3:
                    {
                        finalData = _parser.ThreeMutchesOfWords(data);
                        break;
                    }
                default:
                    {
                        finalData.Add("No mutches for your request!");
                        break;
                    }
            }

            foreach (var item in finalData)
            {
                percent += item;
                var rus = item.Split("\n");
                foreach (var i in rus)
                    result.Add(i);

            }
            return result;

        }
    }
}
