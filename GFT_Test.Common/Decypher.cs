using GFT_Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFT_Test.Common
{
    public class Decypher
    {

        private static List<Base> baseList = null;

        private static List<List<Value>> valueList = null;

        private static List<string> cypherRowList = null;

        private static List<WordRules> wordRuleList = null;

        private static List<string> wordsToFind = null;

        private static List<Word> wordList = null;

        public void LoadJsonFiles()
        {
            try
            {
                baseList = ReadJsonFile.ReadBaseFile();

                valueList = ReadJsonFile.ReadValuesFile();

                cypherRowList = ReadJsonFile.ReadCypherFile();

                wordsToFind = ReadJsonFile.ReadWordsFile();
            }
            catch (Exception ex)
            {

            }
        }


        public void LoadRulesPerRow()
        {
            try
            {
                wordList = new List<Word>();

                foreach (var row in cypherRowList)
                {
                    int index = cypherRowList.IndexOf(row);
                    List<Value> valuesPerRow = valueList[index];
                    List<Rule> rulesPerRow = new List<Rule>();
                    foreach (var value in valuesPerRow)
                    {
                        Rule rule = new Rule()
                        {
                            order = value.order,
                            isTermination = value.isTermination,
                            source = baseList[value.rule].source,
                            replacement = baseList[value.rule].replacement
                        };
                        rulesPerRow.Add(rule);
                    }
                    rulesPerRow = rulesPerRow.OrderBy(r => r.order).ToList();
                    wordList.Add(new Word() { cypherWord = row, rulesPerWord = rulesPerRow });
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Puzzel GetsWordPuzzel()
        {
            try
            {
                LoadJsonFiles();

                LoadRulesPerRow();

                List<string> decypherRowList = new List<string>();

                foreach (var word in wordList)
                {
                    var temporalWord = word.cypherWord;
                    foreach (var rule in word.rulesPerWord)
                    {
                        if (temporalWord.Contains(rule.source))
                        {
                            temporalWord = temporalWord.Replace(rule.source, rule.replacement);
                            if (rule.isTermination)
                            {
                                break;
                            }
                        }
                    }

                    word.decypherWord = temporalWord;

                    char[] letterArray = new char[temporalWord.Length];

                    for (int i = 0; i < temporalWord.Length; i++)
                    {
                        letterArray[i] = temporalWord[i];
                    }

                    word.decypherRow = letterArray;
                    decypherRowList.Add(temporalWord); 
                }

                char[,] matrix = new char[wordList.Count, wordList.First().decypherRow.Length];

                int rowNumber = 0;
                foreach (var row in wordList)
                {
                    int columnNumber = 0;
                    foreach (var letter in row.decypherRow)
                    {
                        matrix[rowNumber, columnNumber] = letter;
                        columnNumber++;
                    }
                    rowNumber++;
                }

                Puzzel puzzel = new Puzzel();
                puzzel.matrix = matrix;
                puzzel.wordsToFind = wordsToFind;

                return puzzel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
