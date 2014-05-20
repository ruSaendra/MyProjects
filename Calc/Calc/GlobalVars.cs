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
        public static double[] mem_cells = new double[5];   // Массив ячеек памяти.     
        public static int glob_action=0;                    // Переменная для выбора действия.
        public static bool action_chosen = true,            // Выбрано ли текущее действие.
                           action_done = false,             // Выполнено ли последнее действие.
                           last_act_unar = false,           // Унарность последней операции.
                           rad_chosen = true;               // Расчет тригонометрических функций в радианах (false - градусы).
        public static bool[] mem_cells_used = { false, false, false, false, false };
        public static int mem_cell_index = 0;               // Индекс ячейки для запоминания чисел.
        public static string logString;                     // Строка для вывода лога.
        public static string[] logData = new string[3];     // Массив с данными для лога: 0 - первый член выражения, 1 - второй член выражения, 2 - результат.
    }
}
