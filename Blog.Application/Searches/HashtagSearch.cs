using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class HashtagSearch
    {
        public string Name { get; set; }

        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}
