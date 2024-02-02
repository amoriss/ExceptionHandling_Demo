using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Demo;
internal class Methods
{
    /// <summary>
    /// attempt to divide by zero
    /// with user input
    /// </summary>
    public static void Example1()
    {
        bool isValidInput = false;

        while (isValidInput == false)
        {
            try
            {
                // Try block: Code that may cause an exception is placed here
                Console.WriteLine("Enter a number to divide 100 by:");
                int divisor = Convert.ToInt32(Console.ReadLine());
                int result = 100 / divisor;
                Console.WriteLine($"100 divided by {divisor} is {result}");
                isValidInput = true;
            }
            catch (DivideByZeroException ex)
            {
                // Catch block: Code to handle the exception is placed here
                Console.WriteLine("Cannot divide by zero. Please try a different number.");
            }
            catch (FormatException ex)
            {
                // Catch block for a different type of exception
                Console.WriteLine("That's not a valid number. Please enter a numeric value.");
            }
            finally
            {
                // Finally block: Code that will run regardless of an exception is placed here
                Console.WriteLine("Operation completed.");
            }

        }
       
    }
    /// <summary>
    /// attempt to divide by zero.
    /// iterate through a list of the divisors with a foreach
    /// </summary>
    public static void Example2()
    {
        // Collection of denominators
        List<int> denominators = new List<int> { 10, 5, 0, 2 }; // Includes a 0 which will cause a DivideByZeroException

        int numerator = 100;

        foreach (int denominator in denominators)
        {
            try
            {
                // Division operation that might throw DivideByZeroException
                int result = numerator / denominator;
                Console.WriteLine($"{numerator} / {denominator} = {result}");
            }
            catch (DivideByZeroException)
            {
                // Handle the divide by zero case
                Console.WriteLine($"Cannot divide {numerator} by zero.");
            }
            // Optionally, catch other exceptions if necessary
        }
    }

    /// <summary>
    /// reading from a file
    /// catch the exception if file is not found
    /// </summary>
    public static void Example3()
    {
        StreamReader reader = null;
        try
        {
            string filePath = "example.txt";
            reader = new StreamReader(filePath);
            string fileContent = reader.ReadToEnd();
            Console.WriteLine(fileContent);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("The file was not found:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // Always ensure the file is closed, even if an error occurred
            if (reader != null)
            {
                reader.Close();
                Console.WriteLine("File stream closed.");
            }
        }
    }

    /// <summary>
    /// getting user input for editing index of array
    /// </summary>
    public static void Example4()
    {
        var myArray = new int[] { 10, 20, 30 };
        // when getting user input, is a good place to insert a try-catch block
        // we don't know what user will give us


        // TRY CATCH BLOCK
        //Console.Write("Tell me what index of this array to change: ");

        //try
        //{
        //    // user inputs 3 or greater
        //    var input2 = int.Parse(Console.ReadLine());
        //    Console.WriteLine(myArray[input2]);
        //}
        //catch (FormatException f)
        //{

        //    Console.WriteLine(f.Message);
        //}
        //catch (IndexOutOfRangeException i)
        //{
        //    Console.WriteLine(i.Message);
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}
        //finally
        //{
        //    Console.WriteLine("This line will execute no matter what.");
        //}

        //Console.WriteLine();
        //Console.WriteLine("The rest of of my program will run");
    }
    /// <summary>
    /// getting user input for edit index of array, 
    /// but with a loop until user gives input in correct format
    /// </summary>
    public static void Example5()
    {
        var myArray = new int[] { 10, 20, 30 };
        // WITH WHILE LOOP
        while (true)
        {
            try
            {
                Console.WriteLine("Enter in a number that's an index in the array.");
                // user inputs 3 or greater
                var couldParse = int.TryParse(Console.ReadLine(), out int index);
                Console.WriteLine(myArray[index]);
                break;
            }
            catch (FormatException f)
            {

                Console.WriteLine(f.Message);
                Console.WriteLine("Please try again!");

            }
            catch (IndexOutOfRangeException i)
            {
                Console.WriteLine(i.Message);
                Console.WriteLine("Please try again!");
            }
            catch (SystemException s)
            {
                Console.WriteLine(s.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please try again!");
            }

        }
    }

   /// <summary>
   /// example of calling another method that only has a try/finally. 
   /// the original method handles the exception
   /// </summary>
    public static void Original()
    {
        try
        {
            ReadFile("nonexistentfile.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ReadFile(string filePath)
    {
        FileStream fileStream = null;
        try
        {
            fileStream = new FileStream(filePath, FileMode.Open);
            // Read from the file
        }
        finally
        {
            // Ensure the file stream is closed, even if an exception occurs
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
        // Note: No catch block here, so any exception will be thrown back to the caller
    }
}
