using Microsoft.EntityFrameworkCore;
using BillBoardAPI.Models.Number;

namespace BillBoardAPI.Contexts.Number
{
    public interface INumberContext
    {
        DbSet<NumberModel> numberModel { get; set; }
        int NumberSaveChange();
    }
}