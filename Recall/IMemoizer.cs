﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recall
{
    public interface IMemoizer<TResult>
    {
        int MaxItems { get; }

        TimeSpan MaxAge { get; }

        Func<IEnumerable<KeyValuePair<string, CacheEntry<TResult>>>,
            IOrderedEnumerable<KeyValuePair<string, CacheEntry<TResult>>>> EvictionOrderer { get; }

        MemoizedFunc<TResult> Memoize(Func<IEnumerable<TResult>> func);

        MemoizedFunc<TArg, TResult> Memoize<TArg>(Func<TArg, IEnumerable<TResult>> func);

        MemoizedAsyncFunc<TResult> Memoize(Action<Action<IEnumerable<TResult>>> action);

        MemoizedAsyncFunc<TArg, TResult> Memoize<TArg>(Action<TArg, Action<IEnumerable<TResult>>> action);

        MemoizedTaskAsyncFunc<TResult> MemoizeTask(Func<Task<IEnumerable<TResult>>> func);

        MemoizedTaskAsyncFunc<TArg, TResult> MemoizeTask<TArg>(Func<TArg, Task<IEnumerable<TResult>>> func);
    }
}