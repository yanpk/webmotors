using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Application;
using WebMotors.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebMotors.ViewComponent
{
    public class MarcaDropDownListViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        public MarcaDropDownListViewComponent()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id, string tagName = "selectMarca")
        {
            var ddl = new List<SelectListItem>();

            HttpClient client = new HttpClient();

            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Teste");

                var stringTask = client.GetStringAsync("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make");

                var msg = await stringTask;
                var model = JsonConvert.DeserializeObject<List<MarcaViewModel>>(msg);

                foreach (var item in model)
                {
                    var listItem = new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name,
                        Selected = (id.HasValue && item.Id == id.Value)
                    };
                    ddl.Add(listItem);
                }
                ViewBag.Nome = tagName;
                ViewBag.TextoAlternativo = "Selecione uma marca";
                ViewBag.CssClass = "basic-autocomplete";
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
