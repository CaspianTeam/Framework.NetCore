using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm
{
    public class AjaxFormJavaScriptExecuteFunctionModel
    {
        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; } = ResponseReturnType.JavaScriptExecuteFunction;
        public string FunctionName { get; set; }
        public object ParameterModel { get; set; }
    }
}
