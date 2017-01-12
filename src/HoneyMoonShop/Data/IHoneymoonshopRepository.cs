using System.Collections.Generic;
using HoneymoonShop.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Data
{
    public interface IHoneymoonshopRepository
    {
        IEnumerable<Jurk> Jurken { get; }

        void SaveJurk(Jurk jurk);

        Jurk DeleteJurk(int id);
    }
}
