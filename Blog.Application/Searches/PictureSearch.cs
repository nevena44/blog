using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class PictureSearch
    {
        public string Alt { get; set; }

        public int PostId { get; set; }

        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}
