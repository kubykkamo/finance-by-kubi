using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace finance_by_kubi.Models;


public class Category {

    public string Name { get; set; } = string.Empty;

    public int Id { get; set; }
    public string? Color { get; set; }


    public int? AccountId { get; set; }
    public Account Account { get; set; }


    public List<Transaction> Transactions { get; set; } = new();
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
