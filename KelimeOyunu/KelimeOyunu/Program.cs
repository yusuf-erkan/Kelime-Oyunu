using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace KelimeOyunu
{/*Ekrana girilen harf ile başlayan ilk Productname ekrana yazdırılır ve gelen kelimenin 
 * son harfiyle başlayan kelimeler ard arda yazdırılır.Kaç kelime bulunduysa kelime sayısı da 
 * yazdırılır.
 */
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-KJG5C0HL\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand("Select case when CHARINDEX(' ',ProductName)>0 Then LEFT(ProductName, CHARINDEX(' ', ProductName) - 1) else ProductName END FROM PRODUCTS", con);
            /*
             * Charindex'le productName içinde boşluk kaçıncı indexteyse onu döndürür.
             * Left ile ProductName'de boşluktan önceki(Sol tarafını) alıcak.
             * Else durumunda ise Charindexte birşey bulamadıysa (boşluk bulamadıysa) direk kelimeyi yazdırır.
             * */
            DataTable dt = new DataTable();
            while (1 == 1)
            {
                Console.Write("Lütfen harf giriniz: ");
                string alınanharf = Console.ReadLine().ToUpper();
                bool sart = true;
                int i = 0, x = 0,y=0;
                string tablodegeri;
                do
                {
                    adp.Fill(dt);
                    dt.Rows[y][0] = " ";
                    //ekrana yazdırılan deger tekrar döngüye girmesin diye null yapıldı.
                    tablodegeri = dt.Rows[i][0].ToString().ToUpper();
                    //0. sütunun i. satırına bakar.
                    if (tablodegeri.Substring(0, 1) == alınanharf)
                    //Substring(0,1) 0.harften başlayıp ilk harfi alır.
                    {
                        Console.WriteLine(tablodegeri);
                        alınanharf = tablodegeri[tablodegeri.Length - 1].ToString();
                        //alınan harf tablodeğerinin son harfine eşitledik.
                        i = 0;
                        x++;
                    }

                    if (i == dt.Rows.Count - 1)
                    {
                        sart = false;
                        Console.WriteLine("{0} kelime bulundu", x);
                    }
                    dt.Clear();
                    i++;
                    y = i - 1;
                } while (sart);
            }
        }
    }
}
