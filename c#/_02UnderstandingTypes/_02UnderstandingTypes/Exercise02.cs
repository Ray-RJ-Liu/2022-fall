using System.Diagnostics;
using System.Text;

namespace _02UnderstandingTypes;

// 1. The content in <String> is immutable while the one in <StringBuilder> is mutable. If you want to modify string
//    in the existing string, then use <StringBuilder> object. If you want to create a new modified string object, then
//    use <String> object.
// 
// 2. <Array> is the base class of all arrays in C#
//
// 3. By using "Array.Sort( your_array )". You can add datatype and comparer as optional arguments.
//
// 4. Call this function ->    xxx.Length()
//
// 5. No.
//
// 6. "CopyTo" method needs user to provide memory location therefore it will copy all elements to that area.
//    "Clone" method doesn't need user to do so. It will return a new array object that is identical to the original one.
//    They are both SHALLOW COPY.
//

using System;
using System.Collections;

public class Exercise02
{
    public static void Main()
    {
    
    }

    public void  Question1()
    {
        int[] a = new int[10]{0,1,2,3,4,5,6,7,8,9};

        int[] a_copy = new int[a.Length];
        for (int i = 0; i < a.Length; ++i)
        {
            a_copy[i] = a[i];
        }
    }

    public void  Question2()
    {
        ArrayList buffer = new ArrayList();
        Console.WriteLine("Enter command (+ item, -item, or -- to clear):");
        while (true)
        {
            string cmd = Console.ReadLine();

            if (cmd == "quit")
                return;
            
            switch (cmd.Substring(0,2))
            {
                case "+ ":
                    buffer.Add(cmd.Substring(2));
                    break;
                case "- ":
                    buffer.Remove(cmd.Substring(0,2));
                    break;
                case "--":
                    buffer.Clear();
                    break;
            }
            
            Console.WriteLine("Array:");
            Console.WriteLine("    Count:    {0}", buffer.Count);
            Console.WriteLine("    Capacity: {0}", buffer.Capacity);
            Console.WriteLine("Values:");
            foreach (string word in buffer)
            {
                Console.Write("    {0}", word);    
            }
            Console.WriteLine();
        }
    }

    static bool isPrime(int num)
    {
        if( num==2 || num==3) {
            return true;
        }
        if( num%6 != 1 && num%6 != 5) {
            return false;
        }
        for ( int i=5; i*i <= num; i+=6 ) {
            if( num%i==0 || num%(i+2)==0 ) {
                return false;
            }
        }
        return true;
    }
    
    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> buffer = new List<int>();
        for (int i = startNum; i <= endNum; ++i)
        {
            if (isPrime(i))
            {
                buffer.Add(i);
            }
        }
        return buffer.ToArray();
    }
    
    public int[] Question3(int start, int end)
    {
        int[] nums = FindPrimesInRange(start, end);
        Console.WriteLine("Q3 Answer:");
        foreach (int num in nums)
        {
            Console.Write(num);
            Console.Write(' ');
        }
        Console.WriteLine();
        return nums;
    }

    public int[] Question4(int[] array, int k)
    {
        int[] res = new int[array.Length];
        for (int i=0; i<array.Length; ++i)
        {
            res[i] = 0;
        }

        for (int i = 1; i <= k; ++i)
        {
            for (int j = 0; j < array.Length; ++j)
            {
                if (j < i)
                {
                    res[j] += array[j + array.Length - i];
                }
                else
                {
                    res[j] += array[j - i];
                }
            }
        }
        Console.WriteLine("Q4 Answer:");
        foreach (int num in res)
        {
            Console.Write(num);
            Console.Write(' ');
        }
        Console.WriteLine();
        return res;
    }

    public int[] Question5(int[] array)
    {
        if (array.Length == 1)
        {
            return new int[1] { array[0] };
        }
            
        List<int> res = new List<int>();
        int rs = 0, re = 0;
        int cs = 0, ce = 1;
        for (int i = 1; i < array.Length; ++i, ++ce)
        {
            if (array[i] != array[i - 1])
            {
                if (re - rs < ce - cs - 1)
                {
                    re = ce-1;
                    rs = cs;
                }
                cs = ce;
            }
        }
        
        if (re - rs < ce - cs - 1)
        {
            re = ce-1;
            rs = cs;
        }

        for (int i = rs; i <= re; ++i)
        {
            res.Add(array[i]);
        }
        
        Console.WriteLine("Q5 Answer:");
        foreach (int num in res)
        {
            Console.Write(num);
            Console.Write(' ');
        }
        Console.WriteLine();
        return res.ToArray();
    }

    public int   Question7(int[] array)
    {
        Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
        for (int i = 0; i < array.Length; ++i)
        {
            if (dict.ContainsKey(array[i]))
            {
                dict[array[i]][0]++;
                dict[array[i]][1] = i;
            }
            else
            {
                dict.Add( array[i], new int[2]{ 1, i});
            }
        }

        KeyValuePair<int, int[]> res = new KeyValuePair<int, int[]>(0,new int[2]{0,0});
        foreach (var pair in dict)
        {
            if (pair.Value[0]>res.Value[0] )
            {
                res = pair;
            }
            else if(pair.Value[0]==res.Value[0])
            {
                if (pair.Value[1] < res.Value[1])
                    res = pair;
            }
        }
        Console.WriteLine("Q7 Answer:");
        Console.WriteLine(res.Key);
        return res.Key;
    }

    public string QuestionString1(string s)
    {
        StringBuilder str = new StringBuilder(s);
        for (int i = 0; i < str.Length / 2; ++i)
        {
            (str[i], str[str.Length - i - 1]) = (str[str.Length - i - 1], str[i]);
        }

        return str.ToString();
    }

    bool isSeparator(char c)
    {
        if (c == ':' || c == '.' || c == ',' || c == ';' || c == '=' ||
            c == '(' || c == ')' || c == '&' || c == '[' || c == ']' ||
            c == '"' || c == '\''|| c == '\\'|| c == '/' || c == '!' ||
            c == '?' || c == ' ')
        {
            return true;
        }

        return false;
    }

    void collectWords( ref string str, ref List<string> word, ref List<string> sepa)
    {
        bool flag = isSeparator(str[0]);
        int cs  = 0;
        int len = 0;
        // 遍历字符，采集单词串和分隔符串
        for (int i = 0; i < str.Length; ++i, ++len)
        {
            if (isSeparator(str[i]) ^ flag)
            {
                if (!flag) // 字符 => 分割
                {
                    word.Add(str.Substring(cs, len));
                }
                else // 分割 => 字符
                {
                    sepa.Add(str.Substring(cs, len));
                }

                flag = !flag;
                len = 0;
                cs = i;
            }

            if (i == str.Length - 1)
            {
                if (!flag) // 字符 => 分割
                {
                    word.Add(str.Substring(cs, i-cs+1));
                }
                else // 分割 => 字符
                {
                    sepa.Add(str.Substring(cs, i-cs+1));
                }
            }
        }
    }
    public string QuestionString2(string s)
    {
        StringBuilder res = new StringBuilder();
        List<string> word = new List<string>();
        List<string> sepa = new List<string>();
        
        bool wordFirst = (isSeparator(s[0]) == false);
        collectWords( ref s, ref word, ref sepa);
        
        // 翻转所有单词
        for (int i = 0; i < word.Count / 2; ++i)
        {
            (word[i], word[word.Count - i - 1]) = (word[word.Count - i - 1], word[i]);
        }
        
        // 分隔符数量与字符单词数量差至多相差1，否则输入了非法字符
        Debug.Assert( Math.Abs( word.Count-sepa.Count)<=1 );
        int size = Math.Max(word.Count(), sepa.Count);
        
        // 重新构建句子
        if (wordFirst)
        {
            for (int i = 0; i < size; ++i)
            {
                if( i<word.Count )    res.Append(word[i]);
                if( i<sepa.Count )    res.Append(sepa[i]);
            }    
        }
        else
        {
            for (int i = 0; i < size; ++i)
            {
                if( i<sepa.Count )    res.Append(sepa[i]);
                if( i<word.Count )    res.Append(word[i]);
            }   
        }
        
        return res.ToString();
    }

    bool isPalindromes( string str)
    {
        for (int i = 0; i < str.Length / 2; ++i)
        {
            if(str[i]!=str[str.Length - i - 1]) return false;
        }
        return true;
    }

    public void QuestionString3( string str)
    {
        
        HashSet<string> set = new HashSet<string>();
        List<string> word = new List<string>();
        List<string> sepa = new List<string>();
        
        collectWords( ref str, ref word, ref sepa);

        foreach (var w in word)
        {
            if (isPalindromes(w))
            {
                set.Add(w);
            }
        }

        string[] res = set.ToArray();
        Array.Sort(res);
        
        Console.WriteLine("QuestionString3:");
        foreach (var s in res)
        {
            Console.WriteLine(s);
        }
    }

    public string[] QuestionString4(string url)
    {
        string[] res = new string[3]{"","",""};
        int idx_protocol = url.IndexOf(':');
        
        if( idx_protocol!=-1 )
            res[0] = url.Substring(0, idx_protocol+1);

        int idx_server = url.IndexOf('/', idx_protocol + 3);
        if (idx_server != -1)
            res[1] = url.Substring(idx_protocol + 3, idx_server - idx_protocol - 3);
        else
            res[1] = url.Substring(idx_protocol + 3);
        
        if( idx_server!=-1 )
            res[2] = url.Substring(idx_server+1);
        return res;
    }
}