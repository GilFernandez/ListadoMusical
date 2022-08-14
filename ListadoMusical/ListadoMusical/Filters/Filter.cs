 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using ListadoMusical.Controllers;
using ListadoMusical.Models;
using Microsoft.Ajax.Utilities;

namespace ListadoMusical.Filters
{
    public class Filter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var oUsuario = (Usuario)HttpContext.Current.Session["User"];
            

            
            if (oUsuario == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }


}