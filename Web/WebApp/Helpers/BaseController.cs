using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using WebMotors.ViewModel;

namespace WebMotors.Helpers
{
    public class BaseController : Controller
    {
        public IActionResult SmartResult(object model, bool isJsonResult = false)
        {
            if (Request.IsAjaxRequest())
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = 400;
                    if (Request.Method == "POST")
                    {
                        var errors = GetErrorFromModelState(ModelState);
                        return Json(errors);
                    }
                }

                if (isJsonResult)
                    return Json(model);
                else
                    return PartialView(model);
            }

            return View(model);
        }

        public IEnumerable<string> GetErrorFromModelState(ModelStateDictionary ms)
        {
            var errors = new List<string>();
            if (ms == null || ms.ErrorCount == 0)
                return errors;

            foreach (var item in ms.Values)
            {
                if (item == null || item.Errors == null || item.Errors.Count == 0)
                    continue;

                foreach (var error in item.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors;
        }

        public JsonResult ToDataTable<T>(PagedResult<T> pg) where T : class
        {
            var json = new
            {
                draw = 1,
                recordsTotal = pg.TotalResults,
                recordsFiltered = pg.PageSize,
                data = pg.Itens
            };

            return new JsonResult(json);
        }

        public void Log(Exception ex, string message)
        {

        }
    }
}