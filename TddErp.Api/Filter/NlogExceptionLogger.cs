using System.Web.Http.ExceptionHandling;

namespace TddErp.Api.Filter
{
    public class NlogExceptionLogger : ExceptionLogger
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public override void Log(ExceptionLoggerContext context)
        {
            logger.Fatal(context.Exception);
        }
    }
}