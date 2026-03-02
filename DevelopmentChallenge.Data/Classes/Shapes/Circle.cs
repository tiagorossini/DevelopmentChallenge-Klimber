using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// Represents a circular geometric shape. Implements the <see cref="IGeometricShape"/> interface
    /// to provide specific calculations for a circle's area and circumference (perimeter).
    /// </summary>
    public class Circle : IGeometricShape
    {
        /// <summary>
        /// The radius of the circle, calculated as half of the provided diameter during initialization.
        /// </summary>
        private readonly decimal _radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class using the specified diameter.
        /// </summary>
        /// <param name="diameter">The full length across the circle, which is halved to determine the radius.</param>
        public Circle(decimal diameter)
        {
            _radius = diameter / 2;
        }

        /// <summary>
        /// Calculates the area of the circle.
        /// </summary>
        /// <returns>A decimal value representing the total area of the circle.</returns>
        public decimal CalculateArea()
        {
            return (decimal)(Math.PI * Math.Pow((double)_radius, 2));
        }

        /// <summary>
        /// Calculates the perimeter (circumference) of the circle.
        /// </summary>
        /// <returns>A decimal value representing the total circumference of the circle.</returns>
        public decimal CalculatePerimeter()
        {
            return (decimal)Math.PI * _radius * 2;
        }
    }
}
