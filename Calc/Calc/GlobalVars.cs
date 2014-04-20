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
        public static bool action_chosen = true;            // Выполнено или нет предыдущее действие.
        public const string glob_exp = "2.718282",          // Шоб логарифны стественны делать.
                             glob_pi = "3.141592";          // Шоб круг поперёк считать.
    }
}
