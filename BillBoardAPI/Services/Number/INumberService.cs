using System.Collections.Generic;
using BillBoardAPI.Models.Number;

namespace BillBoardAPI.Services.Number
{
    public interface INumberService
    {
        List<NumberModel> GetNumberListHomepage();
    }
}