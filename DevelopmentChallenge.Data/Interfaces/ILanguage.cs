using System;

namespace DevelopmentChallenge.Data.Interfaces
{
    /// <summary>
    /// Interface which defines the contract for language-specific implementations for the geometric shapes report.
    /// </summary>
    public interface ILanguage
    {
        /// <summary>
        /// Gets the localized message to be displayed when the report is generated with an empty list of shapes.
        /// </summary>
        string EmptyListMessage { get; }

        /// <summary>
        /// Gets the localized title or header text for the top of the geometric shapes report.
        /// </summary>
        string ReportTitle { get; }

        /// <summary>
        /// Retrieves the localized name of a specific geometric shape, appropriately pluralized based on the given quantity.
        /// </summary>
        /// <param name="shapeType">The exact class type of the geometric shape.</param>
        /// <param name="quantity">The total number of shapes of this type, used to determine whether to return the singular or plural form.</param>
        /// <returns>The localized string representing the shape's name.</returns>
        string ShapeName(Type shapeType, int quantity);

        /// <summary>
        /// Formats a single line in the report, detailing the aggregated statistics for a specific type of shape.
        /// </summary>
        /// <param name="quantity">The total number of shapes of this type.</param>
        /// <param name="shapeName">The localized name of the shape (already correctly pluralized).</param>
        /// <param name="area">The sum of the areas for all shapes of this type.</param>
        /// <param name="perimeter">The sum of the perimeters for all shapes of this type.</param>
        /// <returns>A localized, formatted string containing the shape's aggregated data.</returns>
        string FormatLine(int quantity, string shapeName, decimal area, decimal perimeter);

        /// <summary>
        /// Formats the final summary footer of the report, displaying the grand totals across all shape types.
        /// </summary>
        /// <param name="totalShapes">The total combined count of all shapes in the report.</param>
        /// <param name="totalArea">The total combined area of all shapes in the report.</param>
        /// <param name="totalPerimeter">The total combined perimeter of all shapes in the report.</param>
        /// <returns>A localized, formatted string representing the report's final totals.</returns>
        string FormatFooter(int totalShapes, decimal totalArea, decimal totalPerimeter);
    }
}
