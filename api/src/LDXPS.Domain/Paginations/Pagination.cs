using System;
using System.Collections.Generic;

namespace LDXPS.Domain.Paginations
{
    public class Pagination<T> where T : class
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages => (int)Math.Ceiling(Total / (double)PerPage);

        public IEnumerable<T> Data { get; set; }
        public string OrderByField { get; set; }
        public bool OrderByAscending { get; set; }

        public Pagination()
        {
            Page = 1;
            PerPage = 20;
            OrderByField = "Codigo";
            OrderByAscending = true;
        }
        public Pagination(int perPage, int page) : this()
        {
            Page = page;
            PerPage = perPage;
        }
    }
}
