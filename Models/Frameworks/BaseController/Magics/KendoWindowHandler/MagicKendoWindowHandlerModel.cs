using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.Magics.KendoWindowHandler;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics.KendoWindowHandler
{
    public class MagicKendoWindowHandlerModel
    {
        public MagicKendoWindowHandlerModel()
        {
            KendoWindowOptionModel = new KendoWindowOptionModel {Width = "80%"};
        }

        public string KendoWindowId { get; set; }

        /// <summary>
        /// KendoWindowActionType Enum
        /// </summary>
        public KendoWindowActionType KendoWindowActionType { get; set; }

        /// <summary>
        /// KendoWindowOptionModel Model
        /// </summary>
        public KendoWindowOptionModel KendoWindowOptionModel { get; set; }

    }

}
