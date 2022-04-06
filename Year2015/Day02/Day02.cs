using System;
using System.Diagnostics;

namespace Year2015.Day02;

public static class Day02
{
    private static int Part01(string[] dimensions)
    {
        int total = 0;

        foreach (string dims in dimensions)
        {
            string[] lwh = dims.Split('x');
            int l = Convert.ToInt32(lwh[0]);
            int w = Convert.ToInt32(lwh[1]);
            int h = Convert.ToInt32(lwh[2]);

            int lw = l * w;
            int wh = w * h;
            int hl = h * l;

            int min = new[] {lw, wh, hl}.Min();

            total += 2 * lw + 2 * wh + 2 * hl + min;
        }

        return total;
    }

    private static int Part02(string[] dimensions)
    {
        int total = 0;

        foreach (string dims in dimensions)
        {
            string[] lwh = dims.Split('x');
            int l = Convert.ToInt32(lwh[0]);
            int w = Convert.ToInt32(lwh[1]);
            int h = Convert.ToInt32(lwh[2]);

            int bow = l * w * h;

            List<int> min = new List<int> {l, w, h};
            min.Sort();

            total += 2 * min[0] + 2 * min[1] + bow;
        }

        return total;
    }

    public static void Run()
    {
        string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day02/input.txt"));

        // PART 01
        Debug.Assert(Part01(new[] {"2x3x4 "}) == 58);
        Debug.Assert(Part01(new[] {"1x1x10"}) == 43);

        Console.WriteLine("Day02.Part01 = {0}", Part01(input));

        // PART 02
        Debug.Assert(Part02(new[] {"2x3x4 "}) == 34);
        Debug.Assert(Part02(new[] {"1x1x10"}) == 14);

        Console.WriteLine("Day02.Part02 = {0}", Part02(input));
    }
}