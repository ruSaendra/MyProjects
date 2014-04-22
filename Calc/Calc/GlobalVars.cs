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
        public static bool action_chosen = true,            // Выбрано ли текущее действие.
                           action_done = false,              // Выполнено ли последнее действие.
                           rad_chosen = true;               // Расчет тригонометрических функций в радианах (false - градусы).
    }
}
