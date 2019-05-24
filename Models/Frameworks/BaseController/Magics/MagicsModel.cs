using System.Collections.Generic;
using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics.Alert;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics.KendoWindowHandler;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics
{
    public class MagicsModel
    {
        public MagicsModel()
        {
            ResponseReturnType = ResponseReturnType.Magics;
        }

        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; }

        public List<MagicAlertNotifyModel> Notifies { get; set; }
        public List<MagicResetFormModel> ResetForms { get; set; }
        public List<MagicKendoRefreshModel> KendoRefresh { get; set; }
        public List<MagicKendoWindowHandlerModel> KendoWindowHandler { get; set; }
    }

}
