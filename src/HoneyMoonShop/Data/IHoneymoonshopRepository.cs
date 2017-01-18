using System.Collections.Generic;
using HoneymoonShop.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Data
{
    public interface IHoneymoonshopRepository
    {
        IEnumerable<Jurk> Jurken { get; }
        IEnumerable<Afspraak> Afspraken { get; }

        void SaveJurk(Jurk jurk);
        void SaveAfspraak(Afspraak afspraak);

        Jurk DeleteJurk(int id);
        Afspraak DeleteAfspraak(int id);
    }
}
