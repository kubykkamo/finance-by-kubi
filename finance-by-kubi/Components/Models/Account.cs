using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace finance_by_kubi.Models;

public class Account
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Transaction> Transactions{ get; set; }
    public List<Category> Categories { get; set; }
    private const string filePath = "account_data.json";

    public List<Category> GetAllCategories()
    {
        return Categories;
    }

    public List<Transaction> GetAllTransactions() 
    {

        return Transactions;
    }
    public void AddTransaction(string desc, decimal amount, bool isIncome, Category category) 
    {
        
        var transaction = new Transaction(desc, amount, isIncome, category);
        Transactions.Add(transaction);
    }

    public void RemoveTransaction(Transaction t) 
    {
        Transactions.Remove(t);
    }

    public void AddCategory(string name) 
    { 
        Categories.Add(new Category(name));
    }

   
    public decimal TotalIncome => Transactions
        .Where(t => t.IsIncome == true)
        .Sum(t => t.Amount);
    public decimal TotalOutcome => Transactions
        .Where(t => t.IsIncome == false)
        .Sum(t => t.Amount);
    public decimal Balance => TotalIncome - TotalOutcome;

    

    public Account(List<Transaction> transactions, List<Category> categories)
    {
        Transactions = transactions;
        Categories = categories;
        foreach (var t in transactions)
        {

            t.Category = Categories.FirstOrDefault(c => c.Name == t.Category?.Name);
        }



    }

    public List<Transaction> GetSortedTransactions(SortType sortType, List<Transaction> t) 
    {
       
        return sortType switch
        {
            SortType.ByDateDesc => t.OrderByDescending(t => t.Date).ToList(),
            SortType.ByDateAsc => t.OrderBy(t => t.Date).ToList(),
            SortType.ByNameDesc => t.OrderByDescending(t => t.Description).ToList(),
            SortType.ByNameAsc => t.OrderBy(t => t.Description).ToList(),
            SortType.ByAmountDesc => t.OrderByDescending(t => t.Amount).ToList(),
            SortType.ByAmountAsc => t.OrderBy(t => t.Amount).ToList(),
            _=> t.ToList()
            
        };

    }

    public List<Transaction> DateOrderedTransactions() 
    { 
        return Transactions
            .OrderByDescending(t => t.Date)
            .ToList();
    }

    public List <Transaction> GetFilteredTransactions(Category category)
    {
        
        
        var transactions = Transactions
            .Where(t => t.Category == category)
            
            .ToList();

       if(transactions.Count == 0) 
        {
            throw new ArgumentException("Zvolené kategorii neodpovídají žádné transkace!");
        }

        return transactions;
    }

    public List<Transaction> GetFilteredSortedTransactions(Category category, SortType sortType) 
    {
        var catTransactions = GetFilteredTransactions(category);

        var sortedTransactions = GetSortedTransactions(sortType, catTransactions);

        return sortedTransactions;

    }

    public Account() 
    {

    }

 
}