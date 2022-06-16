

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;

namespace WordsCounter.Repository
{
     class ParsOnlyText : IParsOnlyText
    {


        public List<string> ParsTexts(string data)
        {
            var parser = new Parser();
            List<string> list = new List<string>();
            try
            {
                WebClient client = new WebClient();
                byte[] raw = client.DownloadData(data);
                string webData = System.Text.Encoding.UTF8.GetString(raw);
                var document = new HtmlDocument();
                document.LoadHtml(webData);
                var pageText = document.DocumentNode.InnerText;

                if (!String.IsNullOrEmpty(pageText))
                {
                    var match = parser.TagsUsingRegex(pageText);

                    list.Add(match);
                }
               

            } catch(Exception ex)
            {
                ex.GetType();
            }


            return list;
        }

    }
}
