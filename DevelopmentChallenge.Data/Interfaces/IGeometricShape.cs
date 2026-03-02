namespace DevelopmentChallenge.Data.Interfaces
{
    /// <summary>
    /// Defines the fundamental contract for all geometric shapes, ensuring that any implementation 
    /// provides the necessary methods to calculate its specific area and perimeter.
    /// </summary>
    public interface IGeometricShape
    {
        /// <summary>
        /// Calculates the total surface area of the geometric shape based on its specific dimensions and mathematical formula.
        /// </summary>
        /// <returns>A decimal value representing the calculated area.</returns>
        decimal CalculateArea();

        /// <summary>
        /// Calculates the total boundary length (perimeter or circumference) of the geometric shape based on its specific dimensions.
        /// </summary>
        /// <returns>A decimal value representing the calculated perimeter.</returns>
        decimal CalculatePerimeter();
    }
}
