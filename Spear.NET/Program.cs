using System;
using Spear.Utils;
using Spear.Math;
using Spear.Core;
using System.Text;

namespace Spear
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 300, height = 200;
            StringBuilder sb = new StringBuilder();
            for (int j = height - 1; j >= 0; j--)
            {
                for (int i = 0; i < width; i++)
                {
                    var lowerLeftCorner = new Vector3f(-2.0f, -1.0f, -1.0f);
                    var horizontal = new Vector3f( 4.0f, 0.0f, 0.0f );
                    var vertical = new Vector3f( 0.0f, 2.0f, 0.0f );
                    var origin = new Vector3f();

                    float u = (float)(float)i / (float)width;
                    float v = (float)(float)j / (float)height;

                    var ray = new Ray( origin, lowerLeftCorner + ( horizontal * u ) + (vertical * v) );

                    var color = Ray.LinerBlendBlueToWhite(ray);

                    int ir = (int)(255.99 * color.R);
                    int ig = (int)(255.99 * color.G);
                    int ib = (int)(255.99 * color.B);
                    sb.Append(ir);
                    sb.Append(" ");
                    sb.Append(ig);
                    sb.Append(" ");
                    sb.AppendLine(ib.ToString());
                }
            }
            ImageExporter.ExportPPM("sample.ppm",width,height, sb.ToString());
        }
    }
}
