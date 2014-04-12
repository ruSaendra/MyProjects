using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calc
{
    struct GlobalVars
    {
        public static double glob_1st = 0, glob_2nd;        // Переменные для членов выражений.
        public static int glob_action=0;                    // Переменная для выбора действия.
        public static bool enter_round = false;             // Переменная для повторения предыдущего действия при нажати кнопки Enter.
    }
}
