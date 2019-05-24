using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm
{
    public class AjaxFormRedirectModel
    {
        public AjaxFormRedirectModel()
        {
            ResponseReturnType = ResponseReturnType.Redirect;
        }

        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; }
        public string Redirect { get; set; }
    }
}
