using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces
{
    public interface ISearchable
    {
        bool MatchesQuery(string query);
    }
}
