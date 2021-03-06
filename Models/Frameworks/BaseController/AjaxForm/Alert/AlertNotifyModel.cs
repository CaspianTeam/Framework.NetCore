﻿using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm;
using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm.Alert;

namespace CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm.Alert
{
    public class AlertNotifyModel
    {
        public AlertNotifyModel()
        {
            ResponseReturnType = ResponseReturnType.Alert;
            AlertType = AlertType.Notify;
        }

        /// <summary>
        /// Enum: ResponseReturnType
        /// </summary>
        public ResponseReturnType ResponseReturnType{ get; set; }

        /// <summary>
        /// Enum: AlertType
        /// </summary>
        public AlertType AlertType { get; set; }
        public string MessageText { get; set; }

        /// <summary>
        /// Enum: MessageType
        /// </summary>
        public MessageType MessageType { get; set; }
        public string Url { get; set; }
    }

}
