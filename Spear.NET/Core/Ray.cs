using Spear.Math;

namespace Spear.Core
{
    public class Ray
    {
        /// <summary>
        /// private fields to hold start and end positions ( points ) of a ray.
        /// </summary>
        private Vector3f _startPosition;
        private Vector3f _endPosition;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Ray() { }

        /// <summary>
        /// Parameterized constructor that initializes member fields
        /// </summary>
        /// <param name="start"> Start position of the ray </param>
        /// <param name="end"> End position of the ray </param>
        public Ray(Vector3f start, Vector3f end) { _startPosition = start; _endPosition = end; }

        // Public properties

        /// <summary>
        /// Returns origin ( starting point ) of the ray.
        /// </summary>
        public Vector3f Origin => _startPosition;

        /// <summary>
        /// Returns direction ( ending point ) of the ray.
        /// </summary>
        public Vector3f Direction => _endPosition;


        // Public Methods

        /// <summary>
        /// Returns point at a specific length t, from origin
        /// </summary>
        /// <param name="t"> Length from origin </param>
        /// <returns> Point at which length reaches from origin </returns>
        public Vector3f PointAtDistance(float distance) => Origin + ( Direction * distance );

        /// <summary>
        /// Just a static helper method to create a liner blend from blue to white
        ///  A linear blend should always be in form
        ///  (1 - t) * start value +  (t * end value ).
        ///  t should always go from 0 to 1.
        /// </summary>
        /// <param name="ray"></param>
        /// <returns> returns a light blue blended color with white </returns>
        public static Vector3f LinerBlendBlueToWhite( Ray ray ) 
        {
            Vector3f unitVectorOfDirection = Vector3f.UnitVector(ray.Direction);
            // we are taking t as half of Y direction plus 1, so making sure we are always in 
            // 0 < t < 1 range.
            float t = 0.5f * (unitVectorOfDirection.Y + 1.0f);
            // returns the linear blended colour vector from above formula
            // ( ( 1 - t ) * start value ) + ( end value * t )
            // Start value is a white - 1,1,1
            // end value is a sort of light blue - 0.5, 0.7, 1 as rgb
            // and we are blending those together to produce our colour.
            return 
                ( new Vector3f( 1.0f, 1.0f, 1.0f ) * (1 - t) ) + 
                ( new Vector3f( 0.5f, 0.7f, 1.0f ) * t );
        }
    }
}
