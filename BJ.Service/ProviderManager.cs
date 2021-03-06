using ClassLibrary1;

namespace BJ.Service;

public class ProviderManage
{
    public ProviderManage()
    {
    }

    public IList<Provider> Providers { get; set; }

    public IList<Provider> GetProviderByName(string name)
    {
        return Providers
            .Where(provider => provider.UserName.Contains(name))
            .ToList();
    }
    public Provider GetFirstProviderByName(string name)
    {
        return Providers
            .Where(provider => provider.UserName.StartsWith(name))
            .Single();
    }
    
    public Provider GetProviderById(int id)
    {
        return Providers
            .First(provider => provider.Id == id);

    }

    
}