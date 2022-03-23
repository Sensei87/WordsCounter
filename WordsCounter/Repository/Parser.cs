using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;


namespace WordsCounter.Repository
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
                if (!String.IsNullOrEmpty(pageText))
                {
                    var match = TagsUsingRegex(pageText).ToLower();

                    string[] splitArray = match.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string[] articles = { "an", "the", "is", "in", "at", "-", "&", "?", "|" };
                    for (int i = 0; i < splitArray.Length; i++)
                    {
                        for (int j = 0; j < articles.Length; j++)
                        {
                            if (articles[j] == splitArray[i])
                            {
                                match = match.Replace(splitArray[i], "");
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
            string? result = "";
            if (text == null)
            {
                result = "The reference is null!";
                list.Add(result);
                return list;
            }
            try
            {
                string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                var finalPercent = 0.0;
                int counter = 1;
                for (int i = 0; i < source.Length; i++)
                {
                    var match = from word in source
                                where word
            .ToLowerInvariant() == source[i].ToLowerInvariant()
                                select word;
                    finalPercent = match.Count() * 100.0 / source.Length;
                    finalPercent = Math.Round(finalPercent, 2);
                    result += "\n " + counter + ". " + source[i] + " [" + match.Count() + " words] (" + finalPercent + " %)";
                    counter++;
                }

            }
            catch (Exception ex)
            {
                result += ex.Message;
            }
            list.Add(result);
            return list;
        }

        // Count mutches two words
        public List<string> TwoMutchesOfWords(string text)
        {
            var list = new List<string>();
            string? result = "";
            if (text == null)
            {
                result = "The reference is null!";
                list.Add(result);
                return list;
            }
            try
            {
                string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                  StringSplitOptions.RemoveEmptyEntries);

                string sourceOne = "";

                for (int i = 0; i < source.Length / 2; i++)
                {

                    if (i % 2 == 0)
                    {
                        sourceOne += string.Join("  ", source[i] += " " + source[i + 1] + ",");

                    }

                }
                result = ReturnPercents(sourceOne);

            }
            catch (Exception ex)
            {
                result += ex.Message;
            }
            list.Add(result);
            return list;
        }

        // Count mutches three words
        public List<string> ThreeMutchesOfWords(string text)
        {
            var list = new List<string>();
            string? result = "";
            if (text == null)
            {
                result = "The reference is null!";
                list.Add(result);
                return list;
            }
            try
            {

                string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                  StringSplitOptions.RemoveEmptyEntries);

                string sourceOne = "";

                for (int i = 0; i < source.Length / 2 + 1; i++)
                {
                    if (i % 3 == 0)
                    {
                        sourceOne += string.Join("  ", source[i] += " " + source[i + 1] + " " + source[i + 2] + ",");

                    }

                }
                result = ReturnPercents(sourceOne);
            }
            catch (Exception ex)
            {
                result += ex.Message;
            }
            list.Add(result);
            return list;
        }

        // Find percent 
        string ReturnPercents(string source)
        {
            string[] subString = source.Split(",");
            string? result = "";
            var finalPercent = 0.0;
            int counter = 1;
            for (int i = 0; i < subString.Length; i++)
            {
                var match = from word in subString
                            where word
        .ToLowerInvariant() == subString[i].ToLowerInvariant()
                            select word;
                finalPercent = match.Count() * 100.0 / subString.Length;
                finalPercent = Math.Round(finalPercent, 2);
                result += "\n " + counter + ". " + subString[i] +
                    " [" + match.Count() + " words] (" + finalPercent + " %)";
                counter++;
            }

            return result;
        }



    }
}
