using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class DePara
    {
        public string IdMoeda { set; get; }
        public int CodigoCotacao { set; get; }

        public static DePara selecionarCodigoCotacao(string idMoeda)
        {
            int CodCotacao = 0;
            switch (idMoeda)
            {
                case "AFN": CodCotacao = 66; break;
                case "ALL": CodCotacao = 49; break;
                case "ANG": CodCotacao = 33; break;
                case "ARS": CodCotacao = 3; break;
                case "AWG": CodCotacao = 6; break;
                case "BOB": CodCotacao = 56; break;
                case "BYN": CodCotacao = 64; break;
                case "CAD": CodCotacao = 25; break;
                case "CDF": CodCotacao = 58; break;
                case "CLP": CodCotacao = 16; break;
                case "COP": CodCotacao = 37; break;
                case "CRC": CodCotacao = 52; break;
                case "CUP": CodCotacao = 8; break;
                case "CVE": CodCotacao = 51; break;
                case "CZK": CodCotacao = 29; break;
                case "DJF": CodCotacao = 36; break;
                case "DZD": CodCotacao = 54; break;
                case "EGP": CodCotacao = 12; break;
                case "EUR": CodCotacao = 20; break;
                case "FJD": CodCotacao = 38; break;
                case "GBP": CodCotacao = 22; break;
                case "GEL": CodCotacao = 48; break;
                case "GIP": CodCotacao = 18; break;
                case "HTG": CodCotacao = 63; break;
                case "ILS": CodCotacao = 40; break;
                case "IRR": CodCotacao = 17; break;
                case "ISK": CodCotacao = 11; break;
                case "JPY": CodCotacao = 9; break;
                case "KES": CodCotacao = 21; break;
                case "KMF": CodCotacao = 19; break;
                case "LBP": CodCotacao = 42; break;
                case "LSL": CodCotacao = 4; break;
                case "MGA": CodCotacao = 35; break;
                case "MGB": CodCotacao = 26; break;
                case "MMK": CodCotacao = 69; break;
                case "MRO": CodCotacao = 53; break;
                case "MRU": CodCotacao = 15; break;
                case "MUR": CodCotacao = 7; break;
                case "MXN": CodCotacao = 41; break;
                case "MZN": CodCotacao = 43; break;
                case "NIO": CodCotacao = 23; break;
                case "NOK": CodCotacao = 62; break;
                case "OMR": CodCotacao = 34; break;
                case "PEN": CodCotacao = 45; break;
                case "PGK": CodCotacao = 2; break;
                case "PHP": CodCotacao = 24; break;
                case "RON": CodCotacao = 5; break;
                case "SAR": CodCotacao = 44; break;
                case "SBD": CodCotacao = 32; break;
                case "SGD": CodCotacao = 70; break;
                case "SLL": CodCotacao = 10; break;
                case "SOS": CodCotacao = 61; break;
                case "SSP": CodCotacao = 47; break;
                case "SZL": CodCotacao = 55; break;
                case "THB": CodCotacao = 39; break;
                case "TRY": CodCotacao = 13; break;
                case "TTD": CodCotacao = 67; break;
                case "UGX": CodCotacao = 59; break;
                case "USD": CodCotacao = 1; break;
                case "UYU": CodCotacao = 46; break;
                case "VES": CodCotacao = 68; break;
                case "VUV": CodCotacao = 57; break;
                case "WST": CodCotacao = 28; break;
                case "XAF": CodCotacao = 30; break;
                case "XAU": CodCotacao = 60; break;
                case "XDR": CodCotacao = 27; break;
                case "XOF": CodCotacao = 14; break;
                case "XPF": CodCotacao = 50; break;
                case "ZAR": CodCotacao = 65; break;
                case "ZWL": CodCotacao = 3; break;
            }

            return new DePara
            {
                IdMoeda = idMoeda,
                CodigoCotacao = CodCotacao
            };

        }

                    
    }

}