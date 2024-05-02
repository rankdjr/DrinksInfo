using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Services;

public class Utilities
{
    public static void PrintNewLines(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine();
        }
    }
}
