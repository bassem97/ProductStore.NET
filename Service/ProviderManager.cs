using ClassLibrary1;

namespace Service;

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
    public IList<Provider> GetFirst5ProviderByName(string name)
    {
        return Providers
            .Where(provider => provider.UserName.Contains(name))
            .Take(5)
            .ToList();
    }
    
    public Provider GetProviderById(int id)
    {
        return Providers
            .First(provider => provider.Id == id);

    }

    
}