#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

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

        private StringObjectMap Data { get; set; }

        //+
        //- @Get -//
        /// <summary>
        /// Obtains a value (for reference types, GetReference is more efficient).
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T Get<T>(String name)
        {
            if (Data[name] is T)
            {
                return (T)Data[name];
            }
            //+
            return default(T);
        }

        /// <summary>
        /// Obtains a value.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">Name of scope.</param>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T Get<T>(String scope, String name) where T : struct
        {
            return Get<T>(ScopeTranscriber.Construct(scope, name));
        }

        //(must be unique; scopes are recommended)
        //- @GetReference -//
        /// <summary>
        /// Obtains an object reference.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T GetReference<T>(String name) where T : class
        {
            return Data[name] as T;
        }

        //- @GetReference -//
        /// <summary>
        /// Obtains an object reference.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">Name of scope.</param>
        /// <param name="name">Name of item </param>
        /// <returns>Value of item</returns>
        public T GetReference<T>(String scope, String name) where T : class
        {
            return GetReference<T>(ScopeTranscriber.Construct(scope, name));
        }

        //- @Set -//
        /// <summary>
        /// Sets and object by name (scoping is highly recommended)
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">Name of item.</param>
        /// <param name="value">value of the item.</param>
        public void Set<T>(String name, T value)
        {
            Data[name] = value;
        }

        /// <summary>
        /// Sets and object by name (scoping is highly recommended)
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">Name of scope.</param>
        /// <param name="name">Name of item.</param>
        /// <param name="value">value of the item.</param>
        public void Set<T>(String scope, String name, T value)
        {
            Set(ScopeTranscriber.Construct(scope, name), value);
        }
    }
}