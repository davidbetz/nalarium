#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium
{
    public delegate void Executor<T>(T t);
    public delegate void Executor<T, T2>(T t, T2 t2);
    public delegate void Executor<T, T2, T3>(T t, T2 t2, T3 t3);
    public delegate void Executor<T, T2, T3, T4>(T t, T2 t2, T3 t3, T4 t4);
    public delegate void Executor<T, T2, T3, T4, T5>(T t, T2 t2, T3 t3, T4 t4, T5 t5);
}