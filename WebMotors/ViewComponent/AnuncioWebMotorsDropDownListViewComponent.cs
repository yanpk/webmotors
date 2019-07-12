using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Application;
using WebMotors.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMotors.ViewComponent
{
    public class AnuncioWebMotorsDropDownListViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly AnuncioWebMotorsApp _app;

        public AnuncioWebMotorsDropDownListViewComponent(AnuncioWebMotorsApp app)
        {
            _app = app;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id, string tagName = "selectMarca")
        {
            var itens = new List<AnuncioWebMotorsViewModel>();
            var ddl = new List<SelectListItem>();
            try
            {
                var listAll = await _app.GetAllAsync();
                foreach (var item in listAll)
                {
                    var listItem = new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Marca +" - " + item.Modelo,
                        Selected = (id.HasValue && item.Id == id.Value)
                    };
                    ddl.Add(listItem);
                }
                ViewBag.Nome = tagName;
                ViewBag.TextoAlternativo = "Selecione um Anuncio";
                ViewBag.CssClass = "js-example-basic-single";
                ViewBag.SelectedValue = id;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao processar sua requisição. " + ex.Message);
            }
            return View("~/Views/Shared/_DropDownList.cshtml", ddl);
        }
    }
}
