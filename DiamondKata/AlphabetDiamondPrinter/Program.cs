// See https://aka.ms/new-console-template for more information

using System;

namespace AlphabetDiamondPrinter;

public static class AlphabetDiamondPrinter
{
    public static void Main()
    {
        Console.WriteLine("Please enter a character input [A-Z] : ");
        var inputChar = Console.ReadKey(); //TODO : validate this
        if (!string.IsNullOrEmpty(inputChar.KeyChar.ToString()))
        {
            var result = new AlphabetMatrixCalculator().CalculateAlphabetMatrix(inputChar.KeyChar.ToString());

            Console.WriteLine("\nHere's your pretty little alphabet diamond! :)");
            PrintAlphabetDiamondMatrix(result);
        }

        Console.ReadLine();
    }

    private static void PrintAlphabetDiamondMatrix(RowInfo[] result)
    {
        var columnCount = (result[0].Index1*2) + 1;
        
        //print top half of the diamond
        for (int i = 0; i < result.Length; i++)
        {
            var currentRow = result[i];
            for (int j = 0; j < columnCount; j++)
            {
                if (j == currentRow.Index1 || j == currentRow.Index2)
                {
                    Console.Write($"{currentRow.Alphabet}");
                }
                else
                {
                    Console.Write(" _ ");
                }
            }
            Console.WriteLine();
        }
        
        //print bottom half of the diamond
        
        for (int i = result.Length - 2; i >= 0; i--)
        {
            var currentRow = result[i];
            for (int j = 0; j < columnCount; j++)
            {
                if (j == currentRow.Index1 || j == currentRow.Index2)
                {
                    Console.Write($"{currentRow.Alphabet}");
                }
                else
                {
                    Console.Write(" _ ");
                }
            }
            Console.WriteLine();
        }
    }
}