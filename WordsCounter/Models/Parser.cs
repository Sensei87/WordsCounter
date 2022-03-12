using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;


namespace WordsCounter.Models
{
    public class Parser : IParser
    {
        // Main Parser
        public List<string> Pars(string data)
        {
            List<string> list = new List<string>();
            try
            {
                WebClient client = new WebClient();
                byte[] raw = client.DownloadData(data);
                string webData = System.Text.Encoding.UTF8.GetString(raw);
                var document = new HtmlDocument();
                document.LoadHtml(webData);
                var pageText = document.DocumentNode.InnerText;
                if(!String.IsNullOrEmpty(pageText))
                {
                    var match = TagsUsingRegex(pageText);
                   
                    list.Add(match);
                    
                }

            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
           
            return list;

        }
        // Regex pattern
        string TagsUsingRegex(string inputString) =>
         Regex.Replace(inputString, @"\s+", " ");

        // Count number of words
        public List<string> NumberOfWords(string text)
        {
            var sorted = new SortedList<string, int>(StringComparer.OrdinalIgnoreCase);
            var list = new List<string>();
            if (text == null)
            {
                list.Add("No match for your request");
                return list;
            }
            foreach (var item in text.Split())
            {
                if (sorted.ContainsKey(item))
                {
                    sorted[item]++;
                }
                else
                {
                    sorted.Add(item, 1);
                }
                
            }
            int[] counter = new int[sorted.Capacity];
            int index = 0;
            var finalPercent = 0M;
            foreach (var item in sorted)
            {
                if (item.Value == 0 || item.Value > 10) continue;
                counter[index] += item.Value;
                finalPercent = counter[index] * 100M / sorted.Capacity;
                index++;
               
                list.Add(finalPercent + "%  " + item.Key + "  " + item.Value);
               
            }

            return list;
        }

        
    }
}
