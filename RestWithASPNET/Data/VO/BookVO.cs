using RestWithASPNET.Model.Base;
using System;

namespace RestWithASPNET.Data.VO
{
    public class BookVO : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}