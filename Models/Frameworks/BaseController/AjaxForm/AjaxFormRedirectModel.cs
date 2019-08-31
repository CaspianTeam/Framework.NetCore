using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm
{
    public class AjaxFormRedirectModel
    {
        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; } = ResponseReturnType.Redirect;
        public string Redirect { get; set; }
    }
}
