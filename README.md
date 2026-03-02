# 🚀 Development Challenge - Refactorización de Código

Este repositorio contiene la solución a la prueba técnica de refactorización de la clase FormaGeometrica. El objetivo principal fue transformar un código legacy (una "God Class" con alta dependencia algorítmica y condicional) en una arquitectura limpia, escalable y mantenible, aplicando buenas prácticas de clean code y programación orientada a objetos (POO).

## 🎯 Objetivos Cumplidos
[x] Refactorización completa aplicando buenas prácticas.

[x] Implementación de nuevas formas geométricas (Rectángulo, Trapecio).

[x] Incorporación de un nuevo idioma (Italiano).

[x] Corrección de bugs lógicos del código original.

[x] Tests unitarios actualizados y ampliados (100% Passing).

## 🏛️ Decisiones Arquitectónicas y Patrones de Diseño
El código original presentaba violaciones claras a los principios SOLID, centralizando cálculos matemáticos, traducciones y formateo HTML en un solo método y basando su lógica en estructuras switch/if anidadas.

Para resolver esto, se aplicaron los siguientes principios y patrones:

### 1. Principio de Responsabilidad Única (SRP)
Se eliminó la "God Class" delegando las responsabilidades a donde corresponden:
- **Las formas (`IGeometricShape`)**: Solo saben calcular su propia área y perímetro.
- **Los idiomas (`ILanguage`)**: Solo saben de diccionarios, traducciones, pluralización y reglas de formato.
- **El reporteador (`ReportGenerator`)**: Solo se encarga de iterar, agrupar y orquestar la construcción del StringBuilder, sin importar qué formas o idiomas reciba.

### 2. Principio Abierto/Cerrado (OCP) y Strategy Pattern
- **Polimorfismo en Formas**: En lugar de constantes enteras (Cuadrado = 1), se creó la interfaz IGeometricShape. Agregar una forma nueva (ej. Pentagono) ahora solo requiere crear una nueva clase, sin modificar el código existente.
- **Polimorfismo en Idiomas**: Se creó la abstracción ILanguage. Los idiomas ya no dependen de un parámetro int idioma, sino de estrategias inyectadas (ej. new Spanish()).
- **Traducciones**: En lugar de usar switch o if para obtener los nombres de las formas, se implementó un Dictionary<Type, string[]> en cada idioma. Esto elimina la complejidad ciclomática y prepara la clase para que, en un futuro, los textos puedan provenir de una base de datos o un archivo .resx.

### 3. Principio DRY (Don't Repeat Yourself)
Para evitar la duplicación del algoritmo de búsqueda de traducciones en cada idioma, se implementó una clase abstracta base LanguageBase que implementa ILanguage. Las clases concretas (Spanish, English, Italian) solo sobreescriben los diccionarios y propiedades, heredando la lógica común del método ShapeName.

## ✨ Mejoras Técnicas Destacadas
- **Modelado real de geometría**: El código original forzaba a todas las figuras a recibir un único parámetro `_lado`. La refactorización permite que cada figura reciba en su constructor los parámetros exactos que necesita. Por ejemplo, el `Trapezoid` ahora recibe sus 5 dimensiones (bases, altura y lados) para calcular un perímetro real, y el `Rectangle` recibe su base y altura.
- **Manejo de Edge Cases (Bugs resueltos)**: Se corrigió un bug del código original donde el Footer del reporte imprimía plurales incorrectos si solo había una forma en toda la lista (ej. imprimía "1 formas"). Ahora evalúa correctamente la cardinalidad total para imprimir "1 forma" o "N formas".
- **LINQ para agrupación**: Se reemplazó la iteración manual y los contadores aislados por un GroupBy(shape => shape.GetType()). Esto agrupa naturalmente las formas, manteniendo el código del generador limpio y extensible a N formas.

## 🧪 Testing
Los tests unitarios se reescribieron utilizando **NUnit** para reflejar la nueva arquitectura y garantizar que las salidas del reporteador sean idénticas a los requerimientos originales del negocio.
- Se agregaron nuevos casos de prueba para validar el comportamiento del Rectángulo, Trapecio y el idioma Italiano.
- Configuración de Cultura: Se fijó la cultura en los tests (`es-AR`) mediante el `[SetUp]` para garantizar que el separador decimal (coma ,) sea predecible sin importar en qué entorno o servidor de CI/CD se ejecuten las pruebas.

### 🛠️ ¿Cómo ejecutar las pruebas?
El proyecto utiliza .NET Framework 4.6.2. Para correr las pruebas en Visual Studio:
- Recompilar la solución (Rebuild Solution).
- Asegurarse de tener instalado el paquete NuGet NUnit3TestAdapter en el proyecto de tests.
- Abrir el Test Explorer y ejecutar todas las pruebas (Run All).

(dejo esta aclaración ya que cuando me descargué el proyecto el visual studio no me reconocía los tests)
