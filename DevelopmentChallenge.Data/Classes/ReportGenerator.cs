using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// A static utility class responsible for generating formatted, localized reports 
    /// that summarize collections of geometric shapes.
    /// </summary>
    public static class ReportGenerator
    {
        /// <summary>
        /// Generates an HTML-formatted string report aggregating the quantities, areas, and perimeters 
        /// of the provided geometric shapes, localized according to the specified language strategy.
        /// </summary>
        /// <param name="shapes">A list of objects implementing <see cref="IGeometricShape"/> to be analyzed and summarized.</param>
        /// <param name="language">The localization strategy implementing <see cref="ILanguage"/> that dictates the language, phrasing, and formatting of the output.</param>
        /// <returns>A localized, HTML-formatted string representing the complete geometric shapes report.</returns>
        public static string Print(List<IGeometricShape> shapes, ILanguage language)
        {
            var stringBuilder = new StringBuilder();

            if (!shapes.Any())
            {
                stringBuilder.Append(language.EmptyListMessage);
                return stringBuilder.ToString();
            }

            stringBuilder.Append(language.ReportTitle);

            int totalShapes = 0;
            decimal totalArea = 0m;
            decimal totalPerimeter = 0m;

            var groupings = shapes.GroupBy(shape => shape.GetType());

            foreach (var group in groupings)
            {
                int quantity = group.Count();
                decimal area = group.Sum(shape => shape.CalculateArea());
                decimal perimeter = group.Sum(shape => shape.CalculatePerimeter());

                string shapeName = language.ShapeName(group.Key, quantity);
                stringBuilder.Append(language.FormatLine(quantity, shapeName, area, perimeter));

                totalShapes += quantity;
                totalArea += area;
                totalPerimeter += perimeter;
            }

            stringBuilder.Append(language.FormatFooter(totalShapes, totalArea, totalPerimeter));

            return stringBuilder.ToString();
        }
    }
}
