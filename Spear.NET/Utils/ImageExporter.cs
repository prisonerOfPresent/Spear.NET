using Spear.Math;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spear.Utils
{
    public class ImageExporter
    {
        public static void ExportPPM( string fileName, int width, int height, string data ) 
        {
            using (var writer = new StreamWriter(fileName)) 
            {
                writer.WriteLine("P3");
                writer.Write( width );
                writer.Write(" ");
                writer.WriteLine( height );
                writer.WriteLine("255");
                // Now start writing stuff
                writer.Write(data);
            }
        }
    }
}
