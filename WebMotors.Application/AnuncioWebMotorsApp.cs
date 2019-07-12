using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.ViewModel;
using WebMotors.Model;
using WebMotors.Application.Configuration;
using WebMotors.Interface;

namespace WebMotors.Application
{
    public class AnuncioWebMotorsApp : BaseApp
    {
        private readonly IAnuncioWebMotorsRepository _rep;

        public AnuncioWebMotorsApp(IAnuncioWebMotorsRepository rep, IUnitOfWork unitOfWork, AutoMapperConfiguration autoMapper) : base(unitOfWork, autoMapper)
        {
            _rep = rep;
        }

        public int Create(AnuncioWebMotorsViewModel vm)
        {
            var obj = Mapper.Map<AnuncioWebMotorsViewModel, AnuncioWebMotors>(vm);
            BeginTransaction();
            _rep.Add(obj);
            return Commit();
        }

        public int Delete(int id)
        {
            BeginTransaction();
            _rep.Delete(id);
            return Commit();
        }

        public int Delete(AnuncioWebMotorsViewModel vm)
        {
            return Delete(vm.Id);
        }

        public int Edit(AnuncioWebMotorsViewModel vm)
        {
            var obj = _rep.Get(vm.Id);
            obj.Id = vm.Id;
            obj.Marca = vm.Marca;
            obj.Modelo = vm.Modelo;
            obj.Versao = vm.Versao;
            obj.Ano = vm.Ano;
            obj.Quilometragem = vm.Quilometragem;
            obj.Observacao = vm.Observacao;
            BeginTransaction();
            _rep.Update(obj);
            return Commit();
        }

        public IEnumerable<AnuncioWebMotorsViewModel> GetAll()
        {
            var obj = _rep.GetAll();
            var vm = Mapper.Map<IEnumerable<AnuncioWebMotorsViewModel>>(obj);
            return vm;
        }

        public PagedResult<AnuncioWebMotorsViewModel> GetAll(int page = 1, int pageSize = 30, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            var result = new PagedResult<AnuncioWebMotorsViewModel>();
            var models = _rep.GetAll(page, pageSize, textSearch, orderBy, ascending);
            result.PageNumber = page;
            result.PageSize = pageSize;
            result.Itens = Mapper.Map<IEnumerable<AnuncioWebMotorsViewModel>>(models);
            result.TotalResults = _rep.Count(textSearch);
            return result;
        }

        public async Task<IEnumerable<AnuncioWebMotorsViewModel>> GetAllAsync()
        {
            var models = await _rep.GetAllAsync();

            return Mapper.Map<IEnumerable<AnuncioWebMotorsViewModel>>(models);
        }

        public async Task<PagedResult<AnuncioWebMotorsViewModel>> GetAllAsync(int page = 1, int pageSize = 30, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            var result = new PagedResult<AnuncioWebMotorsViewModel>();
            var models = await _rep.GetAllAsync(page, pageSize, textSearch, orderBy, ascending);
            result.PageNumber = page;
            result.PageSize = pageSize;
            result.Itens = Mapper.Map<IEnumerable<AnuncioWebMotorsViewModel>>(models);
            result.TotalResults = await _rep.CountAsync(textSearch);

            return result;
        }

        public int Save(AnuncioWebMotorsViewModel vm)
        {
            if (vm.Id == 0)
                return Create(vm);
            else
                return Edit(vm);
        }

        public AnuncioWebMotorsViewModel Get(int id)
        {
            var obj = _rep.Get(id);
            return Mapper.Map<AnuncioWebMotorsViewModel>(obj);
        }

        public async Task<AnuncioWebMotorsViewModel> GetAsync(int id)
        {
            var obj = await _rep.GetAsync(id);
            return Mapper.Map<AnuncioWebMotorsViewModel>(obj);
        }
    }
}
