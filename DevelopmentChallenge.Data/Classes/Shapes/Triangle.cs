using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// Represents a triangle geometric shape. Implements the <see cref="IGeometricShape"/> interface
    /// to provide specific calculations for a triangle's area and perimeter.
    /// </summary>
    public class Triangle : IGeometricShape
    {
        /// <summary>
        /// The length of a single side of the equilateral triangle. Since all sides are equal, only one value is needed.
        /// </summary>
        private readonly decimal _side;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class with the specified side length.
        /// </summary>
        /// <param name="side">The length of the triangle's sides.</param>
        public Triangle(decimal side)
        {
            _side = side;
        }

        /// <summary>
        /// Calculates the area of the equilateral triangle. 
        /// </summary>
        /// <returns>A decimal value representing the total area of the equilateral triangle.</returns>
        public decimal CalculateArea()
        {
            return (decimal)(Math.Sqrt(3) / 4 * Math.Pow((double)_side, 2));
        }

        /// <summary>
        /// Calculates the perimeter of the equilateral triangle.
        /// </summary>
        /// <returns>A decimal value representing the total perimeter of the equilateral triangle.</returns>
        public decimal CalculatePerimeter()
        {
            return _side * 3;
        }
    }
}
