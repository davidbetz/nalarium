#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    public interface IProviderFactory<T>
    {
        T Create(params string[] parameterArray);
    }
}