

using System;
class  ArrayIsEmpty {
    
    static public bool IsArrayEmpty(string[] array)
{
    
   return (array.Length > 0) ? false : true;
    
 /*if (array.Length > 0)
    return false;
   else
    return true;*/
}
    
    
  static void Main() {
    string[] array= new string[0];  
    bool isEmpty = IsArrayEmpty(array); 
    Console.WriteLine(isEmpty);
    
  }
}
