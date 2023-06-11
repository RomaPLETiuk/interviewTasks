using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CourseraGraderNetCore3
{
    public class LearnerProgram{
    /*
    TODO:
        Write a public static C# method named NumSquare that takes a one-dimentional array as input
        and creates a LINQ statement that queries the numbers that have a square number graeter than 20 and orders them ascending. 
        The LINQ query retrieves anonymous objects in which each object contains the number (Num) and its square number (SqrNum).
        The method returns the LINQ query as an IEnumerable<object> object.
        The anonymous object contains two instance variables named Num and SqrNum.
    Input: a one-dimentional integer array.
    Output: a LINQ query of type IEnumerable<object>. 
    Example: Given array A = [3, 4, 10, 5], invoking NumSquare(A) return a LINQ query that once executed will contain:
                    {Num=5, SqrNum=25}, 
                    {Num=10, SqrNum=25}
                    
    */
    public static IEnumerable<object> NumSquare(int[] A){                  
        var query = from num in A
                    let sqrNum = num * num
                    where sqrNum > 20
                    orderby sqrNum ascending
                    select new { Num = num, SqrNum = sqrNum };

        return query;
    }

    /*
    TODO:
        Write a public static C# method named EvenNumber that takes a one-dimentional array as input
        and creates a LINQ statement that queries the even numbers in the given array. 
        The method returns the created LINQ query.
    Input : A which is a one-dimentional integer array.
    Output: an IEnumebarble<int> object containing the even numbers of A
    Example: Given that A = [1, 2, 3, 4, 5, 6], invoking EvenNumber(A) would return 
            a linq query containes the even number in A which are {2, 4, 6}
    */
    public static IEnumerable<int> EvenNumber(int[] A){
        var query = from num in A
                    where num % 2 == 0
                    select num;

        return query;
    }

    /*
    TODO:
        Write a C# public static method named FindCity that takes a one-dimentional string array as input
        and creates a LINQ statement that queries the cities that starts with 'A' or 'a' and ends with 'N' or 'n'
        and returns the created LINQ query as an IEnumerable<string> object.
    Input: cities an array of strings 
    Output: The strings in teh cities array that starts with letter 'A' or 'a' and ends with letter 'N' or 'n'.
    Example:
            if cities = ["New York","Amman", "Paris"], invoking FindCity(cities) 
            would return a LINQ query that contains only {Amman}.

    */
   
     public static IEnumerable<string> FindCity(string[] cities)
        {
        var query = from city in cities
                    where city.StartsWith("A", StringComparison.OrdinalIgnoreCase)
                          && city.EndsWith("N", StringComparison.OrdinalIgnoreCase)
                    select city;

        return query;   
        }

    /* 
    TODO:
        Write a C# public static method named OrderString that takes a one-dimentional string array as input
        and creates a LINQ statement that queries the strings that have more than 5 characters and order them
         in a descending order. The method returns an IEnumerable<string> object.
    INPUT: names an array of strings.
    Output: an IEnumerable<string> object containig the strings that have more than 5 characters order descending.
    Example: if Names = {"Sami","Samah","Lamar","Leen", "Mahmoud", "Layan", "Yousef"}, then invoking OrderString(Names) 
    would return an IEnumerable<string> object containing: {"Mahmoud", "Yousef"}
    */

    public static IEnumerable<string> OrderString(string[] Names)
      {          
        var query = from name in Names
                    where name.Length > 5
                    orderby name descending
                    select name;

        return query;
        }

          
  }
}
