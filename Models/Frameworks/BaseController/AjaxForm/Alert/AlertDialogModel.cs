using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;
using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm.Alert;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm.Alert
{
    public class AlertDialogModel
    {
        public AlertDialogModel()
        {
            ResponseReturnType = ResponseReturnType.Alert;
            AlertType = AlertType.Dialog;
        }

        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType { get; set; }

        /// <summary>
        /// Enum: AlertType
        /// </summary>
        public AlertType AlertType { get; set; }
        public string MessageText { get; set; }

        /// <summary>
        /// Enum: ExtraMessageType
        /// </summary>
        public MessageType MessageType { get; set; } 
        public string MessageTitle { get; set; }
        public bool BackgroundDismiss { get; set; } = false;
        public bool ShowOkButton { get; set; } = true;
        public string OkButtonText { get; set; }
        public string OkButtonFunctionName { get; set; }
        public string OkButtonClass { get; set; }
        public bool ShowCancelButton { get; set; } = false;
        public string CancelButtonText { get; set; }
        public string CancelButtonFunctionName { get; set; }
        public bool ShowOk2Button { get; set; } = false;
        public string Ok2ButtonText { get; set; }
        public string Ok2ButtonFunctionName { get; set; }
        public string Ok2ButtonClass { get; set; }
    }

}
