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
                        return ("lgX");
                    if (GlobalVars.glob_2nd == Math.Round(Math.E,15))
                        return ("lnX");
                    return ("logX");
                case 8:
                    return ("sinX");
                case 9:
                    return ("cosX");
                case 10:
                    return ("tgX");
                case 11:
                    return ("ctgX");
                case 12:
                    return ("secX");
                case 13:
                    return ("cosecX");
                case 14:
                    return ("arcsinX");
                case 15:
                    return ("arccosX");
                case 16:
                    return ("arctgX");
                case 17:
                    return ("arcctgX");
                case 18:
                    return ("arcsecX");
                case 19:
                    return ("arccosecX");
                case 20:
                    return ("XmodY");
                case 21:
                    return ("%ofX");
                case 22:
                    return ("e^X");
                default:
                    return (sb_act);
            }
        }


    }
}
