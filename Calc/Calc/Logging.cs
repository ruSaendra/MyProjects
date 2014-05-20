using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace Calc
{
    class Logging
    {
        public static void logging(int logActIndex)
        {
            switch (logActIndex)
            {
                case 0:
                    GlobalVars.logString = "Приложение было открыто.";
                    break;
                case 1:
                    GlobalVars.logString = "Приложение было закрыто."+Environment.NewLine;
                    break;
                case 2:                                                                             // Ввод первого числа.
                    GlobalVars.logData[0] = GlobalVars.glob_1st.ToString();
                    GlobalVars.logString = "Введён первый член выражения: "+GlobalVars.logData[0]+".";
                    break;
                case 3:                                                                             // Ввод второго числа.
                    GlobalVars.logData[1] = GlobalVars.glob_2nd.ToString();
                    GlobalVars.logString = "Введён второй член выражения: " + GlobalVars.logData[1] + ".";
                    break;
                case 4:                                                                             // Выбор действия.
                    GlobalVars.logString = logCalcAction("Выбрано действие: ");
                    break;
                case 5:                                                                             // Изменение выбранного действия.
                    GlobalVars.logString = logCalcAction("Выбранное действие изменено на ");
                    break;
                case 6:                                                                             // Вычисление выражения.
                    GlobalVars.logString = logStringAssemble();
                    break;
                case 7:                                                                             // Очистка поля ввода.
                    GlobalVars.logString = "Поле ввода числа очищено.";
                    break;
                case 8:                                                                             // Сброс всех полей.
                    GlobalVars.logString = "Сброшены значения всех членов выражения и выбранное действие.";
                    break;
                case 9:                                                                             // Заполнение ячейки памяти.
                    GlobalVars.logString = "В ячейку памяти №" + (GlobalVars.mem_cell_index + 1) + " введено число " + GlobalVars.mem_cells[GlobalVars.mem_cell_index] + ".";
                    break;
                case 10:                                                                            // Вставка в ячейку памяти из буфера обмена.
                    GlobalVars.logString = "В ячейку памяти №" + (GlobalVars.mem_cell_index + 1) + " вставлено из буфера обмена число " + GlobalVars.mem_cells[GlobalVars.mem_cell_index] + ".";
                    break;
                case 11:                                                                            // Использование числа в ячейке памяти.
                    GlobalVars.logString = "Число " + GlobalVars.mem_cells[GlobalVars.mem_cell_index] + " из ячейки памяти №" + (GlobalVars.mem_cell_index + 1) + " вставлено в поле для ввода числа.";
                    break;
                case 12:                                                                            // Очистка ячейки памяти.
                    GlobalVars.logString = "Ячейка памяти №" + (GlobalVars.mem_cell_index + 1) + " очищена.";
                    break;
                case 13:                                                                            // Очистка всех ячеек памяти.
                    GlobalVars.logString = "Все ячейки памяти очищены.";
                    break;
                case 14:                                                                            // Вставка из буфера обмена.
                    StringBuilder sb = new StringBuilder(Clipboard.GetText());
                    for (int i = 0, j = sb.Length; i < j; i++)
                    {
                        if (sb[0] == '-' && sb[1] == '0' && (sb[2] != '.' && sb[2] != ','))
                        {
                        sb.Remove(1, 1);
                        }
                        else
                            if (sb[0] == '0' && (sb[1] != '.' && sb[1] != ','))
                            {
                                sb.Remove(0, 1);
                            }
                    }
                    sb.Replace(',', '.');
                    GlobalVars.logString = "Из буфера обмена вставлено число " + sb.ToString() + ".";
                    break;
                case 15:
                    GlobalVars.logString = "Ошибка: попытка деления на ноль!";
                    break;
                case 16:
                    GlobalVars.logString = "Ошибка: попытка вставить из буфера обмена некорректные данные!";
                    break;
                case 17:
                    GlobalVars.logString = "Ошибка: попытка вставки слишком большого значения из буфера обмена!";
                    break;
                case 18:
                    GlobalVars.logString = "Ошибка: переполнение стека при вставке значения из буфера обмена!";
                    break;
                case 19:
                    GlobalVars.logString = "Ошибка: попытка извлечь значение из пустой ячейки памяти!";
                    break;
                default:
                    return;
            }
            Logging.writeLog();
        }

        private static void writeLog()                                                      // Запись лога в файл.
        {
            if(!Directory.Exists(@"Log"))                                                   // Создание директории, если ещё не создана.
            {
                Directory.CreateDirectory(@"Log");
            }
            using (StreamWriter logAct = new StreamWriter("Log\\log.txt", true))
            {
                logAct.Write("[{0:dd.MM.yyyy HH:mm:ss}] ",DateTime.Now);                    // Таймстамп.
                logAct.WriteLine(GlobalVars.logString);                                     // Выполненное действие.
            }
            return;
        }

        private static string logCalcAction(string tempStr)
        {
            switch (GlobalVars.glob_action)
            {
                case 1:
                    return (tempStr+"сложение.");
                case 2:
                    return (tempStr + "вычитание.");
                case 3:
                    return (tempStr + "умножение.");
                case 4:
                    return (tempStr + "деление.");
                case 5:
                    if (GlobalVars.glob_2nd == 2)
                        return (tempStr + "возведение в квадрат.");
                    if (GlobalVars.glob_2nd == 3)
                        return (tempStr + "возведение в куб.");
                    return (tempStr + "возведение в заданную степень.");
                case 6:
                    if (GlobalVars.glob_2nd == 2)
                        return (tempStr + "извлечение квадратного корня.");
                    if (GlobalVars.glob_2nd == 3)
                        return (tempStr + "извлечение кубического корня.");
                    return (tempStr + "извлечение корня заданной степени.");
                case 7:
                    if (GlobalVars.glob_2nd == 10)
                        return (tempStr + "вычисление десятичного логарифма.");
                    if (GlobalVars.glob_2nd == Math.Round(Math.E, 15))
                        return (tempStr + "вычисление  естественного логарифма.");
                    return (tempStr + "вычисление логарифма по заданному основанию.");
                case 8:
                    return (tempStr + "вычисление синуса.");
                case 9:
                    return (tempStr + "вычисление косинуса.");
                case 10:
                    return (tempStr + "вычисление тангенса.");
                case 11:
                    return (tempStr + "вычисление котангенса.");
                case 12:
                    return (tempStr + "вычисление секанса.");
                case 13:
                    return (tempStr + "вычисление косеканса.");
                case 14:
                    return (tempStr + "вычисление арксинуса.");
                case 15:
                    return (tempStr + "вычисление арккосинуса.");
                case 16:
                    return (tempStr + "вычисление арктангенса.");
                case 17:
                    return (tempStr + "вычисление арккотангенса.");
                case 18:
                    return (tempStr + "вычисление арксеканса.");
                case 19:
                    return (tempStr + "вычисление арккосеканса.");
                case 20:
                    return (tempStr + "вычисление остатка от деления нацело.");
                case 21:
                    return (tempStr + "вычисление процентного соотношения чисел.");
                case 22:
                    return (tempStr + "возведение е в заданную степень.");
                default:
                    return ("Выбрано неверное действие");
            }
        }

        private static string logStringAssemble()
        {
            GlobalVars.logData[2] = GlobalVars.glob_1st.ToString();
            switch (GlobalVars.glob_action)
            {
                case 1:
                    return (GlobalVars.logData[0] + " + " + GlobalVars.logData[1] + " = " + GlobalVars.logData[2]);
                case 2:
                    return (GlobalVars.logData[0] + " - " + GlobalVars.logData[1] + " = " + GlobalVars.logData[2]);
                case 3:
                    return (GlobalVars.logData[0] + " * " + GlobalVars.logData[1] + " = " + GlobalVars.logData[2]);
                case 4:
                    return (GlobalVars.logData[0] + " / " + GlobalVars.logData[1] + " = " + GlobalVars.logData[2]);
                case 5:
                    if (GlobalVars.glob_2nd == 2)
                        return (GlobalVars.logData[0] + " ^ 2 = " + GlobalVars.logData[2]);
                    if (GlobalVars.glob_2nd == 3)
                        return (GlobalVars.logData[0] + " ^ 3 = " + GlobalVars.logData[2]);
                    return (GlobalVars.logData[0] + " ^ " + GlobalVars.logData[1] + " = " + GlobalVars.logData[2]);
                case 6:
                    if (GlobalVars.glob_2nd == 2)
                        return ("sqrt(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                    if (GlobalVars.glob_2nd == 3)
                        return ("cbrt(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                    return ("root(" + GlobalVars.logData[0] + ", " + GlobalVars.logData[1] + ") = " + GlobalVars.logData[2]);
                case 7:
                    if (GlobalVars.glob_2nd == 10)
                        return ("lg(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                    if (GlobalVars.glob_2nd == Math.Round(Math.E, 15))
                        return ("ln(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                    return ("log(" + GlobalVars.logData[0] + ", " + GlobalVars.logData[1] + ") = " + GlobalVars.logData[2]);
                case 8:
                    return ("sin(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 9:
                    return ("cos(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 10:
                    return ("tg(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 11:
                    return ("ctg(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 12:
                    return ("sec(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 13:
                    return ("cosec(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 14:
                    return ("arcsin(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 15:
                    return ("arccos(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 16:
                    return ("arctg(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 17:
                    return ("arcctg(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 18:
                    return ("arcsec(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 19:
                    return ("arccosec(" + GlobalVars.logData[0] + ") = " + GlobalVars.logData[2]);
                case 20:
                    return (GlobalVars.logData[0] + " mod " + GlobalVars.logData[1] + " = " + GlobalVars.logData[2]);
                case 21:
                    return (GlobalVars.logData[1] + " составляет " + GlobalVars.logData[2] + "% от " + GlobalVars.logData[2]);
                case 22:
                    return ("e ^ " + GlobalVars.logData[0] + " = " + GlobalVars.logData[2]);
                default:
                    return ("Выбрано неверное действие");
            }
        }

    }
}
