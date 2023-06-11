using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CourseraGraderNetCore3
{
  
    public class Product
    {
        private string _Name;
        private double _Price;
         
       
       
        public string Name{
            get{
                 return $"[{_Name}]";
            }
            set{
                _Name = value;
            }
        }
     
      
        public double Price{
            get{
               return _Price*0.71; //here you need to return the price in JOD. Meaning that you need to multiply the _Price with 0.71 and return it.
            }
            set{
                _Price = value;//here you need to set the value keyword to the _Price instance variable.
            }
        }

        

        

        public Product(string N, double P){
           _Name = N; 
           _Price = P;
        }

       
        
        public Product() : this("Empty", 0)
        {

        }
        

       
        //"[_Name] costs Price JOD"
        //Note that, if you implemented the Name and Price properties correctly, you just need to return $"{Name} costs {Price} JOD"
        public override string ToString(){
            return $"[{_Name}] costs {Price} JOD";
        }

        //6. Override the Equals method
        public override bool Equals(object obj)
{
    if (obj == null || GetType() != obj.GetType())
    {
        return false;
    }

    Product otherProduct = (Product)obj;
    return _Name == otherProduct._Name && _Price == otherProduct._Price;
}
        /*
        public override bool Equals(Object obj){
            Product P = obj as Product;
            if(P == null){
                return false;
            }
            //compare between this and P objects if they have the same _Name and _Price            

        }
        */       

      
       
        public double SalePrice()
    {
        double value = 0;
        if (_Price >= 200)
        {
            value = _Price * 0.75;
        }
         else if (_Price >= 100 && _Price < 200)
        {
            value = _Price * 0.85;
        }
        else
        {
            value = _Price * 0.9;
        }
    
        return value;
    }
        
        
        
        
        public string PrintPriceNTimes(int N)
{
    string result = "";
    for (int i = 0; i < N; i++)
    {
        result += _Price.ToString() + ", ";
    }
    result = result.TrimEnd(',');

    return result;
}
        

    }
}
