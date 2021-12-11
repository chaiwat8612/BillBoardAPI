using System.Collections.Generic;
using BillBoardAPI.Models.Number;
using BillBoardAPI.Models.Result;

namespace BillBoardAPI.Services.Number
{
    public interface INumberService
    {
        List<NumberModel> GetNumberList();
        ResultModel SaveNewNumber(SaveNewNumberModel saveNewnumberModel);
    }
}