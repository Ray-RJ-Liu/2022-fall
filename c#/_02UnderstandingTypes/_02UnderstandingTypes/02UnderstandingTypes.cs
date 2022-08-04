namespace _02UnderstandingTypes;
//Understanding Data Types
//1. What type would you choose for the following “numbers”?
// A person’s telephone number ;uint
// A person’s height float
// A person’s age byte
// A person’s gender (Male, Female, Prefer Not To Answer) byte
// A person’s salary decimal
// A book’s ISBN ulong
// A book’s price decimal
// A book’s shipping weight float
// A country’s population uint
// The number of stars in the universe ulong
// The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business ushort
// 2.What are the difference between value type and reference type variables? What is boxing and unboxing?
// Value type: 
// Directly contain their data
// Each has its own copy of data
// Operation on one can not affect another
// Reference Type: 
// Store references to their data(Known as objects)
// Two reference variable can reference the same object
// Operation on one can affect another
// Boxing:
// Convert a value type to a reference type
// Unboxing:
// Convert a reference type to a value type
//3.What is meant by the terms managed resource and unmanaged resource in .NET
// Managed resources are those that are pure .NET code and managed by the runtime and are under its direct control.
//Unmanaged resources are those that are not. File handles, pinned memory, COM objects, database connections etc.
//4.What's the purpose of Garbage Collector in .NET?
// Don’t need to manually release memory
// Allocates objects on managed heap efficiently
//Controlling Flow and Converting Types
//1.What happens when you divide an int variable by 0?
// Show up following output:
// Unhandled exception. System.DivideByZeroException: Attempted to divide by zero.
//2.What happens when you divide a double variable by 0?
// Output:
//     ∞
//3.What happens when you overflow an int variable, that is, set it to a value beyond its range?
// System warning
// [CS1021] Integral constant is too large
//4.What is the difference between x = y++; and x = ++y;?
// For x = y++, first read y , x = y and then do y = y +1
// For x =++y , first do y = y+1 and then do x = y
//5.What is the difference between break, continue, and return when used inside a loop statement?
// The break statement terminates the closest enclosing iteration statement.
// The continue statement starts a new iteration of the closest enclosing iteration statement
// The return statement terminates execution of the function in which it appears and returns control and the function's result, if any, to the caller.
//6.What are the three parts of a for statement and which of them are required?
// The keyword for that starts the loop, the condition being tested, and the EndFor keyword that terminates the loop. The keyword that starts the loop is required.
//7.What is the difference between the = and == operators?
// = is passing the value
// == is checking if the two value is the same
//8.Does the following statement compile? for ( ; true; ) ;
// It is an infinite loop. 
//9.What does the underscore _ represent in a switch expression?
// The underscore (_) character replaces the default keyword to signify that it should match anything if reached.
// The bodies are now expressions instead of statements. The selected body becomes the switch expression's result.
//10.What interface must an object implement to be enumerated over by using the foreach statement?
// 1.The starting point
// 2.the total enumeration length
// 3.address offset for each object

public class Assigment1 {
    public static void _02UnderstandingTypes()
    {
        string[] names = { "sbyte","byte","short","ushort","int","uint","long","ulong","float","double","decimal" };
        int[] bytes = { 1,1,2,2,4,4,8,8,4,8,16};
        string[] range = {"-128 to +127","0 to 255","-32,768 to 32,767","0 to 65,535","-2,147,483,648 to 2,147,483,647","0 to 4,294,967,295","-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807","0 to 18,446,744,073,709,551,615","+-1.0e-45 to +-3.4e38","+-5e-324 to +-1.7e308","+-1.0*10e-28 to +-7.9e28" };
        Console.WriteLine("{0,-20}{1,-5}{2,75}\n","Name","Number of bytes in memory","minimum and maximum values");
        for(int ctr = 0; ctr < names.Length; ctr++)
            Console.WriteLine("{0,-20}{1,5:G}{2,90}",names[ctr], bytes[ctr], range[ctr]);
    }

    public void CenturyCalculator()
    {
        int c;
        Console.WriteLine("Please input the number of century to calculate");
        c = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine(c + " centuries = " + 100*c +" years = " + 36524*c + " days = " + 876576*c +" hours = " + 52594560*c + " minutes = " + 3155673600*c + " seconds = " + 3155673600000*c + "milliseconds = " + 3155673600000000*c + "microseconds = " + 3155673600000000000*c + "nanoseconds");
    }

}