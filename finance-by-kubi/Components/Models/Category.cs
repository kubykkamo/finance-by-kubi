using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace finance_by_kubi.Models;


public class Category {

    public string Name { get; set; }

  
    public Category() { }

    public override string ToString() => Name;



    public Category(string description) 
    {
        if (string.IsNullOrWhiteSpace(description)) 
        {
            throw new ArgumentException("Nebyl zadán název kategorie!");
        }
        Name = description;
    }
    


    

};
