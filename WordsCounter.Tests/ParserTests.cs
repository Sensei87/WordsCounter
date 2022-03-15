using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsCounter.Models;
using Xunit;

namespace WordsCounter.Tests
{
   public class ParserTests
    {
        [Fact]
        public void CheckPars()
        {
            // Arrange
            var text = "Split PDF document online is a web service that allows you to" +
                " split your PDF document into separate pages. This simple application" +
                " has several modes of operation, you can split your PDF document into separate pages," +
                " i.e. each page of the original document will be a separate PDF document," +
                " you can split your document into even and odd pages, this function will " +
                "come in handy if you need to print a document in the form of a book, " +
                "you can also specify page numbers in the settings and the Split PDF" +
                " application will create separate PDF documents only with these pages" +
                " and the fourth mode of operation allows you to create a new PDF document " +
                "in which there will be only those pages that you specified";

            var _parser = new Parser();
            var list = new List<string>();
            
            // Act
            var pars =_parser.Pars(text);
            pars.Add(text);
            list.Add(text);
            

            // Assert
            Assert.Equal(list, pars);
        }
        
        [Fact]
        public void CheckOneNumbers()
        {
            // Arrange
            var text = "Split PDF document online is a web service that allows you to" +
                " split your PDF document into separate pages. This simple application" +
                " has several modes of operation, you can split your PDF document into separate pages," +
                " i.e. each page of the original document will be a separate PDF document," +
                " you can split your document into even and odd pages, this function will " +
                "come in handy if you need to print a document in the form of a book, " +
                "you can also specify page numbers in the settings and the Split PDF" +
                " application will create separate PDF documents only with these pages" +
                " and the fourth mode of operation allows you to create a new PDF document " +
                "in which there will be only those pages that you specified"; 

            var _parser = new Parser();
            var list = new List<string>();

            // Act
            var oneNumber = _parser.OneMutchesOfWord(text);
            var result = "";
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
            list.Add(result);

            // Arrange
            Assert.Equal(list, oneNumber);




        }



    }
}
