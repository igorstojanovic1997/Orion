using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Orion.Utilities
{
    public static class Utilities
    {
        public static string RenderPartialToString(string viewName, object model, ControllerContext ControllerContext)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");
            ViewDataDictionary ViewData = new ViewDataDictionary();
            TempDataDictionary TempData = new TempDataDictionary();
            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }

        }


        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
        public sealed class WhiteListAttribute : ValidationAttribute
        {
            /// <summary>
            /// The White List 
            /// </summary>
            public IEnumerable<byte> WhiteList
            {
                get;
            }

            /// <summary>
            /// The only constructor
            /// </summary>
            /// <param name="whiteList"></param>
            public WhiteListAttribute(params byte[] whiteList)
            {
                WhiteList = new List<byte>(whiteList);
            }

            /// <summary>
            /// Validation occurs here
            /// </summary>
            /// <param name="value">Value to be validate</param>
            /// <returns></returns>
            public override bool IsValid(object value)
            {
                return WhiteList.Contains((byte)value);
            }

            /// <summary>
            /// Get the proper error message
            /// </summary>
            /// <param name="name">Name of the property that has error</param>
            /// <returns></returns>
            public override string FormatErrorMessage(string name)
            {
                return $"{name} must have one of these values: {string.Join(",", WhiteList)}";
            }

        }
    }
}