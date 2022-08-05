﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DesigningOOP;



// 1. Private   = Private objects are not accessible outside the body of the class
//    Protected = The Protected access specifier restricts an object to be accessible only from derived instances of the class. 
//    public    = This is the least restricted access modifier. Public objects are practically accessible to the whole
//                outside world, thereby making them the highest permissible access modifier.
//    Internal  = Internal objects and methods are only accessible within the same assembly.
//    Protected Internal = Protected OR Internal.
//    Private Protected  = This is a union combination of both Private and Protected access modifiers.
// 2. const  = The constant value and will never change
//    readonly = read only and can not be modified
//    static = it belongs to the entire class. All instances share the only static member. 
// 3. Initialize the class member. Add default value.
// 4. It is useful when part of a class' implementation is generated by some tool and the other
//    portion is written by a developer. This allows you to re-generated the generated portion of the code without
//    losing the hand coded portion of the implementation.
// 5. tuple = A data structure that group multiple data elements in a lightweight data structure
// 6. record = It is a class or struct that provides special syntax and behavior for working with data models. 
// 7. Overriding happens in inherited classes with same method name. Overloading means several same name methods in one class
// 8. The field is a variable of any type that is declared directly in the class while property is a member that
//    provides a flexible mechanism to read, write or compute the value of a private field.
// 9. By adding "=" with value.
// 10. Interface is the contract of class. However the abstract provide a basic framework of a class
// 11. All
// 12. F (Not derived class)
// 13. T
// 14. F 
// 15. F
// 20. T
// 21. T
// 22. T
// 23. T
namespace WorkingWithMethod
{


    class Question1
    {
        // 随机生成10个100以内的正整数
        public int[] GenerateNumbers()
        {
            Random rd = new Random();
            return new int[]
            {
                rd.Next() % 100, rd.Next() % 100, rd.Next() % 100, rd.Next() % 100, rd.Next() % 100, rd.Next() % 100,
                rd.Next() % 100, rd.Next() % 100, rd.Next() % 100, rd.Next() % 100
            };
        }

        // 翻转数组顺序
        public void Reverse(ref int[] array)
        {
            for (int i = 0; i < array.Length / 2; ++i)
            {
                (array[i], array[array.Length - i - 1]) = (array[array.Length - i - 1], array[i]);
            }
        }

        // 打印数组内容
        public void PrintNumbers(ref int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i]);
                if (i != array.Length - 1)
                    Console.Write(',');
            }

            Console.WriteLine();
        }
    }

    class Question2
    {
        public int Fibonacci(int n)
        {
            if (n == 0 || n == 1) return 1;
            int res = 0;
            int fnm1 = 1, fnm2 = 1;
            for (int i = 2; i <= n; ++i)
            {
                res = fnm1 + fnm2;
                fnm2 = fnm1;
                fnm1 = res;
            }

            return res;
        }
    }
}

namespace DesigningOOP
{
    abstract class Vehicle
    {
        public abstract void color(UInt32 color);
        public abstract void vin_number(string vin);
    }
    class  Car : Vehicle
    {
        private int            speed_;
        private UInt32         color_;
        private StringBuilder  vin_;
        
        // 获取当前速度
        public int speed()                 { return speed_; }

        // 设定当前速度
        public void speed(int val)         { speed_ = val;  }

        // 获取汽车颜色
        public UInt32 color()              { return color_; }
        
        // 设置汽车颜色
        public override void color(UInt32 color)    { color_ = color; }
        
        // 设置汽车VIN号码
        public override void vin_number(string vin) { vin_ = new StringBuilder(vin); }
 
        // 获取汽车VIN号码
        public string vin_number()         { return vin_.ToString(); }
    }

    class Coupe : Car
    {
        public Coupe()
        {
            door_ = new bool[2] { false, false };
        }

        private bool[] door_;

        public bool door_state_left()            { return door_[0]; }
        public bool door_state_right()           { return door_[1]; }
        public void door_state_left(bool state)  { door_[0]=state; }
        public void door_state_right(bool state) { door_[1]=state; }
    }

    class Mustang : Coupe
    {
        public Mustang()
        {
            
        }
    }
    
    class Question1
    {
        // Abstraction
        // <Vehicle> is an abstract class that only present method for vin number and color.
        
        // Inheritance
        // <Car>     is a class that is inherited from <Vehicle>
        // <Coupe>   is a class that is inherited from <Car>
        // <Mustang> is a class that is inherited from <Coupe>
        
        // Encapsulation
        // In class <Car>, the member <vin_> and <color_> is invisible to user because they are set to private.
        
        // Polymorphism
        // For the method "color" and "vin_number", there are two ways to call them. By passing the value, that will
        // modify the variable while you can get the value by passing nothing.
        
    }


    
    // Question 2 & 3 & 4 & 5 & 6
    interface IPersonService
    {
        void Name(string name);
        void Sex(int sex);
        int Age();
        void AddAddress(string addr);
        int Salary();
        string GetAddress(string attr);
    }
    abstract class Person : IPersonService
    {
        private StringBuilder name_;
        private int           sex_;
        private List<string>  address_;
        private DateTime      birthday_;

        public void Name      (string name) { name_ = new StringBuilder(name); }
        public void Sex       (int    sex ) { sex_  = sex; }
        public int  Age       ()            { return (DateTime.Now - birthday_).Days / 365; }
        public void AddAddress(string addr) { address_.Add(addr); }

        public string GetAddress(string attr)
        {
            return address_[0];
        }

        public abstract int Salary();

        // 构造函数
        public Person(int yy, int mm, int dd) {
            address_   = new List<string>();
            birthday_  = new DateTime( yy, mm, dd);
        }
    }

    interface IStudentService : IPersonService
    {
        bool Submit(Object assignment);
        char Grade(string courseName);
    }
    class Student    : Person, IStudentService
    {
        private int score_;
        
        private Dictionary<string,char> GPA;
        public bool Submit(Object assignment) { /* Do something */ return true; }
        public char Grade(string courseName)  { return GPA[courseName]; }
        public override int Salary()          { return 0;}
        // 构造函数
        public Student(int yy, int mm, int dd):base(yy, mm, dd) {
            score_ = -1;
        }

    }

    interface IInstructorService : IPersonService
    {
        void grade(string name, int score);
    }
    class Instructor : Person
    {
        private double bonus;
        private int    hour_;
        private DateTime joinday_;
        Instructor(int yy, int mm, int dd, DateTime joinday) : base(yy, mm, dd)
        {
            bonus = Age() * 0.25;
            joinday_ = joinday;
        }

        public override int Salary()
        {
            return (int)bonus + hour_*40 + joinday_.Day/365*2; // 瞎算的
        }

        public void grade(string name, int score)
        {
            
        }
    }

    class Course
    {
        private List<Student> enrollment;

        public void AddStudent(Student s)
        {
            enrollment.Add(s);
        }
    }
    
    public class Budget
    {
        public int money;
        public DateTime start;
        public DateTime end;
    }

    interface IDepartmentService
    {
        void AddClass(string name);
        Budget GetBudget(int year);
    }
    
    
    class Department : IDepartmentService
    {
        private Instructor leader;
        private List<string> classes;
        
        private Dictionary<int,Budget> budget;

        public void AddClass(string name)
        {
            this.classes.Add(name);
        }

        public Budget GetBudget(int year)
        {
            return budget[year];
        }
        
        public Department(Instructor leader)
        {
            this.leader  = leader;
            this.classes = new List<string>();
        }
        
    }

    // Question 7
    public class Color
    {
        private byte red;
        private byte green;
        private byte blue;
        private byte alpha;

        public Color(byte r, byte g, byte b, byte a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }
        public Color(byte r, byte g, byte b)
        {
            red = r;
            green = g;
            blue = b;
            alpha = 255;
        }
        
        void Red(byte val){ red = val;} 
        void Green(byte val){ green = val;}    
        void Blue(byte val){ blue = val;} 
        void Alpha(byte val){ alpha = val;} 
        
        byte Red(){ return red;} 
        byte Green(){ return green;}    
        byte Blue(){ return blue;} 
        byte Alpha(){ return alpha;}

        byte grayscale()
        {
            return (byte)((red + green + blue) / 3);
        }
    }

    public class Ball
    {
        private Color color;
        private uint size;
        private uint count;
        
        public Ball(Color color, uint val)
        {
            this.color = color;
            this.size = val;
            count = 0;
        }

        public Ball(byte r, byte g, byte b, uint val)
        {
            color = new Color(r, g, b);
            size  = val;
            count = 0;
        }

        public void Pop()
        {
            size = 0;
        }

        public void Throw()
        {
            if (this.size != 0)
            {
                count++;
            }
        }

        public uint Count()
        {
            return count;
        }
        
       

    }

    
}

namespace _02UnderstandingTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkingWithMethod.Question1 q1 = new WorkingWithMethod.Question1();
            int[] array = q1.GenerateNumbers();
            q1.PrintNumbers (ref array);
            q1.Reverse      (ref array);
            q1.PrintNumbers (ref array);

            WorkingWithMethod.Question2 q2 = new WorkingWithMethod.Question2();
            Debug.Assert(  1==q2.Fibonacci(1));
            Debug.Assert(  2==q2.Fibonacci(2));
            Debug.Assert(  3==q2.Fibonacci(3));
            Debug.Assert(  5==q2.Fibonacci(4));
            Debug.Assert(  8==q2.Fibonacci(5));
            Debug.Assert( 13==q2.Fibonacci(6));
            Debug.Assert( 55==q2.Fibonacci(9));
            
            DesigningOOP.Ball b1 = new DesigningOOP.Ball(0xff, 0xff, 0xff, 23);
            b1.Throw();
            b1.Throw();
            b1.Throw();
            b1.Pop();
            b1.Throw();
            b1.Throw();
            Console.WriteLine(b1.Count());
        }
    }
}
