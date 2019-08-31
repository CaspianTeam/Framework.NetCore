using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;
using Microsoft.AspNetCore.Mvc;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm
{
    public class AjaxFormModelStateModel
    {
        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; } = ResponseReturnType.ModelState;
        public BadRequestObjectResult ModelState { get; set; }
    }
}
