using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm
{
    public class AjaxFormJavaScriptExecuteFunctionModel
    {
        public AjaxFormJavaScriptExecuteFunctionModel()
        {
            ResponseReturnType = ResponseReturnType.JavaScriptExecuteFunction;
        }

        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; }
        public string FunctionName { get; set; }
        public object ParameterModel { get; set; }
    }
}
