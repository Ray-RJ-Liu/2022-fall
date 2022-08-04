namespace _02UnderstandingTypes;

public class Exercise03
{
    public static void Main()
    {
        
    }

    public void Question1()
    {
        for (uint i = 0; i <= 100; ++i)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("/fizzbuzz/");
            }
            else if( i%3==0 )
            {
                Console.WriteLine("/fizz/");
            }
            else if( i%5==0 )
            {
                Console.WriteLine("/buzz/");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
        // What will happen if ...
        // This is a dead loop because i will never reach 500. It is up to 255 due the data type of 'byte'.
    }
    
    public void Question2(int height)
    {
        int numTotal = 2 * height + 1;
        for (int i = 0; i < height; ++i)
        {
            int numStar  = 2 * i + 1;
            int numSpace = numTotal - numStar;

            int tmp = numSpace / 2;
            while( 0!=tmp-- )
                Console.Write(' ');

            while( 0!=numStar-- )
                Console.Write('*');

            tmp = numSpace / 2;
            while( 0!=tmp--)
                Console.Write(' ');
            Console.Write('\n');
        }
        
    }

    public void Question3()
    {
        int num = new Random().Next(3) + 1;
        int guess = 0;
        do
        {
            Console.WriteLine("Please guess a number:\n");
            guess = int.Parse(Console.ReadLine());
            
            if( guess<1 || guess>3 )
                Console.WriteLine("Invalid number");
            else
            {
                if (guess > num)
                    Console.WriteLine("high");
                else if (guess < num)
                    Console.WriteLine("low");
            }
            
        } while (guess != num);
        Console.WriteLine("correct");
    }
    
    public int Question4( int yy, int mm, int dd)
    {
        DateTime b_day = new DateTime(yy, mm, dd);
        DateTime t_day = DateTime.Today;
        return (t_day - b_day).Days;
    }

    public int Question4_bonus(int yy, int mm, int dd)
    {
        int days = Question4(yy, mm, dd);
        return 10000 - (days % 10000);
    }

    public void Question5()
    {
        string[] words = new string[4]{"Good Morning", "Good Afternoon", "Good Evening", "Good Night"};
        DateTime time = DateTime.Now;
        if (time.Hour >= 5 && time.Hour < 12)
        {
            Console.WriteLine(words[0]);
            return;
        }

        if (time.Hour >= 12 && time.Hour < 17)
        {
            Console.WriteLine(words[1]);
            return;
        }

        if (time.Hour >= 17 && time.Hour < 22)
        {
            Console.WriteLine(words[2]);
            return;
        }

        Console.WriteLine(words[3]);
    }

    public void Question6()
    {
        for (int i = 1; i <= 4; ++i)
        {
            for (int j = 0; j <= 24; j+=i)
            {
                if(j!=0)
                    Console.Write(',');
                Console.Write(j);
                
            }
            Console.Write('\n');
        }
    }

}