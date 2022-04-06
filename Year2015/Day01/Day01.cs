using System;
using System.Diagnostics;

namespace Year2015.Day01;

public class Day01
{
    private static int Part01(string directions)
    {
        int floor = 0;

        foreach (char c in directions)
        {
            switch (c)
            {
                case '(':
                    floor += 1;
                    break;
                case ')':
                    floor -= 1;
                    break;
            }
        }

        return floor;
    }
    
    private static int Part02(string directions)
    {
        int floor = 0;

        foreach (var item in directions.Select((value, i) => new {i, value}))
        {
            switch (item.value)
            {
                case '(':
                    floor += 1;
                    break;
                case ')':
                    floor -= 1;
                    break;
            }

            if (floor == -1)
            {
                return item.i + 1;
            }
        }

        return -1;
    }

    public static void Main(string[] args)
    {
        string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day01/input.txt"));
        
        // PART 01
        Debug.Assert(Part01("(())") == 0);
        Debug.Assert(Part01("()()") == 0);
        
        Debug.Assert(Part01("(((") == 3);
        Debug.Assert(Part01("(()(()(") == 3);
        Debug.Assert(Part01("))(((((") == 3);

        Debug.Assert(Part01("())") == -1);
        Debug.Assert(Part01("))(") == -1);

        Debug.Assert(Part01(")))") == -3);
        Debug.Assert(Part01(")())())") == -3);
        
        Console.WriteLine("Day01.Part01 = {0}", Part01(input));
        
        // PART 02
        Debug.Assert(Part02(")") == 1);
        Debug.Assert(Part02("()())") == 5);
        
        Console.WriteLine("Day01.Part02 = {0}", Part02(input));
    }
}