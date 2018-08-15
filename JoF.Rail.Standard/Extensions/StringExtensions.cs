namespace JoF.Rail.Standard.Extensions
{
    using System;

    public static class StringExtensions
    {
        /// <summary>
        /// The offset delay in scheduled and estimated times, minutes
        /// </summary>
        /// <param name="estimatedTime">Estimated time string HH:mm</param>
        /// <param name="scheduledTime">Scheduled time string HH:mm</param>
        /// <returns>string of delay in minutes</returns>
        public static string ToTimeDelay(this string estimatedTime, string scheduledTime)
        {
            if (estimatedTime == null
                || scheduledTime == null
                || !estimatedTime.Contains(":")
                || estimatedTime == scheduledTime)
            {
                return "-";
            }

            var now = DateTime.Now;

            var estIso = now.ToString($"yyyy-MM-ddT{estimatedTime}:00");
            var schedIso = now.ToString($"yyyy-MM-ddT{scheduledTime}:00");

            DateTime.TryParse(estIso, out var estTime);
            DateTime.TryParse(schedIso, out var schedTime);

            // assume next morning
            if (estTime.Hour < schedTime.Hour)
            {
                estTime = estTime.AddDays(1);
            }

            var delay = estTime - schedTime;

            return $"{(60 * delay.Hours) + delay.Minutes}";
        }

        public static string ToTimeDelay(this string estimatedTime, string actualTime, bool hasColon)
        {
            if (!hasColon)
            {
                var bEst = Int32.TryParse(estimatedTime, out var est);
                var bAct = Int32.TryParse(actualTime, out var ac);

                if (!bEst || !bAct)
                {
                    return "-";
                }

                estimatedTime = $"{estimatedTime.Substring(0, 2)}:{estimatedTime.Substring(2, 2)}";
                actualTime = $"{actualTime.Substring(0, 2)}:{actualTime.Substring(2, 2)}";
            }

            return actualTime.ToTimeDelay(estimatedTime);
        }
    }
}
