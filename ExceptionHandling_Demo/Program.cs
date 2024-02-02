// exception 1
using ExceptionHandling_Demo;

var myArray = new int[] { 10, 20, 30 };


//Console.Write("Tell me what index of this array to change: ");
// user inputs 3 or greater will produce exception
//var input = int.Parse(Console.ReadLine());
//Console.WriteLine(myArray[input]);


// WITH WHILE LOOP
//while (true)
//{
//    try
//    {
//        // user inputs 3 or greater
//        var couldParse = int.TryParse(Console.ReadLine(), out int index);
//        Console.WriteLine(myArray[index]);
//        break;
//    }
//    catch (FormatException f)
//    {

//        Console.WriteLine(f.Message);
//        Console.WriteLine("Please try again!");

//    }
//    catch (IndexOutOfRangeException i)
//    {
//        Console.WriteLine(i.Message);
//        Console.WriteLine("Please try again!");
//    }
//    catch (SystemException s)
//    {
//        Console.WriteLine(s.Message);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//        Console.WriteLine("Please try again!");
//    }

//}

//Methods.Example1();
Methods.Example5();

//on quiz: 
//var x = 1;

//for (; x < 6; x += 2)
//{
//    x = x * x;
//}
//Console.WriteLine(x);