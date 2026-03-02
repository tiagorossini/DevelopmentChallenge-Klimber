using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// Represents a rectangular geometric shape. Implements the <see cref="IGeometricShape"/> interface
    /// to provide specific calculations for a rectangle's area and perimeter.
    /// </summary>
    public class Rectangle : IGeometricShape
    {
        /// <summary>
        /// The length of the base (or width) of the rectangle.
        /// </summary>
        private readonly decimal _base;

        /// <summary>
        /// The length of the height (or length) of the rectangle.
        /// </summary>
        private readonly decimal _height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class with the specified base and height dimensions.
        /// </summary>
        /// <param name="base">The base length of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(decimal @base, decimal height)
        {
            _base = @base;
            _height = height;
        }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>A decimal value representing the total area of the rectangle.</returns>
        public decimal CalculateArea()
        {
            return _base * _height;
        }

        /// <summary>
        /// Calculates the perimeter of the rectangle.
        /// </summary>
        /// <returns>A decimal value representing the total perimeter of the rectangle.</returns>
        public decimal CalculatePerimeter()
        {
            return (_base + _height) * 2;
        }
    }
}
