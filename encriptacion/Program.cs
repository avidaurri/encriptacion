using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encriptacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "master";
            string encriptado="";

            encriptado=text_to_ascii(cadena);

            // Console.WriteLine(encriptado);
            Console.WriteLine(desencriptar(encriptado));

            Console.ReadKey();

        }

        public static string text_to_ascii(string password)
        {
            //pasar cadena a arreglo de caracteres
            char[] arr = password.ToCharArray();
            //invertir el orden de los caracteres
            Array.Reverse(arr);

            string invertida = new string(arr);
            string caracter;
            string g = "";
            string a = "";
            string cad = "";
            string compuesta = "";

            //recorrer la cadena de carateres
            for (int i = 0; i < invertida.Length; i++)
            {
                caracter = invertida[i].ToString();
                //convertir a codigo ascii el caracter y concatenarlo en un string separado por comas
                g = Encoding.ASCII.GetBytes(caracter)[0].ToString();
                Console.WriteLine(g);
                if (Convert.ToInt32(g) < 128)
                {

                    g = (Convert.ToInt32(g) + 128).ToString();

                }
                else
                {

                    g = (Convert.ToInt32(g) - 128).ToString();

                }

                cad = cad + g;
                cad = cad + ',';

            }
            //eliminar la ultima coma de la cadena
            compuesta = cad.Substring(0, cad.Length - 1);
            //Console.WriteLine(cad);
            //Console.WriteLine(compuesta);
            a = ascii_to_text(compuesta);

            return a;
        }

        public static string ascii_to_text(string cad)
        {
            string myString = "";
            string[] valores;

            valores = cad.Split(',');
            //recorrer los valores separados por comas
            foreach (string item in valores)
            {
                //codificar caracteres a secuencia de bytes
                // byte[] bytes = Encoding.Default.GetBytes(item);
                myString = myString + (char)Convert.ToInt32(item);
            }
            Console.WriteLine(myString);
            return myString;

        }

        public static string desencriptar(string password)
        {

            string cad="";
            string myString = "";
            string compuesta = "";
            string[] valores;
            int i;
            for (i = 0; i < password.Length; i++)
            {
                //Console.WriteLine(password[i]);
                compuesta = ""+Convert.ToInt32(password[i]);
                //Console.WriteLine(compuesta);
                
                cad = cad + compuesta;
                cad = cad + ',';

            }

            //compuesta = cad.Substring(0, cad.Length - 1);
            Console.WriteLine(cad);

            cad = cad.Substring(0, cad.Length - 1);

            byte[] array=new byte[6];

            /*valores = cad.Split(',');
            //recorrer los valores separados por comas
            foreach (string item in valores)
            {
                Console.WriteLine(item);
                //codificar caracteres a secuencia de bytes
                // byte[] bytes = Encoding.Default.GetBytes(item);
                myString = myString + Encoding.ASCII.GetString(item);
                //String outputB = Encoding.ASCII.GetString(item);
                //g = Encoding.ASCII.GetBytes(caracter)[0].ToString();
                // myString = myString + (byte)Convert.ToInt32(item);

            }*/

            valores = cad.Split(',');
            int ini = 0;
            string ite;
            //recorrer los valores separados por comas
            foreach (string item in valores)
            {
                if(Convert.ToInt32(item) < 255)
                {
                    ite = (Convert.ToInt32(item) - 128).ToString();
                }
                else
                {
                    ite = (Convert.ToInt32(item) + 128).ToString();
                }

                Console.WriteLine("el item es :" +ite);
                array[ini] = Convert.ToByte(ite);
                //myString = myString + Encoding.ASCII.GetString(item);

                ini++;
            }



            string value = ASCIIEncoding.ASCII.GetString(array);
            Console.WriteLine(value);

            // Console.WriteLine(myString);
            return myString;
        }





    }
}
