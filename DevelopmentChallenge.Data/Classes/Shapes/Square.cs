using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// Represents a square geometric shape. Implements the <see cref="IGeometricShape"/> interface
    /// to provide specific calculations for a square's area and perimeter.
    /// </summary>
    public class Square : IGeometricShape
    {
        /// <summary>
        /// The length of a single side of the square.
        /// </summary>
        private readonly decimal _side;

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with the specified side length.
        /// </summary>
        /// <param name="side">The length of the square's sides.</param>
        public Square(decimal side)
        {
            _side = side;
        }

        /// <summary>
        /// Calculates the area of the square.
        /// </summary>
        /// <returns>A decimal value representing the total area of the square.</returns>
        public decimal CalculateArea()
        {
            return _side * _side;
        }

        /// <summary>
        /// Calculates the perimeter of the square.
        /// </summary>
        /// <returns>A decimal value representing the total perimeter of the square.</returns>
        public decimal CalculatePerimeter()
        {
            return _side * 4;
        }
    }
}
