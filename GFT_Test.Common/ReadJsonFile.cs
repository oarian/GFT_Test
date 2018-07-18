using GFT_Test.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace GFT_Test.Common
{
    public static class ReadJsonFile
    {
        
        public static List<Base> ReadBaseFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = "GFT_Test.Common.Resources.base.json";

            List<Base> baseList = null;
            string baseFile = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                baseFile = reader.ReadToEnd();
            }

            baseList = JsonConvert.DeserializeObject<List<Base>>(baseFile);

            return baseList;
        }

        public static List<List<Value>> ReadValuesFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = "GFT_Test.Common.Resources.values.json";

            List<List<Value>> valueList = null;
            string valuesFile = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                valuesFile = reader.ReadToEnd();
            }

            valueList = JsonConvert.DeserializeObject<List<List<Value>>>(valuesFile);

            return valueList;
        }

        public static List<string> ReadCypherFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = "GFT_Test.Common.Resources.cypher.json";

            List<string> cypherRowList = null;
            string cypherFile = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                cypherFile = reader.ReadToEnd();
            }

            cypherRowList = JsonConvert.DeserializeObject<List<string>>(cypherFile);

            return cypherRowList;
        }

        public static List<string> ReadWordsFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = "GFT_Test.Common.Resources.words.json";

            List<string> wordList = null;
            string wordsFile = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                wordsFile = reader.ReadToEnd();
            }
            
            wordList = JsonConvert.DeserializeObject<List<string>>(wordsFile);

            return wordList;
        }
    }
}
