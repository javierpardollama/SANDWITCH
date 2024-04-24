using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Helpers.Classes
{
    /// <summary>
    /// Represents a <see cref="AsyncHelper"/> class.
    /// </summary>
    public static class AsyncHelper
    {

        /// <summary>
        /// Instance of <see cref="TaskFactory"/>
        /// </summary>
        private static readonly TaskFactory TaskFactory = new(CancellationToken.None,
                                                                          TaskCreationOptions.None,
                                                                          TaskContinuationOptions.None,
                                                                          TaskScheduler.Default);

        /// <summary>
        /// Runs Tasks Synchronously
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">Injected <see cref="Func{T, TResult}"/></param>
        /// <returns>Instance of <see cref="{TResult}"/></returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;

            return TaskFactory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap()
            .GetAwaiter()
            .GetResult();
        }

        /// <summary>
        /// Runs Tasks Synchronously
        /// </summary>
        /// <param name="func">Injected <see cref="Func{T, TResult}"/></param>
        public static void RunSync(Func<Task> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;

            TaskFactory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap()
            .GetAwaiter()
            .GetResult();
        }
    }
}
