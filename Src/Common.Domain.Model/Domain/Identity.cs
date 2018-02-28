using System;

namespace Common.Domain.Model.Domain
{
    public interface Identity<out TKey> where TKey : IComparable
    {
        TKey Key { get; }
    }
}