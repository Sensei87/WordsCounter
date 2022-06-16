using System.Collections.Generic;

namespace WordsCounter.Repository
{
    public interface IParsOnlyText
    {

        List<string> ParsTexts(string data);

    }
}
