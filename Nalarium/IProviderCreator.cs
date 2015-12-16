#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium
{
    public interface IProviderCreator<T>
    {
        T Create(params string[] parameterArray);
    }
}