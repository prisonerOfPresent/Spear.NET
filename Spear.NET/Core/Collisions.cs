using Spear.Math;

namespace Spear.Core
{
    public class Collisions
    {
        public static float CollidingSphere( Vector3f center, float radius, Ray ray )
        {
            Vector3f originCenter = ray.Origin - center;
            float a = Vector3f.Dot(ray.Direction, ray.Direction);
            float b = 2.0f * Vector3f.Dot(originCenter, ray.Direction);
            float c = Vector3f.Dot(originCenter, originCenter) - (radius * radius);
            float descriminant = ( b * b ) - (4 * a * c);
            if (descriminant < 0)
                return -1f;
            else
            {
                return (-b - (float)System.Math.Sqrt(descriminant) ) / (2f * a);
            }
        }
    }
}
