using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm.Alert;
using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.Magics;
using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.Magics.KendoWindowHandler;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm.Alert;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics.Alert;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.Magics.KendoWindowHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaspianTeam.Framework.NetCore.Frameworks.BaseControllers
{
    public class BaseController : Controller
    {
        #region AjaxForm

        #region Alert

        #region AlertOverhang
        protected virtual JsonResult AjaxFormAlertOverhangSuccessful(
            string successfulMessage = "",
            bool automaticClose = true,
            bool dimBackground = true,
            bool html = false)
        {
            return Json(new AlertOverhangModel
            {
                MessageText = string.IsNullOrEmpty(successfulMessage) ? "عملیات با موفقیت انجام شد" : successfulMessage,
                MessageType = MessageType.Success,
                AutomaticClose = automaticClose,
                DimBackground = dimBackground,
                Html = html
            });
        }

        protected virtual JsonResult AjaxFormAlertOverhangError(
            string errorMessage = "",
            bool automaticClose = true,
            bool dimBackground = true,
            bool html = false)
        {
            return Json(new AlertOverhangModel
            {
                MessageText = string.IsNullOrEmpty(errorMessage) ? "عملیات با خطا مواجه شد" : errorMessage,
                MessageType = MessageType.Error,
                AutomaticClose = automaticClose,
                DimBackground = dimBackground,
                Html = html
            });
        }

        protected virtual JsonResult AjaxFormAlertOverhangWarning(
            string warningMessage,
            bool automaticClose = true,
            bool dimBackground = true,
            bool html = false)
        {
            return Json(new AlertOverhangModel
            {
                MessageText = warningMessage,
                MessageType = MessageType.Warning,
                AutomaticClose = automaticClose,
                DimBackground = dimBackground,
                Html = html
            });
        }
        protected virtual JsonResult AjaxFormAlertOverhangInfo(
            string infoMessage,
            bool automaticClose = true,
            bool dimBackground = true,
            bool html = false)
        {
            return Json(new AlertOverhangModel
            {
                MessageText = infoMessage,
                MessageType = MessageType.Info,
                AutomaticClose = automaticClose,
                DimBackground = dimBackground,
                Html = html
            });
        }

        protected virtual JsonResult AjaxFormAlertOverhang(
            string messageText,
            MessageType messageType = MessageType.Success,
            bool automaticClose = true,
            bool dimBackground = true,
            bool html = false)
        {
            return Json(new AlertOverhangModel
            {
                MessageText = messageText,
                MessageType = messageType,
                AutomaticClose = automaticClose,
                DimBackground = dimBackground,
                Html = html
            });
        }

        #endregion

        #region AlertNotify

        protected virtual JsonResult AjaxFormAlertNotifySuccessful(
            string successfulMessage = "",
            string url = "")
        {
            return Json(new AlertNotifyModel
            {
                MessageText = string.IsNullOrEmpty(successfulMessage) ? "عملیات با موفقیت انجام شد" : successfulMessage,
                MessageType = MessageType.Success,
                Url = url
            });
        }

        protected virtual JsonResult AjaxFormAlertNotifyError(
            string errorMessage = "",
            string url = "")
        {
            return Json(new AlertNotifyModel
            {
                MessageText = string.IsNullOrEmpty(errorMessage) ? "عملیات با خطا مواجه شد" : errorMessage,
                MessageType = MessageType.Error,
                Url = url
            });
        }

        protected virtual JsonResult AjaxFormAlertNotifyWarning(
            string warningMessage,
            string url = "")
        {
            return Json(new AlertNotifyModel
            {
                MessageText = warningMessage,
                MessageType = MessageType.Warning,
                Url = url
            });
        }
        protected virtual JsonResult AjaxFormAlertNotifyInfo(
            string infoMessage,
            string url = "")
        {
            return Json(new AlertNotifyModel
            {
                MessageText = infoMessage,
                MessageType = MessageType.Info,
                Url = url
            });
        }

        protected virtual JsonResult AjaxFormAlertNotify(
            string messageText,
            MessageType messageType = MessageType.Success,
            string url = "")
        {
            return Json(new AlertNotifyModel
            {
                MessageText = messageText,
                MessageType = messageType,
                Url = url
            });
        }

        #endregion

        #region AlertDialog

        protected virtual JsonResult AjaxFormAlertDialogSuccessful(
            string successfulMessage = "",
            MessageType messageType = MessageType.Success,
            string messageTitle = "",
            bool backgroundDismiss = false,
            bool showOkButton = true,
            string okButtonText = "",
            string okButtonFunctionName = "",
            string okButtonClass = "",
            bool showCancelButton = false,
            string cancelButtonText = "",
            string cancelButtonFunctionName = "",
            bool showOk2Button = false,
            string ok2ButtonText = "",
            string ok2ButtonFunctionName = "",
            string ok2ButtonClass = "")
        {
            return Json(new AlertDialogModel
            {
                MessageText = string.IsNullOrEmpty(successfulMessage) ? "عملیات با موفقیت انجام شد" : successfulMessage,
                MessageType = messageType,
                MessageTitle = messageTitle,
                BackgroundDismiss = backgroundDismiss,
                ShowOkButton = showOkButton,
                OkButtonText = okButtonText,
                OkButtonFunctionName = okButtonFunctionName,
                OkButtonClass = okButtonClass,
                ShowCancelButton = showCancelButton,
                CancelButtonText = cancelButtonText,
                CancelButtonFunctionName = cancelButtonFunctionName,
                ShowOk2Button = showOk2Button,
                Ok2ButtonText = ok2ButtonText,
                Ok2ButtonFunctionName = ok2ButtonFunctionName,
                Ok2ButtonClass = ok2ButtonClass
            });
        }

        protected virtual JsonResult AjaxFormAlertDialogError(
            string erroeMessage = "",
            MessageType messageType = MessageType.Error,
            string messageTitle = "",
            bool backgroundDismiss = false,
            bool showOkButton = true,
            string okButtonText = "",
            string okButtonFunctionName = "",
            string okButtonClass = "",
            bool showCancelButton = false,
            string cancelButtonText = "",
            string cancelButtonFunctionName = "",
            bool showOk2Button = false,
            string ok2ButtonText = "",
            string ok2ButtonFunctionName = "",
            string ok2ButtonClass = "")
        {
            return Json(new AlertDialogModel
            {
                MessageText = string.IsNullOrEmpty(erroeMessage) ? "عملیات با خطا مواجه شد" : erroeMessage,
                MessageType = messageType,
                MessageTitle = messageTitle,
                BackgroundDismiss = backgroundDismiss,
                ShowOkButton = showOkButton,
                OkButtonText = okButtonText,
                OkButtonFunctionName = okButtonFunctionName,
                OkButtonClass = okButtonClass,
                ShowCancelButton = showCancelButton,
                CancelButtonText = cancelButtonText,
                CancelButtonFunctionName = cancelButtonFunctionName,
                ShowOk2Button = showOk2Button,
                Ok2ButtonText = ok2ButtonText,
                Ok2ButtonFunctionName = ok2ButtonFunctionName,
                Ok2ButtonClass = ok2ButtonClass
            });
        }

        protected virtual JsonResult AjaxFormAlertDialogWarning(
            string warningMessage,
            MessageType messageType = MessageType.Warning,
            string messageTitle = "",
            bool backgroundDismiss = false,
            bool showOkButton = true,
            string okButtonText = "",
            string okButtonFunctionName = "",
            string okButtonClass = "",
            bool showCancelButton = false,
            string cancelButtonText = "",
            string cancelButtonFunctionName = "",
            bool showOk2Button = false,
            string ok2ButtonText = "",
            string ok2ButtonFunctionName = "",
            string ok2ButtonClass = "")
        {
            return Json(new AlertDialogModel
            {
                MessageText = warningMessage,
                MessageType = messageType,
                MessageTitle = messageTitle,
                BackgroundDismiss = backgroundDismiss,
                ShowOkButton = showOkButton,
                OkButtonText = okButtonText,
                OkButtonFunctionName = okButtonFunctionName,
                OkButtonClass = okButtonClass,
                ShowCancelButton = showCancelButton,
                CancelButtonText = cancelButtonText,
                CancelButtonFunctionName = cancelButtonFunctionName,
                ShowOk2Button = showOk2Button,
                Ok2ButtonText = ok2ButtonText,
                Ok2ButtonFunctionName = ok2ButtonFunctionName,
                Ok2ButtonClass = ok2ButtonClass
            });
        }

        protected virtual JsonResult AjaxFormAlertDialogInfo(
            string infoMessage,
            MessageType messageType = MessageType.Info,
            string messageTitle = "",
            bool backgroundDismiss = false,
            bool showOkButton = true,
            string okButtonText = "",
            string okButtonFunctionName = "",
            string okButtonClass = "",
            bool showCancelButton = false,
            string cancelButtonText = "",
            string cancelButtonFunctionName = "",
            bool showOk2Button = false,
            string ok2ButtonText = "",
            string ok2ButtonFunctionName = "",
            string ok2ButtonClass = "")
        {
            return Json(new AlertDialogModel
            {
                MessageText = infoMessage,
                MessageType = messageType,
                MessageTitle = messageTitle,
                BackgroundDismiss = backgroundDismiss,
                ShowOkButton = showOkButton,
                OkButtonText = okButtonText,
                OkButtonFunctionName = okButtonFunctionName,
                OkButtonClass = okButtonClass,
                ShowCancelButton = showCancelButton,
                CancelButtonText = cancelButtonText,
                CancelButtonFunctionName = cancelButtonFunctionName,
                ShowOk2Button = showOk2Button,
                Ok2ButtonText = ok2ButtonText,
                Ok2ButtonFunctionName = ok2ButtonFunctionName,
                Ok2ButtonClass = ok2ButtonClass
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name='messageText' type='string'> Your message. HTML is allowed! </param>
        /// <param name='messageType' type='string'> Type Of ExtraMessageType : 'success'/'error'/'warning'/'info'/'purple'/'dark' - default is 'info' </param>
        /// <param name='messageTitle' type='string'> Optional </param>
        /// <param name='backgroundDismiss' type='string'> Click outside of alert box will close the alert. Default is FALSE </param>
        /// <param name='showOkButton' type='bool'> Show OK (confirm) button. Default is TRUE </param>
        /// <param name='okButtonText' type='string'> OK (confirm) button text. Default will be set based on alertType parameter </param>
        /// <param name='okButtonFunctionName' type='string'> OK (confirm) button callback function. Default is nothing (just close the alert) </param>
        /// <param name='okButtonClass' type='string'> 'btn-blue'/ 'btn-green'/ 'btn-red'/ 'btn-orange'/ 'btn-purple'/ 'btn-default'/ 'btn-dark'. Default will be set based on alertType parameter </param>
        /// <param name='showCancelButton' type='bool'> Show Cancel button. Use it in confirm alerts. Default is FALSE </param>
        /// <param name='cancelButtonText' type='string'> Text of cancel button. Default is 'انصراف' </param>
        /// <param name='cancelButtonFunctionName' type='string'> Cancel button callback function. Default is nothing (just close the alert) </param>
        /// <param name='showOk2Button' type='bool'> Another button in alert to do some actions. Default is FALSE </param>
        /// <param name='ok2ButtonText' type='string'> Default text is 'OK' </param>
        /// <param name='ok2ButtonFunctionName' type='string'> button callback function. Default is nothing (just close the alert) </param>
        /// <param name='ok2ButtonClass' type='string'> 'btn-blue'/ 'btn-green'/ 'btn-red'/ 'btn-orange'/ 'btn-purple'/ 'btn-default'/ 'btn-dark'. Default will be set based on alertType parameter </param>
        /// <returns></returns>
        protected virtual JsonResult AjaxFormAlertDialog(
            string messageText,
            MessageType messageType = MessageType.Success,
            string messageTitle = "",
            bool backgroundDismiss=false,
            bool showOkButton=true,
            string okButtonText="",
            string okButtonFunctionName="",
            string okButtonClass="",
            bool showCancelButton=false,
            string cancelButtonText="",
            string cancelButtonFunctionName="",
            bool showOk2Button=false,
            string ok2ButtonText="",
            string ok2ButtonFunctionName="",
            string ok2ButtonClass="")
        {
            return Json(new AlertDialogModel
            {
                MessageText = messageText,
                MessageType = messageType,
                MessageTitle = messageTitle,
                BackgroundDismiss = backgroundDismiss,
                ShowOkButton = showOkButton,
                OkButtonText = okButtonText,
                OkButtonFunctionName = okButtonFunctionName,
                OkButtonClass = okButtonClass,
                ShowCancelButton = showCancelButton,
                CancelButtonText = cancelButtonText,
                CancelButtonFunctionName = cancelButtonFunctionName,
                ShowOk2Button = showOk2Button,
                Ok2ButtonText = ok2ButtonText,
                Ok2ButtonFunctionName = ok2ButtonFunctionName,
                Ok2ButtonClass = ok2ButtonClass
            });
        }

        #endregion

        #endregion


        /// <summary>
        /// Return ModelState resulted by validation for Ajax-form
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public virtual BadRequestObjectResult AjaxFormModelState(ModelStateDictionary modelState)
        {
            return BadRequest(new AjaxFormModelStateModel
            {
                ModelState = BadRequest(modelState)
            });
        }

        /// <summary>
        /// ریدایرکت در حالت آژکس
        /// </summary>
        /// <param name="redirect">ادرس Url</param>
        /// <returns></returns>
        protected virtual JsonResult AjaxFormRedirect(string redirect)
        {
            return Json(new AjaxFormRedirectModel
            {
                Redirect = redirect
            });
        }

        /// <summary>
        /// شبیه سازی
        /// return View(ViewModel);
        /// در حالت آژکس فرم
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        protected virtual JsonResult AjaxFormViewModel<T>(T viewModel)
        {
            return Json(new AjaxFormViewModel
            {
                ViewModel = viewModel
            });
        }

        /// <summary>
        /// اجرا کردن تابع سمت جاوا اسکریپت
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="parameterModel"></param>
        /// <returns></returns>
        protected virtual JsonResult AjaxFormJavaScriptExecuteFunction(string functionName, object parameterModel = null)
        {
            return Json(new AjaxFormJavaScriptExecuteFunctionModel
            {
                FunctionName = functionName,
                ParameterModel = parameterModel
            });
        }

        #endregion

        #region Magics

        #region BaseMagics
        private MagicsModel GetMagics()
        {
            var viewDataMagics = (MagicsModel)ViewData["Magics"];
            if (viewDataMagics == null)
            {
                viewDataMagics = new MagicsModel();

                if (viewDataMagics.Notifies == null)
                    viewDataMagics.Notifies = new List<MagicAlertNotifyModel>();

                if (viewDataMagics.ResetForms == null)
                    viewDataMagics.ResetForms = new List<MagicResetFormModel>();

                if (viewDataMagics.KendoRefresh == null)
                    viewDataMagics.KendoRefresh = new List<MagicKendoRefreshModel>();

                if (viewDataMagics.KendoWindowHandler == null)
                    viewDataMagics.KendoWindowHandler = new List<MagicKendoWindowHandlerModel>();
            }

            return viewDataMagics;
        }

        private void SetMagics(MagicsModel magics)
        {
            ViewData["Magics"] = magics;

            HttpContext.Response.Cookies.Append("Magics", JsonConvert.SerializeObject(magics));
        }
        #endregion

        #region Alert

        /// <summary>
        /// ارسال نوتیفیکیشن در هر قسمت از اکشن و نمایش آن در پایان و بصورت لیستی از نوتیفیکیشن ها
        /// </summary>
        /// <param name="messageText"></param>
        /// <param name="messageType"></param>
        /// <param name="url"></param>
        protected virtual void MagicAlertNotify(
            string messageText,
            MessageType messageType = MessageType.Success,
            string url = "")
        {
            var magics = GetMagics();

            magics.Notifies.Add(new MagicAlertNotifyModel
            {
                MessageText = messageText,
                MessageType = messageType,
                Url = url
            });

            SetMagics(magics);
        }

        #endregion

        /// <summary>
        /// ریست و پاک کردن مقادیر فورم
        /// </summary>
        /// <param name="formId"></param>
        protected virtual void MagicResetForm(string formId)
        {
            var magics = GetMagics();

            magics.ResetForms.Add(new MagicResetFormModel
            {
                FormId = formId
            });

            SetMagics(magics);
        }

        /// <summary>
        /// رفرش کردن دیتای ابجکت های کندو
        /// </summary>
        /// <param name="kendoId"></param>
        /// <param name="kendoType"></param>
        protected virtual void MagicKendoRefresh(string kendoId, KendoType kendoType)
        {
            var magics = GetMagics();

            magics.KendoRefresh.Add(new MagicKendoRefreshModel
            {
                KendoId = kendoId,
                KendoType = kendoType
            });

            SetMagics(magics);
        }

        /// <summary>
        /// باز و بسته کردن مدال کندو
        /// </summary>
        /// <param name="kendoWindowId"></param>
        /// <param name="kendoWindowActionType"></param>
        /// <param name="kendoWindowOptionModel"></param>
        protected virtual void MagicKendoWindowHandler(
            string kendoWindowId,
            KendoWindowActionType kendoWindowActionType,
            KendoWindowOptionModel kendoWindowOptionModel = null)
        {
            var magics = GetMagics();

            if (kendoWindowOptionModel == null)
                kendoWindowOptionModel = new KendoWindowOptionModel {Width = "80%"};

            magics.KendoWindowHandler.Add(new MagicKendoWindowHandlerModel
            {
                KendoWindowId = kendoWindowId,
                KendoWindowActionType = kendoWindowActionType,
                KendoWindowOptionModel = kendoWindowOptionModel
            });

            SetMagics(magics);
        }

        #endregion
    }
}