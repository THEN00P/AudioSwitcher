using System;
using System.Threading;
using System.Threading.Tasks;

namespace AudioSwitcher.AudioApi.CoreAudio
{
    internal static class TaskShim
    {

        public static Task<T> FromResult<T>(T result)
        {
#if NET40
            return TaskEx.FromResult(result);
#else
            return Task.FromResult(result);
#endif
        }

        public static Task Run(Action action)
        {
#if NET40
            return TaskEx.Run(action);
#else
            return Task.Run(action);
#endif
        }

        public static Task Run(Action action, CancellationToken cancellationToken)
        {
#if NET40
            return TaskEx.Run(action, cancellationToken);
#else
            return Task.Run(action, cancellationToken);
#endif
        }

        public static Task<T> Run<T>(Func<T> function)
        {
#if NET40
            return TaskEx.Run(function);
#else
            return Task.Run(function);
#endif
        }

        public static Task<T> Run<T>(Func<T> function, CancellationToken cancellationToken)
        {
#if NET40
            return TaskEx.Run(function, cancellationToken);
#else
            return Task.Run(function, cancellationToken);
#endif
        }

        public static Task<T> Run<T>(Func<Task<T>> function)
        {
#if NET40
            return TaskEx.Run(function);
#else
            return Task.Run(function);
#endif
        }

        public static Task<T> Run<T>(Func<Task<T>> function, CancellationToken cancellationToken)
        {
#if NET40
            return TaskEx.Run(function, cancellationToken);
#else
            return Task.Run(function, cancellationToken);
#endif
        }

        public static Task Run(Func<Task> function)
        {
#if NET40
            return TaskEx.Run(function);
#else
            return Task.Run(function);
#endif
        }

        public static Task Run(Func<Task> function, CancellationToken cancellationToken)
        {
#if NET40
            return TaskEx.Run(function, cancellationToken);
#else
            return Task.Run(function, cancellationToken);
#endif
        }

    }
}
