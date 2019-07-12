using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMotors.Application;
using WebMotors.ViewModel;
using WebMotors.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebMotors.Controllers
{
    public class AnuncioWebMotorsController : BaseController
    {
        private readonly AnuncioWebMotorsApp _app;
        public AnuncioWebMotorsController(AnuncioWebMotorsApp app)
        {
            _app = app;
        }
        public async Task<IActionResult> Index(int page = 0, int pageSize = 30, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            var result = new PagedResult<AnuncioWebMotorsViewModel>();

            try
            {
                result = await _app.GetAllAsync(page, pageSize, textSearch, orderBy, ascending);
            }
            catch (Exception ex)
            {
                Log(ex, "tb_AnuncioWebmotorsController.Index");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Table(int page = 0, int pageSize = 30, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            var result = new PagedResult<AnuncioWebMotorsViewModel>();

            try
            {
                result = await _app.GetAllAsync(page, pageSize, textSearch, orderBy, ascending);

                return PartialView(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao processar sua solicitação.");
                Log(ex, "tb_AnuncioWebmotorsController.Index");
            }
            return SmartResult(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new AnuncioWebMotorsViewModel();
            return SmartResult(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AnuncioWebMotorsViewModel vm)
        {
            if (!ModelState.IsValid)
                return SmartResult(vm);

            try
            {
                _app.Create(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao processar sua requisição.");
                Log(ex, "tb_AnuncioWebmotorsController.Create.Post");
            }
            return SmartResult(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _app.GetAsync(id);
            return SmartResult(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AnuncioWebMotorsViewModel vm)
        {
            if (!ModelState.IsValid)
                return SmartResult(vm);

            try
            {
                _app.Edit(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao processar sua requisição.");
                Log(ex, "tb_AnuncioWebmotorsController.Create.Post");
            }
            return SmartResult(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            bool deleted = false;
            try
            {
                _app.Delete(id);
                deleted = true;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao processar sua requisição.");
                Log(ex, "tb_AnuncioWebmotorsController.Create.Post");
            }
            return SmartResult(deleted, deleted);
        }

        [HttpGet]
        public async Task<JsonResult> GetModelos(int idMarca)
        {
            HttpClient client = new HttpClient();
            List<ModeloViewModel> model = null;

            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Teste");

                var stringTask = client.GetStringAsync("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID="+idMarca);

                var msg = await stringTask;
                model = JsonConvert.DeserializeObject<List<ModeloViewModel>>(msg);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao processar sua requisição. "+ ex.Message);
            }

            return Json(model);

        }

        [HttpGet]
        public async Task<JsonResult> GetVersao(int idModelo)
        {
            HttpClient client = new HttpClient();
            List<VersaoViewModel> model = null;

            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Teste");

                var stringTask = client.GetStringAsync("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=" + idModelo);

                var msg = await stringTask;
                model = JsonConvert.DeserializeObject<List<VersaoViewModel>>(msg);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao processar sua requisição. " + ex.Message);
            }

            return Json(model);

        }

        public IActionResult DropDownList(int? id)
        {
            return ViewComponent("tb_AnuncioWebmotorsDropDownList", new { id = id });
        }
    }
}