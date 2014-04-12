using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                default:
                    return (sb_act);
            }
        }

        public static string statusbar_description(int act, string sb_dscr)     // Описание операнда.          
        {
            switch (act)
            {
                case 0:
                    return ("Choose an action");
                case 1:
                    return ("Addition: add the second number to the first");
                case 2:
                    return ("Substraction: substract the second number from the first");
                case 3:
                    return ("Multiplication: multiply X by Y");
                case 4:
                    return ("Division: divide X by Y");
                default:
                    return (sb_dscr);
            }
        }


    }
}
