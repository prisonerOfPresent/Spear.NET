using System;
using Spear.Utils;

namespace Spear
{
    class Program
    {
        static void Main(string[] args)
        {
            PPMImageExporter.ExportPPM("sample.ppm",1920,1080);
        }
    }
}
