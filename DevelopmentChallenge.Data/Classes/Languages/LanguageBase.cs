using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes.Languages
{
    /// <summary>
    /// Base class for language strategies, providing common logic for resolving shape names 
    /// from translation dictionaries.
    /// </summary>
    public abstract class LanguageBase : ILanguage
    {
        /// <summary>
        /// Gets the localized HTML message to be displayed when the report is generated with an empty list of shapes.
        /// Must be implemented by derived language classes.
        /// </summary>
        public abstract string EmptyListMessage { get; }

        /// <summary>
        /// Gets the localized HTML title for the top of the geometric shapes report.
        /// Must be implemented by derived language classes.
        /// </summary>
        public abstract string ReportTitle { get; }

        /// <summary>
        /// Gets a dictionary mapping geometric shape types to their localized names.
        /// Must be implemented by derived classes to provide an array storing the singular form at index 0 and the plural form at index 1.
        /// </summary>
        protected abstract Dictionary<Type, string[]> Translations { get; }

        /// <summary>
        /// Formats the final summary footer of the report, displaying the grand totals across all shape types.
        /// Must be implemented by derived language classes to provide proper localized formatting.
        /// </summary>
        /// <param name="totalShapes">The total combined count of all shapes in the report.</param>
        /// <param name="totalArea">The total combined area of all shapes.</param>
        /// <param name="totalPerimeter">The total combined perimeter of all shapes.</param>
        /// <returns>A localized, HTML-formatted string representing the report's final totals.</returns>
        public abstract string FormatFooter(int totalShapes, decimal totalArea, decimal totalPerimeter);

        /// <summary>
        /// Formats a single line in the report, detailing the aggregated statistics for a specific shape type.
        /// Must be implemented by derived language classes to provide proper localized formatting.
        /// </summary>
        /// <param name="quantity">The total number of shapes of this type.</param>
        /// <param name="shapeName">The localized name of the shape (already appropriately pluralized).</param>
        /// <param name="area">The sum of the areas for all shapes of this type.</param>
        /// <param name="perimeter">The sum of the perimeters for all shapes of this type.</param>
        /// <returns>A localized, HTML-formatted string containing the shape's aggregated data.</returns>
        public abstract string FormatLine(int quantity, string shapeName, decimal area, decimal perimeter);

        /// <summary>
        /// Common implementation to resolve the shape name based on the quantity (Singular/Plural).
        /// </summary>
        public string ShapeName(Type shapeType, int quantity)
        {
            if (Translations.TryGetValue(shapeType, out string[] names))
            {
                return quantity == 1 ? names[0] : names[1];
            }

            return string.Empty;
        }
    }
}
