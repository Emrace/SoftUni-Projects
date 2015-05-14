using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

class LargestRectangle
{
    static void Main()
    {
        List<List<string>> listMatrix = new List<List<string>>();
        string command = Console.ReadLine();
        List<Tuple<int,int>> topCorners = new List<Tuple<int, int>>();
        List<Tuple<int, int>> bottomCorners = new List<Tuple<int, int>>();
        List<int> rectangleAreas = new List<int>();
        int width = 0;
        int length = 0;

        while (command != "END")
        {
            List<string> currRow = command.Split(new char[] { ',' }).ToArray().ToList();
            currRow.RemoveAll(string.IsNullOrEmpty);
            listMatrix.Add(currRow);
            command = Console.ReadLine();
        }

        string[,] matrix = new string[listMatrix.Count, listMatrix[0].Count];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (IsTopLeftCorner(matrix, row, col))
                {
                    topCorners.Add(Tuple.Create(row, col));
                    for (int i = col; i < matrix.GetLength(1); i++)
                    {
                        if (IsTopRightCorner(matrix, row, i))
                        {
                            topCorners.Add(Tuple.Create(row, i));
                        }
                    }
                    foreach (var corner in topCorners)
                    {
                        if (GetBottomCorner(matrix, corner.Item1, corner.Item2) != -1)
                        {
                            bottomCorners.Add(Tuple.Create(GetBottomCorner(matrix, corner.Item1, corner.Item2), corner.Item2));
                        }
                    }

                    
                }
                else
                {
                    break;
                }
            }
        }





        //for (int row = 0; row < matrix.GetLength(0); row++)
        //{
        //    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
        //    {
        //        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        //        {
        //            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        //            {
        //                if (matrix[row, j] == matrix[i, j + 1])
        //                {
        //                    length++;
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //            }

        //            if (matrix[i, col] == matrix[i+1,col])
        //            {
        //                width++;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}



        //for (int i = 0; i < matrix.Count; i++)
        //{
        //    for (int j = 0; j < matrix[i].Count; j++)
        //    {
        //        Console.Write("{0,4}", matrix[i][j]);
        //    }
        //    Console.WriteLine();
        //}

    }

    static int CalculateRectangleArea(string[,] matrix, int topX, int topY, int botX, int botY)
    {
        
    }

    static int TrackHorizontal(string[,] matrix, int startRow, int startCol)
    {
        int currCol = startCol;

        for (int i = startCol + 1; i < matrix.GetLength(1); i++)
        {
            if (matrix[startRow, i] == matrix[startRow,startCol])
            {
                currCol++;
            }
        }

        while (currCol != startCol)
        {
            if (IsBottomRightCorner(matrix, startRow, currCol))
            {
                return currCol;
            }
        }

        return -1;
    }

    static int GetBottomCorner(string[,] matrix, int startRow, int startCol)
    {
        if (IsTopLeftCorner(matrix, startRow, startCol))
        {
            int currRow = startRow;
            for (int i = startRow + 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[startRow,startCol] == matrix[i,startCol])
                {
                    currRow++;
                }
            }
            while (currRow != startRow)
            {
                if (IsBottomLeftCorner(matrix, currRow, startCol))
                {
                    return currRow;
                }

                currRow--;
            }

            return -1;
        }
        else if (IsTopRightCorner(matrix, startRow, startCol))
        {
            int currRow = startRow;
            for (int i = startRow + 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[startRow, startCol] == matrix[i, startCol])
                {
                    currRow++;
                }
            }
            while (currRow != startRow)
            {
                if (IsBottomRightCorner(matrix, currRow, startCol))
                {
                    return currRow;
                }

                currRow--;
            }

            return -1;
        }

        return -1;
    }

    static bool IsTopLeftCorner(string[,] matrix, int startRow, int startCol)
    {
        if (startRow + 1 > matrix.GetLength(0) - 1 || startCol > matrix.GetLength(1) + 1)
        {
            return false;
        }
        if (matrix[startRow, startCol] == matrix[startRow + 1, startCol] &&
            matrix[startRow, startCol] == matrix[startRow, startCol + 1])
        {
            return true;
        }

        return false;
    }

    static bool IsTopRightCorner(string[,] matrix, int startRow, int startCol)
    {
        if (startRow + 1 > matrix.GetLength(0) - 1 || startCol - 1 < 0)
        {
            return false;
        }
        if (matrix[startRow, startCol] == matrix[startRow + 1, startCol] &&
            matrix[startRow, startCol] == matrix[startRow, startCol - 1])
        {
            return true;
        }
        return false;
    }

    static bool IsBottomLeftCorner(string[,] matrix, int startRow, int startCol)
    {
        if (startRow - 1 < 0 || startCol + 1 > matrix.GetLength(1) - 1)
        {
            return false;
        }

        if (matrix[startRow, startCol] == matrix[startRow - 1, startCol] &&
            matrix[startRow, startCol] == matrix[startRow, startCol + 1])
        {
            return true;
        }
        return false;
    }

    static bool IsBottomRightCorner(string[,] matrix, int startRow, int startCol)
    {
        if (startRow - 1 < 0 || startCol - 1 < 0)
        {
            return false;
        }
        if (matrix[startRow, startCol] == matrix[startRow - 1, startCol] &&
            matrix[startRow, startCol] == matrix[startRow, startCol - 1])
        {

        }
        return false;
    }

    static void GetEdgeLength(List<List<string>> matrix, int startRow, int startCol)
    {
        int length = 1;
        string target = matrix[startRow][startCol];

        for (int i = 1; i < matrix.Count; i++)
        {

        }
    }
}