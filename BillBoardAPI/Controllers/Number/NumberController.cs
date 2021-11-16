using Microsoft.AspNetCore.Mvc;
using BillBoardAPI.Models.Number;
using BillBoardAPI.Models.Result;
using BillBoardAPI.Services.Number;

namespace BillBoardAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Number")]

    public class NumberController : Controller
    {
        readonly private INumberService _numberService;

        public NumberController(INumberService numberService)
        {
            this._numberService = numberService;
        }

        [HttpGet("GetNumberListHomePage")]
        public JsonResult GetNumberListHomePage()
        {
            ResultModel numberResult = new ResultModel
            {
                status = 200,
                message = "Success",
                data = this._numberService.GetNumberListHomepage()
            };
            return Json(numberResult);
        }

        [HttpPost("SaveNewNumber")]
        public JsonResult SaveNewNumber([FromBody]SaveNewNumberModel saveNewNumber)
        {
            ResultModel resultNewNumberModel = this._numberService.SaveNewNumber(saveNewNumber);
            return Json(resultNewNumberModel);
        }
    }
}
