using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace finance_by_kubi.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public bool IsIncome { get; set; }


    public int CategoryId { get; set; }
    

    public int AccountId { get; set; }
    public Account Account { get; set; }




    private Category _category = null!;
    [JsonIgnore]
    public Category Category
    {
        get => _category;
        set => _category = value;
    }


    public Transaction(string description, decimal amount, bool isIncome, Category category)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Popis nesmí být prázdný.");
        }

        if (amount <= 0)
        {
            throw new ArgumentException("Zadej platnou částku.");
        }

        

        Description = description;
        Amount = amount;
        Date = DateTime.Now;
        IsIncome = isIncome;

        
        Category = category;
    }

    public Transaction(string description, decimal amount, bool isIncome, Category category, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Popis nesmí být prázdný.");
        }

        if (amount <= 0)
        {
            throw new ArgumentException("Zadej platnou částku.");
        }



        Description = description;
        Amount = amount;
        Date = date;
        IsIncome = isIncome;

        
        Category = category;
    }
    public Transaction() { }

}
