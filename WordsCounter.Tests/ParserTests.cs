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
            var text = "Every time you call the SaveChanges method, an implicit transaction is started so that if " +
                "something goes wrong, it would automatically roll back all the changes. If the multiple changes" +
                "within the transaction succeed, then the transaction and all changes are committed";

            var _parser = new Parser();
            var list = new List<string>();
            
            // Act
            var pars =_parser.Pars(text);
            pars.Add(text);
            list.Add(text);
            list.Sort();

            // Assert
            Assert.Equal(list, pars);
        }


    }
}
