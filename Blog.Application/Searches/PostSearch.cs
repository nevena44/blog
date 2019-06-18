using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class PostSearch
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int UserId { get; set; }

        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}
