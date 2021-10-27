using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BillBoardAPI.Contexts.Number;
using BillBoardAPI.Models.Number;
using BillBoardAPI.Services.Configure;

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
    }
}
