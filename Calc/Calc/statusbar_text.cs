using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calc
{
    class statusbar_text                                                        // Выбор текста для разделов статусбара.
    {
        public static string statusbar_action(int act,string sb_act)            // Индикатор операнда.
        {
            switch(act)
            {
                case 0:
                    return("N/A");
                case 1:
                    return("X+Y");
                case 2:
                    return("X-Y");
                case 3:
                    return("X*Y");
                case 4:
                    return("X/Y");
                case 5:
                    if (GlobalVars.glob_2nd == 2)
                        return ("X^2");
                    if (GlobalVars.glob_2nd == 3)
                        return ("X^3");
                    return ("X^Y");
                case 6:
                    if (GlobalVars.glob_2nd == 2)
                        return ("sqrtX");
                    if (GlobalVars.glob_2nd == 3)
                        return ("cbrtX");
                    return ("YrootX");
                case 7:
                    if (GlobalVars.glob_2nd == 10)
                        return ("LgX");
                    if (GlobalVars.glob_2nd == Math.E)
                        return ("LnX");
                    return ("LogX");
                default:
                    return (sb_act);
            }
        }

        public static string statusbar_description(int act, string sb_dscr)     // Описание операнда.          
        {
            switch (act)
            {
                case 0:
                    return ("Выберите действие");
                case 1:
                    return ("Сложение: прибавить к значению X значение Y");
                case 2:
                    return ("Вычитание: вычесть из значения Х значение Y");
                case 3:
                    return ("Умножение: умножить значение Х на значение Y");
                case 4:
                    return ("Деление: разделить значение Х на значение Y");
                case 5:
                    if (GlobalVars.glob_2nd == 2)
                        return ("Возведение в квадрат: умножить число Х само на себя");
                    if (GlobalVars.glob_2nd == 3)
                        return ("Возведение в куб: умножить число Х само на себя два раза");
                    return ("Возведение в степень: умножить число Х само на себя Y раз");
                case 6:
                    if (GlobalVars.glob_2nd == 2)
                        return ("Извлечение квадратного корня из Х");
                    if (GlobalVars.glob_2nd == 3)
                        return ("Извлечение кубического корня из Х");
                    return ("Извлечение корня степени Y из Х");
                case 7:
                    if (GlobalVars.glob_2nd == 10)
                        return ("Вычисление десятичного логарифма Х");
                    if (GlobalVars.glob_2nd == Math.E)
                        return ("Вычисление натурального логарифма Х");
                    return ("Вычисление логарифма Х по основанию Y");
                default:
                    return (sb_dscr);
            }
        }


    }
}
