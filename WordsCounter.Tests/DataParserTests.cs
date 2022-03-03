using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsCounter.Models;
using Xunit;

namespace WordsCounter.Tests
{
   public class DataParserTests
    {
        
        
        [Fact]
        public void CheckData()
        {
            // Arrange
            var _dataParser = new DataParser {Data = "one, two, three, fifteen", Percent = "2 2 1 4 3" };

            // Act
            _dataParser.Percent = "2 2 1 5 3";

            // Assert
            Assert.Equal("2 2 1 5 3", _dataParser.Percent);
            Assert.Equal("one, two, three, fifteen", _dataParser.Data);


        }
    }
}
