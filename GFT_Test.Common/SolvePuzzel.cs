using GFT_Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFT_Test.Common
{
    public class SolvePuzzel
    {

        private List<PuzzelSolution> puzzelSolutions = new List<PuzzelSolution>();

        public List<PuzzelSolution> FindWords(char[,] matrix)
        {
            try
            {
                List<string> wordsToFind = ReadJsonFile.ReadWordsFile();
                int rows = matrix.GetLength(0);
                int columns = matrix.GetLength(1);

                foreach (var word in wordsToFind)
                {
                    var wordLength = word.Length;
                    var firstLetter = word[0];

                    bool foundWord = false;

                    for (int x = 0; x < rows; x++)
                    {
                        for (int y = 0; y < columns; y++)
                        {
                            if (firstLetter == matrix[x, y])
                            {
                                foundWord = FindWordHorizontal(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordVertical(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordDiagonal(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordDiagonalLeft(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordHorizontalB(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordVerticalB(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordDiagonalB(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordDiagonalLeftB(matrix, word, x, y);

                                if (!foundWord)
                                    foundWord = FindWordAnyDirection(matrix, word, x, y);
                            }

                            if (foundWord)
                                break;
                        }
                        if (foundWord)
                            break;
                    }
                }

                return puzzelSolutions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool FindWordHorizontal(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var columnMax = columnBase + wordLength;

                if (columnMax <= matrix.GetLength(1))
                {
                    var temporalWord = string.Empty;

                    for (int y = columnBase; y < columnMax; y++)
                    {
                        temporalWord += matrix[rowBase, y];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int y = columnBase; y < columnMax; y++)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[rowBase, y].ToString(),
                                row = rowBase,
                                column = y
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool FindWordHorizontalB(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var columnMin = columnBase - wordLength;

                if (columnMin >= 0)
                {
                    var temporalWord = string.Empty;

                    for (int y = columnBase; y > columnMin; y--)
                    {
                        temporalWord += matrix[rowBase, y];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int y = columnBase; y > columnMin; y--)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[rowBase, y].ToString(),
                                row = rowBase,
                                column = y
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool FindWordVertical(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var rowMax = rowBase + wordLength;

                if (rowMax <= matrix.GetLength(0))
                {
                    var temporalWord = string.Empty;

                    for (int x = rowBase; x < rowMax; x++)
                    {
                        temporalWord += matrix[x, columnBase];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int x = rowBase; x < rowMax; x++)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[x, columnBase].ToString(),
                                row = x,
                                column = columnBase
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool FindWordVerticalB(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var rowMin = rowBase - wordLength;

                if (rowMin >= 0)
                {
                    var temporalWord = string.Empty;

                    for (int x = rowBase; x > rowMin; x--)
                    {
                        temporalWord += matrix[x, columnBase];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int x = rowBase; x > rowMin; x--)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[x, columnBase].ToString(),
                                row = x,
                                column = columnBase
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool FindWordDiagonal(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var rowMax = rowBase + wordLength;
                var columnMax = columnBase + wordLength;
                if (rowMax <= matrix.GetLength(0) && columnMax <= matrix.GetLength(1))
                {
                    var temporalWord = string.Empty;

                    for (int i = 0; i < wordLength; i++)
                    {
                        temporalWord += matrix[rowBase + i, columnBase + i];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int i = 0; i < wordLength; i++)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[rowBase + i, columnBase + i].ToString(),
                                row = rowBase + i,
                                column = columnBase + i
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        private bool FindWordDiagonalB(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var rowMax = rowBase - wordLength;
                var columnMax = columnBase - wordLength;
                if (rowMax >= 0 && columnMax >= 0)
                {
                    var temporalWord = string.Empty;

                    for (int i = 0; i < wordLength; i--)
                    {
                        temporalWord += matrix[rowBase - i, columnBase - i];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int i = 0; i > wordLength; i--)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[rowBase - i, columnBase - i].ToString(),
                                row = rowBase - i,
                                column = columnBase - i
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool FindWordDiagonalLeft(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var rowMax = rowBase + wordLength;
                var columnMax = columnBase + wordLength;
                if (rowMax <= matrix.GetLength(0) && columnMax <= matrix.GetLength(1))
                {
                    var temporalWord = string.Empty;

                    for (int i = 0; i < wordLength; i++)
                    {
                        temporalWord += matrix[rowBase + i, columnBase - i];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int i = 0; i < wordLength; i++)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[rowBase + i, columnBase - i].ToString(),
                                row = rowBase + i,
                                column = columnBase - i
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool FindWordDiagonalLeftB(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var rowMax = rowBase - wordLength;
                var columnMax = columnBase + wordLength;
                if (rowMax >= 0 && columnMax <= matrix.GetLength(1))
                {
                    var temporalWord = string.Empty;

                    for (int i = 0; i < wordLength; i++)
                    {
                        temporalWord += matrix[rowBase - i, columnBase + i];
                    }

                    if (word == temporalWord)
                    {
                        PuzzelSolution solution = new PuzzelSolution();
                        solution.word = word;
                        for (int i = 0; i < wordLength; i++)
                        {
                            Breakdown breakdown = new Breakdown()
                            {
                                character = matrix[rowBase - i, columnBase + i].ToString(),
                                row = rowBase - i,
                                column = columnBase + i
                            };
                            solution.breakdown.Add(breakdown);
                        }

                        puzzelSolutions.Add(solution);

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool FindWordAnyDirection(char[,] matrix, string word, int rowBase, int columnBase)
        {
            try
            {
                var wordLength = word.Length;
                var rowMax = matrix.GetLength(0);
                var columnMax = matrix.GetLength(1);

                var temporalWord = string.Empty;
                temporalWord += matrix[rowBase, columnBase];

                bool isValidLetter = false;
                var lastRow = rowBase;
                var lastColumn = columnBase;

                PuzzelSolution solution = new PuzzelSolution();
                solution.word = word;
                Breakdown breakdown = new Breakdown()
                {
                    character = matrix[lastRow, lastColumn].ToString(),
                    row = lastRow,
                    column = lastColumn
                };
                solution.breakdown.Add(breakdown);

                for (int i = 1; i < wordLength; i++)
                {
                    string t = temporalWord;

                    //Validate next column
                    if (lastColumn + 1 < columnMax)
                    {
                        t += matrix[lastRow, lastColumn + 1];
                        if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow && b.column == lastColumn + 1).Count() == 0)
                        {
                            isValidLetter = true;
                            lastColumn += 1;
                        }
                    }
                    
                    //Validate next row
                    if (!isValidLetter)
                    {
                        if (lastRow + 1 < rowMax)
                        {
                            t = temporalWord;
                            t += matrix[lastRow + 1, lastColumn];
                            if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow + 1 && b.column == lastColumn).Count() == 0)
                            {
                                isValidLetter = true;
                                lastRow += 1;
                            }
                        }   
                    }

                    //Validate diagonal down
                    if (!isValidLetter)
                    {
                        if (lastRow + 1 < rowMax && lastColumn + 1 < columnMax)
                        {
                            t = temporalWord;
                            t += matrix[lastRow + 1, lastColumn + 1];
                            if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow + 1 && b.column == lastColumn + 1).Count() == 0)
                            {
                                isValidLetter = true;
                                lastRow += 1;
                                lastColumn += 1;
                            }
                        }
                    }

                    //Validate diagonal down left
                    if (!isValidLetter)
                    {
                        if (lastRow + 1 < rowMax && lastColumn - 1 >= 0)
                        {
                            t = temporalWord;
                            t += matrix[lastRow + 1, lastColumn - 1];
                            if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow + 1 && b.column == lastColumn - 1).Count() == 0)
                            {
                                isValidLetter = true;
                                lastRow += 1;
                                lastColumn -= 1;
                            }
                        }
                    }

                    //Validate diagonal up
                    if (!isValidLetter)
                    {
                        if (lastRow - 1 >= 0 && lastColumn + 1 < columnMax)
                        {
                            t = temporalWord;
                            t += matrix[lastRow - 1, lastColumn + 1];
                            if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow - 1 && b.column == lastColumn + 1).Count() == 0)
                            {
                                isValidLetter = true;
                                lastRow -= 1;
                                lastColumn += 1;
                            }
                        }
                    }

                    //Validate diagonal up left
                    if (!isValidLetter)
                    {
                        if (lastRow - 1 >= 0 && lastColumn - 1 >= 0)
                        {
                            t = temporalWord;
                            t += matrix[lastRow - 1, lastColumn - 1];
                            if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow - 1 && b.column == lastColumn - 1).Count() == 0)
                            {
                                isValidLetter = true;
                                lastRow -= 1;
                                lastColumn -= 1;
                            }
                        }
                    }

                    //Validate previous column
                    if (!isValidLetter)
                    {
                        if (lastColumn - 1 >= 0)
                        {
                            t = temporalWord;
                            t += matrix[lastRow, lastColumn - 1];
                            if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow && b.column == lastColumn - 1).Count() == 0)
                            {
                                isValidLetter = true;
                                lastColumn -= 1;
                            }
                        }
                    }

                    //Validate previous row
                    if (!isValidLetter)
                    {
                        if (lastRow - 1 >= 0)
                        {
                            t = temporalWord;
                            t += matrix[lastRow - 1, lastColumn];
                            if (t == word.Substring(0, i + 1) && solution.breakdown.Where(b => b.row == lastRow - 1 && b.column == lastColumn).Count() == 0)
                            {
                                isValidLetter = true;
                                lastRow -= 1;
                            }
                        }
                    }

                    if (isValidLetter)
                    {
                        temporalWord = t;
                        isValidLetter = false;

                        breakdown = new Breakdown()
                        {
                            character = matrix[lastRow, lastColumn].ToString(),
                            row = lastRow,
                            column = lastColumn
                        };
                        solution.breakdown.Add(breakdown);
                    }
                    else
                    {
                        break;
                    }
                }


                if (word == temporalWord)
                {
                    puzzelSolutions.Add(solution);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
