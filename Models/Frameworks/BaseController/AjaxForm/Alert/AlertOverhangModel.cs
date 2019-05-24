using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;
using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm.Alert;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm.Alert
{
    public class AlertOverhangModel
    {
        public AlertOverhangModel()
        {
            ResponseReturnType = ResponseReturnType.Alert;
            AlertType = AlertType.Overhang;
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
        /// Enum: MessageType
        /// </summary>
        public MessageType MessageType { get; set; } = MessageType.Info;
        public bool AutomaticClose { get; set; } = true;
        public bool DimBackground { get; set; } = true;
        public bool Html { get; set; } = false;
    }

}
