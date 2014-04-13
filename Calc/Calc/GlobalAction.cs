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
                case 5:
                    GlobalVars.glob_1st = Math.Pow(GlobalVars.glob_1st, GlobalVars.glob_2nd);
                    break;
                case 6:
                    GlobalVars.glob_1st = Math.Pow(GlobalVars.glob_1st, 1 / GlobalVars.glob_2nd);
                    break;
                default:
                    break;
            }
        }

        public static string glob_numberenter(int local_action, string txtBox)              // Через это делаются действия.
        {
                if (txtBox == "")                                                           // Повторить предыдущее действие с тем же вторым членом.
                    if(local_action==-1)
                        GlobalAction.glob_action();
                    else
                        GlobalVars.glob_action = local_action;                              // Выбрать другое действие.
                else
                    if (GlobalVars.glob_action == 0)                                        // Утверждение первого члена выражения и выбор операции.
                    {
                        try
                        {
                            GlobalVars.glob_1st = double.Parse(txtBox,CultureInfo.InvariantCulture);
                            GlobalVars.glob_action = local_action;
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
                            GlobalVars.glob_2nd = double.Parse(txtBox,CultureInfo.InvariantCulture);
                            if (local_action != -1)
                            {
                                GlobalVars.glob_action = local_action;
                                GlobalVars.enter_round = false;
                            }
                            GlobalAction.glob_action();
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error: inappropriate content.");
                        }
                    }
            return ("" + GlobalVars.glob_1st);
        }

    }
}
