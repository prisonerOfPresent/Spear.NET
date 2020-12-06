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
        public Vector3f PointAtParameter(float t) => Origin + ( Direction * t );

        /// <summary>
        /// Just a static helper method
        /// </summary>
        /// <param name="ray"></param>
        /// <returns> a color of direction of the ray </returns>
        public static Vector3f Color( Ray ray ) 
        {
            Vector3f unitVectorOfDirection = Vector3f.UnitVector(ray.Direction);
            float t = 0.5f * (unitVectorOfDirection.Y + 1.0f);
            return 
                ( new Vector3f( 1.0f, 1.0f, 1.0f ) * (1 - t) ) + 
                ( new Vector3f( 0.5f, 0.7f, 1.0f ) * t );
        }
    }
}
