using System;
using System.Collections.Generic;

namespace WebMotors.ViewModel
{
    public interface IPagedResult<T> : IPagedResultBase where T : class
    {
        IEnumerable<T> Itens { get; set; }
    }
}
