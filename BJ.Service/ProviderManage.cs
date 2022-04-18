using BJ.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BJ.Service
{
    public class ProviderManage
    {
        IList<Provider> Providers { get; set; }
        public List<Provider> GetProviderByName(string name)
        {
            return (from p in Providers
                    where p.Name.Contains(name)
                    select p
                   ).ToList();
        }

        public List<Provider> GetProviderByName2(string name)
        {
            return Providers.Where (p => p.Name.Contains(name)).ToList();
        }
        public Provider GetFirstProviderByName3(string name)
        {
            return (from p in Providers
                    where p.Name.StartsWith(name)
                    select p).First();
        }
        public Provider GetProviderByName4(string name)
        {
            return Providers.Where(p => p.Name.StartsWith(name)).First();
        }

        public Provider GetProvideById(int id)
        {
            return (from p in Providers
                    where p.Id == id
                    select p).Single();
        }
        public Provider GetProvideById2(int id)
        {
            return Providers.Where(p => p.Id==id).Single();
        }

        
    }


}
