using Spear.Math;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spear.Utils
{
    public class ImageExporter
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
                        var color = new Vector3f( (float)(i/width), (float)(j/height), 0.2f );
                        int ir = (int)(255.99 * color.R);
                        int ig = (int)(255.99 * color.G);
                        int ib = (int)(255.99 * color.B);
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
