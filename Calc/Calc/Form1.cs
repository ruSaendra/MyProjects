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
            ///Возведение в степени - done.
            ///Извлечение корней
            ///Логарифмы
            ///Тригонометрические функции
            ///Вопрос при закрытии
            ///Дизайн
            ///config-файл
            ///Запись лога
            /// ^в паралллельном потоке
            ///Новые иконки
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)                                             // Хоткеи, хоткеи эвриуэар.
            {
                                                                        // Блок хоткеев для ввода цифр и десятичной точки.
                case Keys.D1:
                    numbttn_click_func('1');
                    return true;                    
                case Keys.D2:                       
                    numbttn_click_func('2');        
                    return true;                    
                case Keys.D3:
                    numbttn_click_func('3');
                    return true;
                case Keys.D4:
                    numbttn_click_func('4');
                    return true;
                case Keys.D5:
                    numbttn_click_func('5');
                    return true;
                case Keys.D6:
                    numbttn_click_func('6');
                    return true;
                case Keys.D7:
                    numbttn_click_func('7');
                    return true;
                case Keys.D8:
                    numbttn_click_func('8');
                    return true;
                case Keys.D9:
                    numbttn_click_func('9');
                    return true;
                case Keys.D0:
                    numbttn_click_func('0');
                    return true;
                case Keys.OemPeriod:
                    numbttn_click_func('.');
                    return true;
                case Keys.NumPad1:
                    numbttn_click_func('1');
                    return true;
                case Keys.NumPad2:
                    numbttn_click_func('2');
                    return true;
                case Keys.NumPad3:
                    numbttn_click_func('3');
                    return true;
                case Keys.NumPad4:
                    numbttn_click_func('4');
                    return true;
                case Keys.NumPad5:
                    numbttn_click_func('5');
                    return true;
                case Keys.NumPad6:
                    numbttn_click_func('6');
                    return true;
                case Keys.NumPad7:
                    numbttn_click_func('7');
                    return true;
                case Keys.NumPad8:
                    numbttn_click_func('8');
                    return true;
                case Keys.NumPad9:
                    numbttn_click_func('9');
                    return true;
                case Keys.NumPad0:
                    numbttn_click_func('0');
                    return true;
                case Keys.Decimal:
                    numbttn_click_func('.');
                    return true;
                                                                        // Конец блока хоткеев для ввода цифр и десятичной точки.
                case Keys.Add:                                          // Сложение: нампад.
                    actbttn_click_func(1);
                    return true;
                case Keys.Oemplus:                                      // Сложение: основная клавиатура.
                    actbttn_click_func(1);
                    return true;
                case Keys.Subtract:                                     // Вычитание: нампад.
                    actbttn_click_func(2);
                    return true;
                case Keys.OemMinus:                                     // Вычитание: основная клавиатура.
                    actbttn_click_func(2);
                    return true;
                case Keys.Multiply:                                     // Умножение: нампад.
                    actbttn_click_func(3);
                    return true;
                case Keys.Shift|Keys.D8:                                // Умножение: основная клавиатура.
                    actbttn_click_func(3);
                    return true;
                case Keys.Divide:                                       // Деление: нампад.
                    actbttn_click_func(4);
                    return true;
                case Keys.OemQuestion:                                  // Деление: основная клавиатура.
                    actbttn_click_func(4);
                    return true;
                case Keys.Enter:                                        // Кнопка Энтер - повторение предыдущего действия или выполнение выбранного.
                    enterbttn_click_func();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);    
            }

        }

        private void numbttn_click_func(char btn_pressed)               // Нажатие цифровых клавиш или точки.
        {
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
            txtBox.Text = "";
            toolbarAction.Text = statusbar_text.statusbar_action(GlobalVars.glob_action, toolbarAction.Text);
            toolbarDescription.Text = statusbar_text.statusbar_description(GlobalVars.glob_action, toolbarDescription.Text);
        }

        private void enterbttn_click_func()
        {
            if (txtBox.Text == "" && !GlobalVars.enter_round)
                resultBox.Text = GlobalAction.glob_numberenter(-1, "" + GlobalVars.glob_1st);
            else
                if (txtBox.Text == "")
                    resultBox.Text = GlobalAction.glob_numberenter(-1, "" + GlobalVars.glob_2nd);
                else
                    resultBox.Text = GlobalAction.glob_numberenter(-1, txtBox.Text);
            GlobalVars.enter_round = true;
            txtBox.Text = "";
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
            txtBox.Text = "";
        }

        private void btnClrRslt_Click(object sender, EventArgs e)       // Очистить поле результата.
        {
            resultBox.Text = "";
            GlobalVars.glob_1st = 0;
            GlobalVars.glob_action = 0;
            toolbarAction.Text = statusbar_text.statusbar_action(GlobalVars.glob_action, toolbarAction.Text);
            toolbarDescription.Text = statusbar_text.statusbar_description(GlobalVars.glob_action, toolbarDescription.Text);
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

        private void btnPow2_Click(object sender, EventArgs e)
        {
            GlobalVars.glob_action = 5;
            if(resultBox.Text=="")
                GlobalVars.glob_1st = double.Parse(txtBox.Text);
            txtBox.Text = "2";
            actbttn_click_func(5);
        }

        private void btnPow3_Click(object sender, EventArgs e)
        {
            GlobalVars.glob_action = 5;
            if (resultBox.Text == "")
                GlobalVars.glob_1st = double.Parse(txtBox.Text);
            txtBox.Text = "3";
            actbttn_click_func(5);
        }

        private void btnPowY_Click(object sender, EventArgs e)
        {
            actbttn_click_func(5);
        }

    }
}
