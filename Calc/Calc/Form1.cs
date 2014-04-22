using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Windows;

namespace Calc
{
    public partial class CalcForm : Form
    {
        public CalcForm()
        {
            InitializeComponent();
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {

            ///TODO:
            ///Memory
            ///Дизайн
            ///config-файл
            ///Запись лога
            /// ^в паралллельном потоке
            ///Новые иконки
            ///Округление и естественная форма
            
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult dbxresult = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Выход из приложения", MessageBoxButtons.YesNo);
            switch (dbxresult)
            {
                case DialogResult.Yes:
                    e.Cancel = false;
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)                                             // Хоткеи, хоткеи эвриуэар.
            {
                                                                        // Блок хоткеев для ввода цифр и десятичной точки.
                case Keys.D1:
                case Keys.NumPad1:
                    numbttn_click_func('1');
                    return true;                    
                case Keys.D2:
                case Keys.NumPad2:   
                    numbttn_click_func('2');        
                    return true;                    
                case Keys.D3:
                case Keys.NumPad3:
                    numbttn_click_func('3');
                    return true;
                case Keys.D4:
                case Keys.NumPad4:
                    numbttn_click_func('4');
                    return true;
                case Keys.D5:
                case Keys.NumPad5:
                    numbttn_click_func('5');
                    return true;
                case Keys.D6:
                case Keys.NumPad6:
                    numbttn_click_func('6');
                    return true;
                case Keys.D7:
                case Keys.NumPad7:
                    numbttn_click_func('7');
                    return true;
                case Keys.D8:
                case Keys.NumPad8:
                    numbttn_click_func('8');
                    return true;
                case Keys.D9:
                case Keys.NumPad9:
                    numbttn_click_func('9');
                    return true;
                case Keys.D0:
                case Keys.NumPad0:
                    numbttn_click_func('0');
                    return true;
                case Keys.OemPeriod:
                case Keys.Decimal:
                    numbttn_click_func('.');
                    return true;
                                                                        // Конец блока хоткеев для ввода цифр и десятичной точки.
                case Keys.Add:                                          // Сложение: нампад.
                case Keys.Oemplus:                                      // Сложение: основная клавиатура.
                    actbttn_click_func(1);
                    return true;
                case Keys.Subtract:                                     // Вычитание: нампад.
                case Keys.OemMinus:                                     // Вычитание: основная клавиатура.
                    actbttn_click_func(2);
                    return true;
                case Keys.Multiply:                                     // Умножение: нампад.
                case Keys.Shift|Keys.D8:                                // Умножение: основная клавиатура.
                    actbttn_click_func(3);
                    return true;
                case Keys.Divide:                                       // Деление: нампад.
                case Keys.OemQuestion:                                  // Деление: основная клавиатура.
                    actbttn_click_func(4);
                    return true;
                case Keys.Enter:                                        // Кнопка Энтер - повторение предыдущего действия или выполнение выбранного.
                    enterbttn_click_func();
                    return true;
                case Keys.Control|Keys.C:                               // Копирование значения поля resultBox в буфер обмена.
                case Keys.Control|Keys.Insert:                          // Копирование значения поля resultBox в буфер обмена - олдфажный вариант.
                    Clipboard.SetText(resultBox.Text);
                    return true;
                case Keys.Control|Keys.V:                               // Вставка из буфера обмена в поле txtBox.
                case Keys.Shift|Keys.Insert:                            // Вставка из буфера обмена в поле txtbox - олдфажный вариант.
                    try                                                 // Шоб буков не було.
                    {
                        double.Parse(Clipboard.GetText());
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("В буфере обмена некорректные данные!", "Ошибка!");
                        return true;
                    }
                    catch (StackOverflowException)
                    {
                        MessageBox.Show("Превышение допустимого размера члена выражения!", "Ошибка!");
                        return true;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Превышение допустимого размера члена выражения!", "Ошибка!");
                        return true;
                    }
                    txtBox.Text = Clipboard.GetText();
                    for (int i = 0, j = txtBox.Text.Length; i < j; i++)
                    {
                        if (txtBox.Text[0] == '-'&& txtBox.Text[1] == '0' && (txtBox.Text[2] != '.' && txtBox.Text[2] != ','))
                        {
                            StringBuilder sb = new StringBuilder(txtBox.Text);
                            sb.Remove(1, 1);
                            txtBox.Text = sb.ToString();
                        }
                        else
                            if (txtBox.Text[0] == '0' && (txtBox.Text[1] != '.' && txtBox.Text[1] != ','))
                            {
                                StringBuilder sb = new StringBuilder(txtBox.Text);
                                sb.Remove(0, 1);
                                txtBox.Text = sb.ToString();
                            }
                    }
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);    
            }

        }

        private void numbttn_click_func(char btn_pressed)               // Нажатие цифровых клавиш или точки.
        {
            if (GlobalVars.action_done)
                clear_fields();
            if (GlobalVars.action_chosen)
            {
                txtBox.Text = "";
                GlobalVars.action_chosen = false;
            }
            if(btn_pressed=='.')                                        // Разделитель целой и дробной части. Остатья должен только один.
            {
                bool dotpres;
                dotpres = txtBox.Text.Contains(".");
                if (txtBox.Text == "")
                    txtBox.Text = "0.";
                else
                    if (dotpres == false)
                        txtBox.Text = txtBox.Text + ".";
            }
            else
                if (txtBox.Text == "0")                                 // Ноля в начале быть не должно.
                    txtBox.Text = "" + btn_pressed;
                else
                    if (txtBox.Text == "-0")
                        txtBox.Text = "-" + btn_pressed;
                    else
                        txtBox.Text = txtBox.Text + btn_pressed;
        }

        private void actbttn_click_func(int btn_pressed)                // Выбор операнда.
        {
            resultBox.Text = GlobalAction.glob_numberenter(btn_pressed, txtBox.Text);
            toolbarAction.Text = statusbar_text.statusbar_action(GlobalVars.glob_action, toolbarAction.Text);
            toolbarDescription.Text = statusbar_text.statusbar_description(GlobalVars.glob_action, toolbarDescription.Text);
            txtBox.Text = "0";
            GlobalVars.action_chosen = true;
            GlobalVars.action_done = false;
        }

        private void enterbttn_click_func()                             // Действие при нажатии кнопки Enter.
        {
            resultBox.Text = GlobalAction.glob_numberenter(-1, txtBox.Text);
            GlobalVars.action_chosen = true;
            GlobalVars.action_done = true;
        }

        private void clear_fields()
        {
            resultBox.Text = "0";
            txtBox.Text = "0";
            GlobalVars.action_chosen = true;
            GlobalVars.glob_1st = 0;
            GlobalVars.glob_action = 0;
            toolbarAction.Text = statusbar_text.statusbar_action(GlobalVars.glob_action, toolbarAction.Text);
            toolbarDescription.Text = statusbar_text.statusbar_description(GlobalVars.glob_action, toolbarDescription.Text);
        }

        private void btn0_Click(object sender, EventArgs e)             // Кнопка 0.
        {
            numbttn_click_func('0');
        }

        private void btn1_Click(object sender, EventArgs e)             // Кнопка 1.
        {
            numbttn_click_func('1');
        }

        private void btn2_Click(object sender, EventArgs e)             // Кнопка 2.
        {
            numbttn_click_func('2');
        }

        private void btn3_Click(object sender, EventArgs e)             // Кнопка 3.
        {
            numbttn_click_func('3');
        }

        private void btn4_Click(object sender, EventArgs e)             // Кнопка 4.
        {
            numbttn_click_func('4');
        }

        private void btn5_Click(object sender, EventArgs e)             // Кнопка 5.
        {
            numbttn_click_func('5');
        }

        private void btn6_Click(object sender, EventArgs e)             // Кнопка 6.
        {
            numbttn_click_func('6');
        }

        private void btn7_Click(object sender, EventArgs e)             // Кнопка 7.
        {
            numbttn_click_func('7');
        }

        private void btn8_Click(object sender, EventArgs e)             // Кнопка 8.
        {
            numbttn_click_func('8');
        }

        private void btn9_Click(object sender, EventArgs e)             // Кнопка 9.
        {
            numbttn_click_func('9');
        }

        private void btnDot_Click(object sender, EventArgs e)           // DOTS! MOAR DOTS!
        {
            numbttn_click_func('.');
        }

        private void btnAddit_Click(object sender, EventArgs e)         // Сложение.
        {
            actbttn_click_func(1);
        }

        private void btnSubstr_Click(object sender, EventArgs e)        // Вычитание.
        {
            actbttn_click_func(2);
        }

        private void btnMultipl_Click(object sender, EventArgs e)       // Умножение.
        {
            actbttn_click_func(3);
        }

        private void btnDivis_Click(object sender, EventArgs e)         // Деление.
        {
            actbttn_click_func(4);
        }

        private void btnClrFld_Click(object sender, EventArgs e)        // Очистить поле введённого числа.
        {
            txtBox.Text = "0";
            GlobalVars.action_chosen = true;
        }

        private void btnClrRslt_Click(object sender, EventArgs e)       // Очистить поле результата.
        {
            clear_fields();
        }

        private void btnEnter_Click(object sender, EventArgs e)         // Выполнить действие или повторить предыдущее.
        {
            enterbttn_click_func();
        }

        private void btnNegate_Click(object sender, EventArgs e)        // Сделать введённое число отрицательным.
        {
            if (txtBox.Text.Contains('-'))
            {
                txtBox.Text=txtBox.Text.Substring(1);
                return;
            }
            txtBox.Text = "-" + txtBox.Text;
            if (txtBox.Text == "-")
                txtBox.Text = "-0";
        }

        private void btnPow2_Click(object sender, EventArgs e)          // Возведение в квадрат.
        {
            if(GlobalVars.glob_action!=0)
                enterbttn_click_func();
            GlobalVars.glob_action = 5;
            if(!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text);
            txtBox.Text = "2";
            actbttn_click_func(-1);
        }

        private void btnPow3_Click(object sender, EventArgs e)          // Возведение в куб.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 5;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text);
            txtBox.Text = "3";
            actbttn_click_func(-1);
        }

        private void btnPowY_Click(object sender, EventArgs e)          // Возведение в n-ную степень.
        {
            actbttn_click_func(5);
        }

        private void btnSqrt_Click(object sender, EventArgs e)          // Извлечение квадратного корня.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 6;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text);
            txtBox.Text = "2";
            actbttn_click_func(-1);
        }

        private void btnCbrt_Click(object sender, EventArgs e)          // Извлечение кубического корня.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 6;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text);
            txtBox.Text = "3";
            actbttn_click_func(-1);
        }

        private void btnYroot_Click(object sender, EventArgs e)         // Извлечение корня n-ной степени.
        {
            actbttn_click_func(6);
        }

        private void btnLog_Click(object sender, EventArgs e)           // Вычисление логарифма по основанию n.
        {
            actbttn_click_func(7);
        }

        private void btnLg_Click(object sender, EventArgs e)            // Вычисление десятичного логарифма.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 7;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "10";
            actbttn_click_func(-1);
        }

        private void btnLn_Click(object sender, EventArgs e)            // Вычисление естественного логарифма.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 7;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = Math.E.ToString(CultureInfo.InvariantCulture);
            actbttn_click_func(-1);
        }

        private void btnSinX_Click(object sender, EventArgs e)          // Синус.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 8;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text,CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnCosX_Click(object sender, EventArgs e)          // Косинус.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 9;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnTgX_Click(object sender, EventArgs e)           // Тангенс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 10;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnCtgX_Click(object sender, EventArgs e)          // Котангенс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 11;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnSecX_Click(object sender, EventArgs e)          // Секанс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 12;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnCosecX_Click(object sender, EventArgs e)        // Косеканс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 13;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnArcsinX_Click(object sender, EventArgs e)       // Арксинус.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 14;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnArccosX_Click(object sender, EventArgs e)       // Арккосинус.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 15;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnArctgX_Click(object sender, EventArgs e)        // Арктангенс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 16;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnArcctgX_Click(object sender, EventArgs e)       // Арккотангенс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 17;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnArcsecX_Click(object sender, EventArgs e)       // Арксеканс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 18;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnArccosecX_Click(object sender, EventArgs e)     // Арккосеканс.
        {
            if (GlobalVars.glob_action != 0)
                enterbttn_click_func();
            GlobalVars.glob_action = 19;
            if (!GlobalVars.action_chosen)
                GlobalVars.glob_1st = double.Parse(txtBox.Text, CultureInfo.InvariantCulture);
            txtBox.Text = "0";
            actbttn_click_func(-1);
        }

        private void btnFox_Click(object sender, EventArgs e)           // Кнопка Фокса.
        {
            DialogResult result = MessageBox.Show("Вы Фокс?", "Кнопка Фокса", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    for (int i = 0; i < 100; i++)
                        MessageBox.Show("Уберите Фокса от компьютера!", "Ошибка!");
                    this.Close();
                    return;
                case DialogResult.No:
                    MessageBox.Show("Эта кнопка не для вас.", "Ошибка!");
                    return;
                default:
                    return;
            }
        }

        private void rbtnRad_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.rad_chosen = true;
        }

        private void rbtnDeg_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.rad_chosen = false;
        }

        private void btnPI_Click(object sender, EventArgs e)
        {
            txtBox.Text = Math.Round(Math.PI,15).ToString(CultureInfo.InvariantCulture);
            GlobalVars.action_chosen = false;
        }

    }
}
