using Microsoft.EntityFrameworkCore;
using BillBoardAPI.Models.Blog;

namespace BillBoardAPI.Contexts.Blog
{
    public interface IBlogContext
    {
        DbSet<BlogModel> blogModel { get; set; }
        int BlogSaveChange();
    }
}