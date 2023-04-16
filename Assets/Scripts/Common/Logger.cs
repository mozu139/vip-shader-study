using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace VipShaderStudy.Common
{
    public class Logger
    {

        public static void Log<T>(IEnumerable<T> v, string head = "")
        {
            Debug.Log($"<color=red>{head}</color>");
            foreach(var e in v)
            {
                Debug.Log(e);
            }
        }
    }
}
