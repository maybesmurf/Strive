﻿using System.Collections.Immutable;

namespace PaderConference.Infrastructure.Serialization
{
    public class
        ImmutableDictionarySerializer<TKey, TValue> : ImmutableDictionarySerializerBase<
            ImmutableDictionary<TKey, TValue>, TKey, TValue>
    {
        protected override ImmutableDictionary<TKey, TValue> CreateInstance()
        {
            return ImmutableDictionary<TKey, TValue>.Empty;
        }
    }
}