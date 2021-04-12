using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Time
{
    public class Time_Library
    {
        public static int CountDown(int curTime)
		{
            return curTime--;
		}
        public static int CountUp(int curTime)
        {
            return curTime++;
        }
    }
}

