using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsCounter.Models
{
    public interface IParser
    {
        List<string> Pars(string data);
        List<string> OneMutchesOfWord(string text);
        List<string> TwoMutchesOfWords(string text);
        List<string> ThreeMutchesOfWords(string text);


    }
}
