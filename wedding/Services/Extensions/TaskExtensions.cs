using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace wedding.Services.Extensions
{
    public static class TaskExtensions
    {
        [DebuggerStepThrough]
        public static ConfiguredTaskAwaitable<TResult> AnyContext<TResult>(this Task<TResult> task)
            => task.ConfigureAwait(false);

        [DebuggerStepThrough]
        public static ConfiguredTaskAwaitable AnyContext(this Task task)
            => task.ConfigureAwait(false);

        public static async Task<T> WrapAsync<T>(CancellationTokenSource cts,
            Func<CancellationToken, Task<T>> taskFactory)
        {
            try
            {
                return await taskFactory(cts.Token).AnyContext();
            }
            catch
            {
                if (!cts.IsCancellationRequested)
                    cts.Cancel();
                throw;
            }
        }
    }
}