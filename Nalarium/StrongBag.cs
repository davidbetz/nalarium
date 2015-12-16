#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium
{
    public class StrongBag
    {
        //- $Data -//

        //+
        //- @Ctor -//
        public StrongBag()
        {
            Data = new StringObjectMap();
        }

        private StringObjectMap Data { get; }

        //+
        //- @Get -//
        /// <summary>
        ///     Obtains a value (for reference types, GetReference is more efficient).
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T Get<T>(string name)
        {
            if (Data[name] is T)
            {
                return (T) Data[name];
            }
            //+
            return default(T);
        }

        /// <summary>
        ///     Obtains a value.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">Name of scope.</param>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T Get<T>(string scope, string name) where T : struct
        {
            return Get<T>(ScopeTranscriber.Construct(scope, name));
        }

        //(must be unique; scopes are recommended)
        //- @GetReference -//
        /// <summary>
        ///     Obtains an object reference.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T GetReference<T>(string name) where T : class
        {
            return Data[name] as T;
        }

        //- @GetReference -//
        /// <summary>
        ///     Obtains an object reference.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">Name of scope.</param>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T GetReference<T>(string scope, string name) where T : class
        {
            return GetReference<T>(ScopeTranscriber.Construct(scope, name));
        }

        //- @Set -//
        /// <summary>
        ///     Sets and object by name (scoping is highly recommended)
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">Name of item.</param>
        /// <param name="value">value of the item.</param>
        public void Set<T>(string name, T value)
        {
            Data[name] = value;
        }

        /// <summary>
        ///     Sets and object by name (scoping is highly recommended)
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">Name of scope.</param>
        /// <param name="name">Name of item.</param>
        /// <param name="value">value of the item.</param>
        public void Set<T>(string scope, string name, T value)
        {
            Set(ScopeTranscriber.Construct(scope, name), value);
        }
    }
}