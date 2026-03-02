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
        /// 
        /// </summary>
        public abstract string EmptyListMessage { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string ReportTitle { get; }

        /// <summary>
        /// 
        /// </summary>
        protected abstract Dictionary<Type, string[]> Translations { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalShapes"></param>
        /// <param name="totalArea"></param>
        /// <param name="totalPerimeter"></param>
        /// <returns></returns>
        public abstract string FormatFooter(int totalShapes, decimal totalArea, decimal totalPerimeter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="shapeName"></param>
        /// <param name="area"></param>
        /// <param name="perimeter"></param>
        /// <returns></returns>
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
