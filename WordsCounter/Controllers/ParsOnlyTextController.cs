using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WordsCounter.Repository;

namespace WordsCounter.Controllers
{
    public class ParsOnlyTextController : Controller
    {
        IParsOnlyText _text;

        public ParsOnlyTextController(IParsOnlyText text)
        {
            this._text = text;
        }
      
        public IActionResult Text()
        {
           

            return View();
        }

        [HttpPost]
        public IActionResult Text(string reference)
        {
          
            var list = _text.ParsTexts(reference);
            if (list.Count < 1)
            {
                list.Add("Website not parsed");
            }

            return View("ResultText", list);
        }
    }
}
