using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm.Alert;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics.Alert
{
    public class MagicAlertNotifyModel
    {
        public string MessageText { get; set; }

        /// <summary>
        /// Enum: MessageType
        /// </summary>
        public MessageType MessageType { get; set; }
        public string Url { get; set; }
    }

}
