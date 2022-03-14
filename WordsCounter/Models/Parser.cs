using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;


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
                    var match = TagsUsingRegex(pageText).ToLower();
                   
                    string[] s = match.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                    string[] articles = {"an", "the", "is", "in", "at" , "-", "&", "?", "|" };
                    for(int i = 0; i < s.Length; i++)
                    {
                        for(int j = 0; j < articles.Length; j++)
                        {
                            if(articles[j] == s[i])
                            {
                                match = match.Replace(s[i], "");
                            }
                        }
                    }
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

        // Count mutches one words
        public List<string> OneMutchesOfWord(string text)
        {
            
            var list = new List<string>();
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            var finalPercent = 0.0;
            for (int i = 0; i < source.Length-1; i++)
            {
                var match = from word in source where word
                            .ToLowerInvariant() == source[i].ToLowerInvariant() select word;
                finalPercent = match.Count() * 100.0 / source.Length;
                finalPercent = Math.Round(finalPercent, 2);
                result += "\n "+ i + ". " + source[i] + " [ " + match.Count() + " words.] (" + finalPercent + " %)";
               
            }
            list.Add(result);

            return list;
        }

        // Count mutches two words
        public List<string> TwoMutchesOfWords(string text)
        {
            var list = new List<string>();
            return list;
        }

        // Count mutches three words
        public List<string> ThreeMutchesOfWords(string text)
        {
            var list = new List<string>();
            return list;
        }



    }
}
