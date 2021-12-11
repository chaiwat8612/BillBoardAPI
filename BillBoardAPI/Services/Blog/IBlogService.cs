using System.Collections.Generic;
using BillBoardAPI.Models.Blog;
using BillBoardAPI.Models.Result;

namespace BillBoardAPI.Services.Blog
{
    public interface IBlogService
    {
        List<BlogModel> GetBlogList();
        BlogModel GetBlogById(string blogId);
        ResultModel SaveNewBlog(SaveNewBlogModel saveNewnumberModel);
    }
}