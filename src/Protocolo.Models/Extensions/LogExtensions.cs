using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Runtime.CompilerServices;

namespace Protocolo.Models.Extensions
{
    public static class LogExtensions
    {
        /// <summary>
        /// Registra os eventos de interesse e relavância.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public static void AddLogInformation<T>(this ILogger<T> logger, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (var prop = LogContext.PushProperty("MemberName", memberName))
            {
                LogContext.PushProperty("FilePath", sourceFilePath);
                LogContext.PushProperty("LineNumber", sourceLineNumber);
                logger.LogInformation(message);
            }
        }

        /// <summary>
        /// Registra ionformações de possivies problemas e comportamentos inesperados.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public static void AddLogWarning<T>(this ILogger<T> logger, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (var prop = LogContext.PushProperty("MemberName", memberName))
            {
                LogContext.PushProperty("FilePath", sourceFilePath);
                LogContext.PushProperty("LineNumber", sourceLineNumber);
                logger.LogWarning(message);
            }
        }

        /// <summary>
        /// Registra informações de falhas de qualquer tipo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public static void AddLogError<T>(this ILogger<T> logger, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (var prop = LogContext.PushProperty("MemberName", memberName))
            {
                LogContext.PushProperty("FilePath", sourceFilePath);
                LogContext.PushProperty("LineNumber", sourceLineNumber);
                logger.LogError(message);
            }
        }

        /// <summary>
        /// Registra erros críticos que comprometam a aplicação de forma completa.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public static void AddLogCritical<T>(this ILogger<T> logger, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (var prop = LogContext.PushProperty("MemberName", memberName))
            {
                LogContext.PushProperty("FilePath", sourceFilePath);
                LogContext.PushProperty("LineNumber", sourceLineNumber);
                logger.LogCritical(message);
            }
        }
    }
}
