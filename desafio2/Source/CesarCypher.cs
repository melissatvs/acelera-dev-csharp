using System;
using System.Text;
using System.Linq;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private const string cMutaveis = "abcdefghijklmnopqrstuvwxyz";
        private const string cImutaveis = " 0123456789";
        private const int cCasas = 3;

        public string Crypt(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }


            StringBuilder vResultado = new StringBuilder();
            char[] vTexto;
            vTexto = message.ToLower().ToCharArray();

            foreach (char c in vTexto)
            {

                if (inStr(c, cMutaveis))
                {
                    vResultado.Append(AndaCasas(c));
                }
                else if (inStr(c, cImutaveis))
                {
                    vResultado.Append(c);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }

            return vResultado.ToString();
        }

        public string Decrypt(string cryptedMessage)
        {


            if (cryptedMessage == null)
            {
                throw new ArgumentNullException();
            }


            StringBuilder vResultado = new StringBuilder();
            char[] vTexto;
            vTexto = cryptedMessage.ToLower().ToCharArray();



            foreach (char c in vTexto)
            {

                if (inStr(c, cMutaveis))
                {
                    vResultado.Append(VoltaCasas(c));
                }
                else if (inStr(c, cImutaveis))
                {
                    vResultado.Append(c);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }

            return vResultado.ToString();
            
        }

        private char AndaCasas(char c)
        {
            int vAscii = Convert.ToInt32(c) + cCasas;

            if (vAscii > Convert.ToInt32(cMutaveis[cMutaveis.Length-1]))
            {
                vAscii = vAscii - cMutaveis.Length;
            }

            return Convert.ToChar(vAscii);
        }
		
        private char VoltaCasas(char c)
        {
            int vAscii = Convert.ToInt32(c) - cCasas;

            if (vAscii < Convert.ToInt32(cMutaveis[0]))
            {
                vAscii = vAscii + cMutaveis.Length;
            }

            return Convert.ToChar(vAscii);
        }

        private bool inStr(char pLetra, string pTexto)
        {            
            
            for (int i = 0; i < pTexto.Length; i++)
            {
                if (pLetra == pTexto[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
