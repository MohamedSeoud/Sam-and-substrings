using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    static long mod(string num)
    {
        long ret;
        double modulo = Math.Pow(10, 9) + 7;
        long modul = Convert.ToInt64(modulo);
        if (Convert.ToString(num).Length < Convert.ToString(modulo).Length)
        {
            return Convert.ToInt64(num);
        }
        else
        {
            if (Convert.ToString(num).Length == Convert.ToString(modulo).Length)
            {
                if (Convert.ToInt64(num) < modul) { return Convert.ToInt64(num); }
                else { return Convert.ToInt64(num) % modul; }
            }
            else
            {
                int modlen = Convert.ToString(modul).Length;
                int numlen = Convert.ToString(num).Length;
                long divnum = Convert.ToInt64(num.Substring(0, modlen));

                for (int i = modlen; i < numlen; i++)
                {
                    if (divnum > modul) { divnum %= modul; }
                    divnum = Convert.ToInt64(Convert.ToString(divnum) + num[i]);
                }
                ret = divnum % modul;
            }
        }

        return ret;
    }

    // Complete the substrings function below.
    static int substrings(string n)
    {

        long ret = 0;
        var nums = new List<long>();
        int len = n.Length;
        int first = Convert.ToInt32(n[0].ToString());
        nums.Add(first);
        for (int i = 1; i < len; i++)
        {
            int tempnum = Convert.ToInt32(n[i].ToString());
            long sum = (tempnum * (i + 1)) + mod((nums[i - 1].ToString() + "0").ToString());
            sum = mod(sum.ToString());
            nums.Add(sum);
        }
        int lennums = nums.Count();
        for (int i = 0; i < lennums; i++)
        {
            ret += nums[i];
            ret = mod(ret.ToString());
        }
        return (int)ret;
    }

    static void Main(string[] args)
    {
    //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string n = Console.ReadLine();

        int result = substrings(n);

        Console.WriteLine(result);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
