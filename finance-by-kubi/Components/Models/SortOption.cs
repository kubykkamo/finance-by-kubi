using System;
using System.Collections.Generic;
using System.Text;

namespace finance_by_kubi.Models;

public class SortOption 
{ 
    public string DisplayName { get; set; }
    public SortType Type { get; set; }


}

public enum SortType
{
    ByDateAsc,
    ByDateDesc,
    ByAmountAsc,
    ByAmountDesc,
    ByNameAsc,
    ByNameDesc
}
