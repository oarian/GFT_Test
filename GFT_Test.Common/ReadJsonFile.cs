using GFT_Test.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFT_Test.Common
{
    public static class ReadJsonFile
    {

        public static List<Base> ReadBaseFile()
        {
            List<Base> baseList = null;

            var baseFile = Encoding.ASCII.GetString(ResourceFiles._base);
            baseList = JsonConvert.DeserializeObject<List<Base>>(baseFile);

            return baseList;
        }

        public static List<List<Value>> ReadValuesFile()
        {
            List<List<Value>> valueList = null;

            var valueFile = Encoding.ASCII.GetString(ResourceFiles.values);
            valueList = JsonConvert.DeserializeObject<List<List<Value>>>(valueFile);

            return valueList;
        }

        public static List<string> ReadCypherFile()
        {
            List<string> cypherRowList = null;

            var cypherFile = Encoding.ASCII.GetString(ResourceFiles.cypher);
            cypherRowList = JsonConvert.DeserializeObject<List<string>>(cypherFile);

            return cypherRowList;
        }

        public static List<string> ReadWordsFile()
        {
            List<string> wordList = null;

            var wordsFile = Encoding.ASCII.GetString(ResourceFiles.words);
            wordList = JsonConvert.DeserializeObject<List<string>>(wordsFile);

            return wordList;
        }
    }
}
