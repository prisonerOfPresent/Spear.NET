using System;
using static System.Math;

namespace Spear.Math
{
    public class Vector3f
    {
        private float[] _components = new float[3];

        public Vector3f() : this(0.0f, 0.0f, 0.0f)
        {

        }
        public Vector3f(float x, float y, float z)
        {
            _components[0] = x;
            _components[1] = y;
            _components[2] = z;
        }

        /// <summary>
        /// Public properties
        /// </summary>
        public float X
        {
            get => _components[0];
            set { _components[0] = value; }
        }
        public float Y
        {
            get => _components[1];
            set
            {
                _components[1] = value;
            }
        }
        public float Z
        {
            get => _components[2];
            set
            {
                _components[2] = value;
            }
        }

        // To make color stuff easier
        public float R => X;
        public float G => Y;
        public float B => Z;

        // length methods

        /// <summary>
        /// Magnitude or length of the vector
        /// </summary>
        /// <returns>Length or Magintude of vector in floating point format.</returns>
        public float Length() => (float)Sqrt(LengthSquared());

        /// <summary>
        /// Calculates the Square of magnitude of vector.
        /// </summary>
        /// <returns>Squared magnitude of the vector.</returns>
        public float LengthSquared() => (float)(Pow(X, 2) + Pow(Y, 2) + Pow(Z, 2));

        /// <summary>
        /// Dot product
        /// </summary>
        /// <returns>dot product of two vectors</returns>
        public static float Dot(Vector3f a, Vector3f b) => (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);

        public static Vector3f Cross( Vector3f a, Vector3f b ) => 
            new Vector3f( 
                ( (a.Y * b.Z) - ( a.Z * b.Y )), // aYbZ - aZbY 
                - ( (a.X * b.Z) - (a.Z * b.X) ), // - (aXbZ - aZbX)
                ( (a.X * b.Y) - ( a.Y * b.X ) ) // aXbY - aYbX
                );


        /// <summary>
        /// Normalize the current vector.
        /// </summary>
        public void Normalize() 
        {
            float k = 1.0f / Length();
            X *= k;
            Y *= k;
            Z *= k;
        }

        /// <summary>
        /// Get a unit vector out of a vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>A new unit vector ( normalized ) from the input vector.</returns>
        public static Vector3f UnitVector(Vector3f vector) => vector / vector.Length();

        // operator overloads

        /// <summary>
        /// Unary Plus operator overload
        /// </summary>
        /// <param name="vector"></param>
        /// <returns> new positive Vector3f with components of parameter vector. </returns>
        public static Vector3f operator +(Vector3f vector)
        {
            return new Vector3f(
                Abs(vector.X),
                Abs(vector.Y),
                Abs(vector.Z));
        }

        /// <summary>
        /// Unary minus operator overload
        /// </summary>
        /// <param name="vector"></param>
        /// <returns> new Vector3f with all components of original vector
        /// with opposite sign (negative) </returns>
        public static Vector3f operator -(Vector3f vector)
        {
            return new Vector3f(-vector.X, -vector.Y, -vector.Z);
        }

        /// <summary>
        /// Binary + operator overload
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> a new Vector3f that adds components of a and b together </returns>
        public static Vector3f operator +(Vector3f a, Vector3f b)
        {
            return new Vector3f(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Binary - operator overload
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> a new Vector3f that subtracts components of b from components of a. </returns>
        public static Vector3f operator -(Vector3f a, Vector3f b)
        {
            return new Vector3f(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Binary * operatir overload
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> a new vector that multiplies components of both a and b. </returns>
        public static Vector3f operator *(Vector3f a, Vector3f b)
        {
            return new Vector3f(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        /// <summary>
        /// Binary / operator overload
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>a new Vector that is constructed by dividing the components 
        /// of vector a by the components of vetcor b.</returns>
        public static Vector3f operator /(Vector3f a, Vector3f b)
        {
            if (b.X == 0.0f || b.Y == 0.0f || b.Z == 0.0f)
                throw new InvalidOperationException("Cannot divide a vector by a zero vector.");
            return new Vector3f(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        /// <summary>
        /// Overload of binary division for a float and a vector.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="a"></param>
        /// <returns> a new Vecto3f with magnitude divided by factor k </returns>
        public static Vector3f operator /(Vector3f a, float k)
        {
            if (k == 0.0f)
                throw new InvalidOperationException("Cannot divide a vector by zero.");
            return new Vector3f(a.X / k, a.Y / k, a.Z / k);
        }

        /// <summary>
        /// Overload of binary multiplication operator for a vector and a float.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="k"></param>
        /// <returns> a new Vector3f with magnitude multiplied by factor k </returns>
        public static Vector3f operator *(Vector3f a, float k)
        {
            return new Vector3f(a.X * k, a.Y * k, a.Z * k);
        }



        // Do we really need the index operator? Let us see.
        public float this[int index] => _components[index];
    }
}
