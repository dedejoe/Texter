using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Texter
{
    class Editor
    {
        //This editor class is now obselete, but it would output the template for a level as a file.

        public void OutputTemplate(string filepath)
        {
            //create file stream
            FileStream fs = System.IO.File.Create(filepath);
            fs.Close();

            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(filepath);

            string row = "";

            //write top boundary
            for (int i = 0; i < 120; i++)
            {
                row += '▓';
            }

            streamWriter.WriteLine(row);

            //create middle section 27 long + top and bottom boundary
            for (int i = 0; i < 27; i++)
            {
                //add rows
                row = "";

                //add left boundary
                row += '▓';

                for (int l = 0; l < 118; l++)
                {
                    row += ' ';
                }

                //add right boundary
                row += '▓';

                //write the row
                streamWriter.WriteLine(row);
            }

            row = "";

            //create bottom boundary
            for (int i = 0; i < 120; i++)
            {
                row += '▓';
            }
            streamWriter.WriteLine(row);

            streamWriter.Close();
            fs.Close();

        }

    }
}
