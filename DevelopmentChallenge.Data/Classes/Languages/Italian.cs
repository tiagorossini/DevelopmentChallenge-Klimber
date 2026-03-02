using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes.Languages
{
    /// <summary>
    /// Represents the Italian language implementation for the geometric shapes report. 
    /// It provides localized strings, pluralization rules, and specific formatting tailored for Italian output.
    /// </summary>
    public class Italian : LanguageBase
    {
        /// <summary>
        /// Gets the Italian localized HTML header to display when the report is generated with an empty list of shapes.
        /// </summary>
        public override string EmptyListMessage => "<h1>Elenco vuoto di forme!</h1>";

        /// <summary>
        /// Gets the Italian localized HTML title for the top of the geometric shapes report.
        /// </summary>
        public override string ReportTitle => "<h1>Rapporto sulle forme</h1>";

        /// <summary>
        /// A lookup dictionary mapping geometric shape types to their Italian translations. 
        /// The array stores the singular form at index 0 and the plural form at index 1.
        /// </summary>
        protected override Dictionary<Type, string[]> Translations => new Dictionary<Type, string[]>
        {
            { typeof(Square), new[] { "Quadrato", "Quadrati" } },
            { typeof(Circle), new[] { "Cerchio", "Cerchi" } },
            { typeof(Triangle), new[] { "Triangolo", "Triangoli" } },
            { typeof(Rectangle), new[] { "Rettangolo", "Rettangoli" } },
            { typeof(Trapezoid), new[] { "Trapezio", "Trapezi" } }
        };

        /// <summary>
        /// Formats the final summary footer of the report in Italian, displaying the grand totals across all shape types.
        /// </summary>
        /// <param name="totalShapes">The total combined count of all shapes in the report.</param>
        /// <param name="totalArea">The total combined area of all shapes.</param>
        /// <param name="totalPerimeter">The total combined perimeter of all shapes.</param>
        /// <returns>An Italian localized, HTML-formatted string representing the report's final totals.</returns>
        public override string FormatFooter(int totalShapes, decimal totalArea, decimal totalPerimeter)
        {
            string shapeWord = totalShapes == 1 ? "forma" : "forme";
            return $"TOTALE:<br/>{totalShapes} {shapeWord} Perimetro {totalPerimeter:#.##} Area {totalArea:#.##}";
        }

        /// <summary>
        /// Formats a single line in the report in Italian, detailing the aggregated statistics for a specific shape type.
        /// </summary>
        /// <param name="quantity">The total number of shapes of this type.</param>
        /// <param name="shapeName">The Italian localized name of the shape (already appropriately pluralized).</param>
        /// <param name="area">The sum of the areas for all shapes of this type.</param>
        /// <param name="perimeter">The sum of the perimeters for all shapes of this type.</param>
        /// <returns>An Italian localized, HTML-formatted string containing the shape's aggregated data.</returns>
        public override string FormatLine(int quantity, string shapeName, decimal area, decimal perimeter)
        {
            return $"{quantity} {shapeName} | Area {area:#.##} | Perimetro {perimeter:#.##} <br/>";
        }
    }
}
