using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WordsCounter.Models;

namespace WordsCounter.Controllers
{
    public class DataParserController : Controller
    {
        DataParser dataParser = new DataParser();
        IParser parser = new Parser();

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(string reference, int wordCount)
        {

            var list = parser.Pars(reference);
            List<string> finalData = new List<string>();

            foreach (var n in list)
                dataParser.Data += n;

            switch (wordCount)
            {
                case 1:
                    {
                        finalData = parser.OneMutchesOfWord(dataParser.Data);
                        break;
                    }
                case 2:
                    {
                        finalData = parser.TwoMutchesOfWords(dataParser.Data);
                        break;
                    }
                case 3:
                    {
                        finalData = parser.ThreeMutchesOfWords(dataParser.Data);
                        break;
                    }
                default:
                    {
                        finalData.Add("No mutches for your request!");
                        break;
                    }
            }

            foreach(var item in finalData)
            {
                dataParser.Percent += item;
               
            }
            
            return Content(dataParser.Percent);
        }



    }
}
