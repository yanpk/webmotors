using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.ViewModel
{
    public class PagedResult<T> : IPagedResult<T> where T : class
    {
        private int _totalPages = 0;
        public int TotalResults { get; set; }

        public int PageSize { get; set; } = 30;

        public int PageNumber { get; set; }

        public int TotalPages
        {
            get
            {
                if (_totalPages > 0)
                    return _totalPages;

                var qtdItens = decimal.Parse(this.TotalResults.ToString());
                var pageSize = decimal.Parse(this.PageSize.ToString());
                if (pageSize == 0M)
                    pageSize = 30;

                _totalPages = (int)Math.Ceiling(qtdItens / pageSize);
                return _totalPages;
            }
        }

        public int StartAt
        {
            get
            {
                return PageNumber - 3 > 0 ? PageNumber - 3 : 1;
            }
        }

        public int EndAt
        {
            get
            {
                return PageNumber + 3 < TotalPages ? PageNumber + 3 : TotalPages;

            }
        }

        public bool EnableNext
        {
            get
            {
                return PageNumber < TotalPages;
            }
        }

        public bool EnablePrevious
        {
            get
            {
                return PageNumber > 1;
            }
        }
        public IEnumerable<T> Itens { get; set; }
    }
}
