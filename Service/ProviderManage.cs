using ClassLibrary1;

namespace Service;

public class ProviderManage
{
    public ProviderManage()
    {
    }

    public IList<Provider> Providers { get; set; }

    private IList<Provider> GetProviderByName(string name)
    {
        return Providers
            .Where(provider => provider.UserName.Contains(name))
            .ToList();
    }
}