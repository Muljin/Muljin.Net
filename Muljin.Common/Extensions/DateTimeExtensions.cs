﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Extensions
{
    public static class DateTimeExtensions
    {
        private static DateTime _epoch = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);

        public static int ToEpoch(this DateTime time)
        {
            return (int)Math.Floor((time - _epoch).TotalSeconds);
        }

        public static DateTime EpochToDateTime(int epoch)
        {
            return _epoch.AddSeconds(epoch);
        }

        public static long ToEpochMs(this DateTime datetime)
        {
            return ((long)datetime.ToEpoch()) * 1000;
        }
    }

    
}
