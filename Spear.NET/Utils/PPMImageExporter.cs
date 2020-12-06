using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spear.Utils
{
    public class PPMImageExporter
    {
        public static void ExportPPM( string fileName, int width, int height ) 
        {
            using (var writer = new StreamWriter(fileName)) 
            {
                writer.WriteLine("P3");
                writer.Write( width );
                writer.Write(" ");
                writer.WriteLine( height );
                writer.WriteLine("255");
                // Now start writing stuff
                for (int j = height - 1; j >= 0; j--) 
                {
                    for (int i = 0; i < width; i++) 
                    {
                        float r = (float)i / (float)width;
                        float g = (float)j / (float)height;
                        float b = 0.2f;
                        int ir = (int)(255.99 * r);
                        int ig = (int)(255.99 * g);
                        int ib = (int)(255.99 * b);
                        writer.Write( ir );
                        writer.Write(" ");
                        writer.Write(ig);
                        writer.Write(" ");
                        writer.WriteLine(ib);
                    }
                }
            }
        }
    }
}
