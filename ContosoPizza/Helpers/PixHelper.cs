using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace ContosoPizza.Helpers
{
    public static class PixHelper
    {
        public static string GerarCodigoPix(string chave, decimal valor, string nome, string cidade)
        {
            string payload = 
                "00201" +
                "26" + (14 + chave.Length).ToString("00") +
                "0014BR.GOV.BCB.PIX01" + chave +
                "52040000" +
                "5303986" +
                "54" + valor.ToString("0.00").Length.ToString("00") + valor.ToString("0.00") +
                "5802BR" +
                "60" + cidade.Length.ToString("00") +nome +
                "60" + cidade.Length.ToString("00") + nome +
                "60" + cidade.Length.ToString("00") + cidade + "62070503****";
            
            string crc = GerarCRC16(payload + "6304");

            return payload + "6304" + crc;
        }

        private static string GerarCRC16(string payload)
        {
            ushort polinomio = 0x1021;
            ushort resultado = 0xFFFF;

            foreach (char c in payload)
            {
                resultado ^= (ushort)(c << 8);
                for (int i = 0; i < 8; i++)
                {
                    if((resultado & 0x8000) != 0)
                        resultado = (ushort)((resultado << 1) ^ polinomio);

                    else
                        resultado <<= 1;
                }
            }

            return resultado.ToString("X4");
        }
    }
}