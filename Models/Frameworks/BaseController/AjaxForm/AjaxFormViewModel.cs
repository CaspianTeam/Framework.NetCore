using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm
{
    public class AjaxFormViewModel
    {
        public AjaxFormViewModel()
        {
            ResponseReturnType = ResponseReturnType.ViewModel;
        }

        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; }
        public object ViewModel { get; set; }
    }
}
