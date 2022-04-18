using BJ.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BJ.Data.Infrastructure;

namespace BJ.Service
{
    public class FactureService : Service<Facture>, IFactureService
    {
        public FactureService(IUnitofwork utwk) : base(utwk)
        {
        }
        public IList<Product> GetProdsByClient(Client client)
        {
            return GetMany(f => f.ClientFK == client.Cin).Select(f => f.Product).ToList();
        }
    }
}
