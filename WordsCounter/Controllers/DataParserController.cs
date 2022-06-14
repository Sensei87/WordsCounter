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

        [HttpPost]
        public IActionResult Index(string reference, int wordCount)
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

            return View("Result", result);
        }



    }
}
