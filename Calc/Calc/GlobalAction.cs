using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Windows;

namespace Calc
{
    class GlobalAction
    {
        public static void glob_action()                                                    // Тут выбирается то действие, которое сделается.
        {
            switch (GlobalVars.glob_action)
            {
                case 1:
                    GlobalVars.glob_1st = GlobalVars.glob_1st + GlobalVars.glob_2nd;        // Сложение.
                    break;
                case 2:
                    GlobalVars.glob_1st = GlobalVars.glob_1st - GlobalVars.glob_2nd;        // Вычитание.
                    break;
                case 3:
                    GlobalVars.glob_1st = GlobalVars.glob_1st * GlobalVars.glob_2nd;        // Умножение.
                    break;
                case 4:
                    if (GlobalVars.glob_2nd == 0)                                           // Деление.
                    {
                        MessageBox.Show("Деление на ноль недопустимо.","Ошибка");           // Очевидно.
                        break;
                    }
                    else
                    {
                        GlobalVars.glob_1st = GlobalVars.glob_1st / GlobalVars.glob_2nd;
                        break;
                    }
                case 5:                                                                     // Возведение в степени.
                    GlobalVars.glob_1st = Math.Pow(GlobalVars.glob_1st, GlobalVars.glob_2nd);
                    break;
                case 6:                                                                     // Извлечение корня.
                    GlobalVars.glob_1st = Math.Pow(GlobalVars.glob_1st, 1 / GlobalVars.glob_2nd);
                    break;
                case 7:                                                                     // Расчет логарифма.
                    GlobalVars.glob_1st = Math.Log(GlobalVars.glob_1st, GlobalVars.glob_2nd);
                    break;
                case 8:                                                                     // Синус.
                    GlobalVars.glob_1st = Math.Round(Math.Sin(con_DegreeRad()),15);
                    break;
                case 9:                                                                     // Косинус.
                    GlobalVars.glob_1st = Math.Round(Math.Cos(con_DegreeRad()),15);
                    break;
                case 10:                                                                    // Тангенс.
                    GlobalVars.glob_1st = Math.Round(Math.Sin(con_DegreeRad()), 15) / Math.Round(Math.Cos(con_DegreeRad()), 15);
                    break;
                case 11:                                                                    // Котангенс.
                    GlobalVars.glob_1st = Math.Round(Math.Cos(con_DegreeRad()), 15) / Math.Round(Math.Sin(con_DegreeRad()), 15);
                    break;
                case 12:                                                                    // Секанс.
                    GlobalVars.glob_1st = 1 / Math.Round(Math.Cos(con_DegreeRad()), 15);
                    break;
                case 13:                                                                    // Косеканс.
                    GlobalVars.glob_1st = 1 / Math.Round(Math.Sin(con_DegreeRad()), 15);
                    break;
                case 14:                                                                    // Арксинус.
                    GlobalVars.glob_1st = GlobalVars.rad_chosen ? Math.Asin(GlobalVars.glob_1st) : (Math.Asin(GlobalVars.glob_1st) / Math.Round(Math.PI,15) * 180);
                    break;
                case 15:                                                                    // Арккосинус.
                    GlobalVars.glob_1st = GlobalVars.rad_chosen ? Math.Acos(GlobalVars.glob_1st) : (Math.Acos(GlobalVars.glob_1st) / Math.Round(Math.PI, 15) * 180);
                    break;
                case 16:                                                                    // Арктангенс.
                    GlobalVars.glob_1st = GlobalVars.rad_chosen ? Math.Atan(GlobalVars.glob_1st) : (Math.Atan(GlobalVars.glob_1st) / Math.Round(Math.PI, 15) * 180);
                    break;
                case 17:                                                                    // Арккотангенс.
                    GlobalVars.glob_1st = GlobalVars.rad_chosen ? (Math.Atan(-GlobalVars.glob_1st) + Math.Round(Math.PI, 15) / 2) : (Math.Atan(-GlobalVars.glob_1st + Math.Round(Math.PI,15) / 2)/Math.Round(Math.PI,15)*180);
                    break;
                case 18:                                                                    // Арксеканс.
                    GlobalVars.glob_1st = GlobalVars.rad_chosen ? Math.Acos(1 / GlobalVars.glob_1st) : (Math.Acos(1 / (GlobalVars.glob_1st)) / Math.Round(Math.PI,15) * 180);
                    break;
                case 19:                                                                    // Арккосеканс.
                    GlobalVars.glob_1st = GlobalVars.rad_chosen ? Math.Asin(1 / GlobalVars.glob_1st) : (Math.Asin(1 / (GlobalVars.glob_1st)) / Math.Round(Math.PI,15) * 180);
                    break;
                case 20:                                                                    // Деление нацело
                    GlobalVars.glob_1st = GlobalVars.glob_1st % GlobalVars.glob_2nd;
                    break;
                case 21:                                                                    // Вычисление процентного соотношения Х и У.
                    GlobalVars.glob_1st = GlobalVars.glob_2nd / GlobalVars.glob_1st * 100;
                    break;
                case 22:                                                                    // Возведение Е в степень Х.
                    GlobalVars.glob_1st = Math.Pow(Math.E, GlobalVars.glob_1st);
                    break;
                default:
                    break;
            }
            Logging.logging(6);
            Logging.logging(2);
        }

        public static string glob_numberenter(int local_action, string txtBox)              // Через это делаются действия.
        {
                if (GlobalVars.action_chosen)                                               // Повторить предыдущее действие с тем же вторым членом.
                    if (local_action == -1)
                        GlobalAction.glob_action();
                    else
                    {
                        GlobalVars.glob_action = local_action;                              // Выбрать другое действие.
                        Logging.logging(5);
                    }
                else
                    if (GlobalVars.glob_action == 0)                                        // Утверждение первого члена выражения и выбор операции.
                    {
                        try
                        {
                            switch (txtBox)
                            {
                                case "e":
                                    GlobalVars.glob_1st = Math.Round(Math.E, 15);
                                    break;
                                case "pi":
                                    GlobalVars.glob_1st = Math.Round(Math.PI, 15);
                                    break;
                                default:
                                    GlobalVars.glob_1st = double.Parse(txtBox, CultureInfo.InvariantCulture);
                                    break;
                            }
                            Logging.logging(2);
                            GlobalVars.glob_action = local_action;
                            Logging.logging(4);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error: inappropriate content.");
                        }
                    }
                    else
                    {                                                                       // Утверждение второго члена выражения и выбор следующей операции.
                        try
                        {
                            switch (txtBox)
                            {
                                case "e":
                                    GlobalVars.glob_2nd= Math.Round(Math.E, 15);
                                    break;
                                case "pi":
                                    GlobalVars.glob_2nd = Math.Round(Math.PI, 15);
                                    break;
                                default:
                                    GlobalVars.glob_2nd = double.Parse(txtBox, CultureInfo.InvariantCulture);
                                    break;
                            }
                            Logging.logging(3);
                            GlobalAction.glob_action();
                            if (local_action != -1)
                            {
                                GlobalVars.glob_action = local_action;
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error: inappropriate content.");
                        }
                    }
            return (GlobalVars.glob_1st.ToString(CultureInfo.InvariantCulture));
        }

        private static double con_DegreeRad()
        {
            if (GlobalVars.rad_chosen)
                return GlobalVars.glob_1st;
            else
                return (Math.PI*GlobalVars.glob_1st / 180);
        }

    }
}
