using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BillBoardAPI.Contexts.Number;
using BillBoardAPI.Models.Number;
using BillBoardAPI.Services.Configure;
using BillBoardAPI.Models.Result;

namespace BillBoardAPI.Services.Number
{
    public class NumberService : INumberService
    {
        readonly private ConfigureService _config = new ConfigureService();
        readonly private IConfiguration _getConfig;
        readonly private INumberContext _numberContext;

        readonly private string _statusInActive = "N";
        readonly private string _bannerImage = ""; 

        public NumberService(INumberContext numberContext)
        {
            #region "Get_config"
            _getConfig = _config.GetConfigFromAppsetting();
            //_bannerImage = _getConfig["Config:__"];
            #endregion

            this._numberContext = numberContext;
        }

        public List<NumberModel> GetNumberListHomepage()
        {
            return GenList(this._numberContext.numberModel
                    .Where(m => m.status != _statusInActive)
                    .OrderBy(m => m.numberId)
                    .ToList());
        }

        private List<NumberModel> GenList(List<NumberModel> numberList)
        {
            return numberList;
        }

        public ResultModel SaveNewNumber(SaveNewNumberModel saveNewnumberModel)
        {
            string errorMessage = "";
            ResultModel result = new ResultModel();

            NumberModel numberModel = new NumberModel();

            string maxTransactionNumber = GetMaxTransactionNumber();

            numberModel.numberId = maxTransactionNumber;
            numberModel.status = saveNewnumberModel.status;
            numberModel.numberValue = saveNewnumberModel.numberValue;

            if (IsSaveNewNumber(numberModel))
            {
                result.status = 200;
                result.message = "Success";
            }
            else
            {
                ErrorModel errorModel = new ErrorModel
                {
                    code = 505,
                    message = errorMessage,
                    target = "S3"
                };
                result.status = 500;
                result.message = "Save New Number Fail."; 
            }

            return result;
        }

        public bool IsSaveNewNumber(NumberModel numberModel)
        {
            this._numberContext.numberModel.Add(numberModel);
            return this._numberContext.NumberSaveChange() > 0 ? true : false;
        }

        public string GetMaxTransactionNumber()
        {
            return this._numberContext.numberModel.Max(m => m.numberId);
        }
    }
}
