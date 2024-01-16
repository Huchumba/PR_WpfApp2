using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.News;

namespace WpfApp2.News
{
    public interface INewsService
    {
        [Get("/news")]
        Task<List<NewsDTO>> Index();

        [Get("/news/{id}")]
        Task<NewsDTO> Details(int id);

        [Post("/news")]
        Task<NewsDTO> Create([Body] NewsCreateDTO item);

        [Post("/news/{id}")]
        Task<NewsDTO> Edit(int id, [Body] NewsCreateDTO item);

        [Delete("/news/{id}")]
        Task Delete(int id);
    }

}
