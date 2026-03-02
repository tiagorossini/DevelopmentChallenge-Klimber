using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Languages;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace DevelopmentChallenge.Data.Tests
{
    /// <summary>
    /// A test fixture containing unit tests for the <see cref="ReportGenerator"/> class. 
    /// Verifies the correct generation, calculation, and localization of geometric shape reports.
    /// </summary>
    [TestFixture]
    public class ReportGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
        }

        /// <summary>
        /// Verifies that generating a report with an empty list using the Spanish language strategy 
        /// returns the localized "empty list" message.
        /// </summary>
        [TestCase]
        public void Print_EmptyList_InSpanish_ReturnsEmptyMessage()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReportGenerator.Print(new List<IGeometricShape>(), new Spanish()));
        }

        /// <summary>
        /// Verifies that generating a report with an empty list using the English language strategy 
        /// returns the localized "empty list" message.
        /// </summary>
        [TestCase]
        public void Print_EmptyList_InEnglish_ReturnsEmptyMessage()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReportGenerator.Print(new List<IGeometricShape>(), new English()));
        }

        /// <summary>
        /// Verifies that generating a report with an empty list using the Italian language strategy 
        /// returns the localized "empty list" message.
        /// </summary>
        [TestCase]
        public void Print_EmptyList_InItalian_ReturnsEmptyMessage()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                ReportGenerator.Print(new List<IGeometricShape>(), new Italian()));
        }

        /// <summary>
        /// Verifies that a report generated for a single square using the Spanish strategy correctly calculates 
        /// the area and perimeter and returns the singular form of the shape's name.
        /// </summary>
        [TestCase]
        public void Print_SingleSquare_InSpanish_ReturnsCorrectSummary()
        {
            var squares = new List<IGeometricShape> { new Square(5) };

            var summary = ReportGenerator.Print(squares, new Spanish());

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forma Perimetro 20 Area 25", summary);
        }

        /// <summary>
        /// Verifies that a report generated for multiple squares using the English strategy correctly aggregates 
        /// the areas and perimeters and returns the plural form of the shape's name.
        /// </summary>
        [TestCase]
        public void Print_MultipleSquares_InEnglish_ReturnsCorrectSummary()
        {
            var squares = new List<IGeometricShape>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var summary = ReportGenerator.Print(squares, new English());

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", summary);
        }

        /// <summary>
        /// Verifies that a report generated for a mixed list of shapes (Squares, Circles, Triangles) using the English strategy 
        /// correctly groups, aggregates, and formats the output, handling decimal calculations properly based on the current culture.
        /// </summary>
        [TestCase]
        public void Print_MultipleShapeTypes_InEnglish_ReturnsCorrectSummary()
        {
            var shapes = new List<IGeometricShape>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square(2),
                new Triangle(9),
                new Circle(2.75m),
                new Triangle(4.2m)
            };

            var summary = ReportGenerator.Print(shapes, new English());

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                summary);
        }

        /// <summary>
        /// Verifies that a report generated for a mixed list of shapes (Squares, Circles, Triangles) using the Spanish strategy 
        /// correctly groups, aggregates, and formats the output, handling decimal calculations properly based on the current culture.
        /// </summary>
        [TestCase]
        public void Print_MultipleShapeTypes_InSpanish_ReturnsCorrectSummary()
        {
            var shapes = new List<IGeometricShape>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square(2),
                new Triangle(9),
                new Circle(2.75m),
                new Triangle(4.2m)
            };

            var summary = ReportGenerator.Print(shapes, new Spanish());

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                summary);
        }

        /// <summary>
        /// Verifies that newly added geometric shapes (Rectangles, Trapezoids) are correctly processed, calculated, 
        /// and localized using the Italian strategy, proving the scalability of the open/closed design.
        /// </summary>
        [TestCase]
        public void Print_NewShapeTypes_InItalian_ReturnsCorrectSummary()
        {
            var shapes = new List<IGeometricShape>
            {
                new Rectangle(5, 2),
                new Trapezoid(10, 6, 3, 5, 3),
                new Rectangle(3, 4)
            };

            var summary = ReportGenerator.Print(shapes, new Italian());

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>2 Rettangoli | Area 22 | Perimetro 28 <br/>1 Trapezio | Area 24 | Perimetro 24 <br/>TOTALE:<br/>3 forme Perimetro 52 Area 46",
                summary);
        }
    }
}
