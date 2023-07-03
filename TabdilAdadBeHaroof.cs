using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabdilAdadBeHarf_DotNet
{
    public class TabdilAdadBeHaroof
    {
        public static string GetHoroof(string adad)
        {
           
            int curentPele = 1;
            int counter = 0;
            string Res = "";
            string stak = "";
            List<string> resultStack = new List<string>();
            for (int j = adad.Length - 1; j >= 0; j--)
            {

                stak = stak + adad[j].ToString();
                counter++;
                if (counter % 3 == 0 || j == 0)
                {
                    counter = 0;
                    Res = "";
                    var arr = stak.ToArray();
                    Array.Reverse(arr);
                    stak = new String(arr);
                    if (stak != "000")
                        Res = GetLetter(stak) + " " + GetPeleDesc(curentPele);
                    if (!string.IsNullOrEmpty(Res) && !string.IsNullOrWhiteSpace(Res))
                        resultStack.Add(Res);
                    curentPele++;
                    stak = "";
                }
            }
            Res = "";
            for (int i = resultStack.Count - 1; i >= 0; i--)
            {
                Res = Res + resultStack[i] + (i == 0 ? "" : " و ");
            }
            return Res;
        }
        static string GetHarf(int adad)
        {
            switch (adad)
            {
                case 1:
                    return "یک";
                case 2:
                    return "دو";
                case 3:
                    return "سه";
                case 4:
                    return "چهار";
                case 5:
                    return "پنج";
                case 6:
                    return "شش";
                case 7:
                    return "هفت";
                case 8:
                    return "هشت";
                case 9:
                    return "نه";
                default:
                    return "";
            }

        }
        static string getHarfBajaygah(int jaygah, int adad)
        {
            switch (jaygah)
            {
                case 1:
                    return GetHarf(adad);
                case 2:
                    return dahgan(adad);
                case 3:
                    if (adad == 2)
                        return "دویست";
                    if (adad == 3)
                        return "سیصد";
                    if (adad == 5)
                        return "پانصد";
                    return GetHarf(adad) + "صد";
                default:
                    return "";
            }
        }
        static string dahgan(int adad)
        {
            switch (adad)
            {

                case 2:
                    return "بیست";
                case 3:
                    return "سی";
                case 4:
                    return "چهل";
                case 5:
                    return "پنجاه";
                case 6:
                    return "شصت";
                case 7:
                    return "هفتاد";
                case 8:
                    return "هشتاد";
                case 9:
                    return "نود";
                default:
                    return "";
            }
        }
        static string zireBist(int adad)
        {
            switch (adad)
            {
                case 1:
                    return " یازده";
                case 2:
                    return " دوازده";
                case 3:
                    return " سیزده";
                case 4:
                    return " چهارده";
                case 5:
                    return " پانزده";
                case 6:
                    return " شانزده";
                case 7:
                    return " هفده";
                case 8:
                    return " هجده";
                case 9:
                    return " نوزده";
                default:
                    return " ده";
            }
        }

        static string GetLetter(string adad)
        {
            adad = int.Parse(adad).ToString();
            if (adad == "0")
                return "";
            int len = adad.Length;
            string res = "";
            for (int i = 0; i < len; i++)
            {
                if (len - (i + 1) == 2)
                {
                    res = res + getHarfBajaygah(3, int.Parse(adad[i].ToString()));
                }
                else
                {
                    if (len - (i + 1) == 1)
                    {
                        if (int.Parse(adad[i].ToString()) == 1)
                        {
                            res = res + " " + zireBist(int.Parse(adad[1].ToString()));
                            break;
                        }
                        else
                        {
                            res = res + " " + getHarfBajaygah(2, int.Parse(adad[i].ToString()));
                        }
                    }
                    else if (len - (i + 1) == 0)
                    {
                        res = res + " " + GetHarf(int.Parse(adad[i].ToString()));
                    }
                }
            }
            return res;
        }
        static string GetPeleDesc(int Pele)
        {
            switch (Pele)
            {
                default:
                    return "";
                case 2:
                    return " هزار ";
                case 3:
                    return " میلیون ";
                case 4:
                    return "میلیارد";
                case 5:
                    return "تریلیون";
            }
        }
    }
}
