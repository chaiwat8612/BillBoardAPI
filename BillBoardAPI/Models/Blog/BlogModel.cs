using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillBoardAPI.Models.Blog
{
    [Table("blogTab")]
    public class BlogModel
    {
        public string blogId { get; set; }
        public string blogDescription { get; set; }
    }

    public class SaveNewBlogModel
    {
        public string blogDescription { get; set; }
    }
}