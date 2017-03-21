using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class Writer
    {
        public static void writeHeaderWithTitle(string title)
        {
            writeALineWith('*', "");
            writeALineWith('*', title);
            writeALineWith('*', "");
        }

        public static void writeALineWith(char symbol, string centerWord)
        {
            int width = Console.WindowWidth - 1;
            string line = "";

            if (centerWord.Length > 0)
            {
                int half = (width - centerWord.Length - 8) / 2;

                string halfString = new String(' ', half);
                var border = new String(symbol, 3);

                string evenAdjsut = isOdd(centerWord.Length) ? "" : " ";

                line = border + halfString + " " + centerWord + " " + evenAdjsut + halfString + border;

                //Console.WriteLine("width:" + width + " centerWord.Length:" + centerWord.Length + " half:" + half);
            }
            else
                line = new string(symbol, width);

            Console.WriteLine(line);
        }

        private static bool isOdd(int value)
        {
            return value % 2 != 0;
        }

        internal static void writeFacebookIcon()
        {
            writeALineWith('*', "");
            writeALineWith('*', "    ****                               **                            **    **");
            writeALineWith('*', "   *****                               **                            **   ** ");
            writeALineWith('*', "  ***                                  **                            **  **  ");
            writeALineWith('*', "*******   ******    ******    ******   *******    ******    ******   ** **   ");
            writeALineWith('*', "*******  ********  ********  ********  ********  ********  **    **  ****    ");
            writeALineWith('*', "  ***          **  **    **  **    **  **    **  **    **  **    **  ****    ");
            writeALineWith('*', "  ***     *******  **        ********  **    **  **    **  **    **  *****   ");
            writeALineWith('*', "  ***    **    **  **        **        **    **  **    **  **    **  **  **  ");
            writeALineWith('*', "  ***    **    **  **    **  **    **  **    **  **    **  **    **  **   ** ");
            writeALineWith('*', "  ***     ******    ******    ******   *******    ******    ******   **    **");
            writeALineWith('*', "");

        }
    }
}
