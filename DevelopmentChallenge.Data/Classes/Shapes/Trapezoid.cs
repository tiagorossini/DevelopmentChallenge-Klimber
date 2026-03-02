using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// Represents a trapezoid geometric shape. Implements the <see cref="IGeometricShape"/> interface
    /// to provide specific calculations for a trapezoid's area and perimeter.
    /// </summary>
    public class Trapezoid : IGeometricShape
    {
        /// <summary>
        /// The length of the longer parallel base (often denoted as 'B' or 'a').
        /// </summary>
        private readonly decimal _majorBase;

        /// <summary>
        /// The length of the shorter parallel base (often denoted as 'b').
        /// </summary>
        private readonly decimal _minorBase;

        /// <summary>
        /// The perpendicular height or distance between the major and minor parallel bases.
        /// </summary>
        private readonly decimal _height;

        /// <summary>
        /// The length of the right non-parallel side (leg).
        /// </summary>
        private readonly decimal _rightSide;

        /// <summary>
        /// The length of the left non-parallel side (leg).
        /// </summary>
        private readonly decimal _leftSide;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trapezoid"/> class with the specified bases and height.
        /// </summary>
        /// <param name="majorBase">The length of the bottom (larger) parallel side.</param>
        /// <param name="minorBase">The length of the top (smaller) parallel side.</param>
        /// <param name="leftSide">The length of the left non-parallel side.</param>
        /// <param name="rightSide">The length of the right non-parallel side.</param>
        /// <param name="height">The distance between the two parallel bases.</param>
        public Trapezoid(decimal majorBase, decimal minorBase, decimal rightSide, decimal leftSide, decimal height)
        {
            _majorBase = majorBase;
            _minorBase = minorBase;
            _rightSide = rightSide;
            _leftSide = leftSide;
            _height = height;
        }

        /// <summary>
        /// Calculates the area of the trapezoid.
        /// </summary>
        /// <returns>A decimal value representing the total area of the trapezoid.</returns>
        public decimal CalculateArea()
        {
            return (_majorBase + _minorBase) / 2 * _height;
        }

        /// <summary>
        /// Calculates the perimeter of the trapezoid.
        /// </summary>
        /// <returns>A decimal value representing the total perimeter of the trapezoid.</returns>
        public decimal CalculatePerimeter()
        {
            return _majorBase + _minorBase + _rightSide + _leftSide;
        }
    }
}
