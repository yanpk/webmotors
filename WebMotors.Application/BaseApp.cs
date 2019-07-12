using WebMotors.Application.Configuration;
using System.Threading.Tasks;
using WebMotors.Interface;
using Microsoft.Extensions.DependencyInjection;


namespace WebMotors.Application
{
    public class BaseApp
    {
        private IUnitOfWork _unitOfWork;

        public BaseApp(IUnitOfWork unitOfWork, AutoMapperConfiguration autoMapper)
        {
            _unitOfWork = unitOfWork;
            autoMapper.Configure();
        }
        internal void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }
        internal int Commit()
        {
            return _unitOfWork.Commit();
        }
        internal async Task<int> CommitAsync()
        {
            return await _unitOfWork.CommitAsync();
        }
    }
}
