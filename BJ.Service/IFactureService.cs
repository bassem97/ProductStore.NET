using BJ.domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Service
{
    public interface IFactureService : IService<Facture>
    {
        public IList<Product> GetProdsByClient(Client client);
    }
}
