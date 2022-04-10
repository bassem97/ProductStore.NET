using BJ.domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BJ.Service
{
    public class FactureService : Service<Facture>, IFactureService
    {
        public IList<Product> GetProdsByClient(Client client)
        {
            return GetMany(f => f.ClientFK == client.Cin).Select(f => f.Product).ToList();
        }
    }
}
