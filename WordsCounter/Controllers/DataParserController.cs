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
            var linqQuery = from tree in list where tree.Length == wordCount select tree;
           
           
            foreach (var item in linqQuery)
            {
                dataParser.Data += "\n " + item;
            }
            string data = dataParser.Data;
            var finalData = parser.NumberOfWords(data);
            foreach(var item in finalData)
            {
                dataParser.Percent += "\n " + item + " words";
               
            }
                  
            var dataFinal =  dataParser.Percent;
            return Content(dataFinal);
        }



    }
}
