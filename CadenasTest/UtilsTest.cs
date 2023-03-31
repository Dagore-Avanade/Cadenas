using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cadenas;

namespace CadenasTest
{
    [TestClass]
    public class UtilsTest
    {
        private static readonly string input = "Esto es un texto lo bastante largo como que pueda reemplazar parte del texto.";

        [TestMethod]
        public void MinLengthOfFortyBaseCase()
        {
            Assert.IsTrue(Utils.IsFortyCharactersLong(new string('a', 40)));
            Assert.IsFalse(Utils.IsFortyCharactersLong("ª"));
        }
        [TestMethod]
        public void ThrowsNullReferenceOnNullString()
        {
            Assert.ThrowsException<NullReferenceException>(() => Utils.IsFortyCharactersLong(null));
        }
        [TestMethod]
        public void ReplaceFromBaseCase()
        {
            string replaceInput = "texto bloque";
            string expected = "Esto es un bloque lo bastante largo como que pueda reemplazar parte del bloque.";
            string actual = Utils.ReplaceFrom(input, replaceInput);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ThrowsOnNoSpaceInReplaceInput()
        {
            string replaceInput = "texto,bloque";
            Assert.ThrowsException<IndexOutOfRangeException>(() => Utils.ReplaceFrom(input, replaceInput));
        }
        [TestMethod]
        public void ReplaceFromSeveralSpaces()
        {
            string replaceInput = "texto    bloque";
            string expected = "Esto es un bloque lo bastante largo como que pueda reemplazar parte del bloque.";
            string actual = Utils.ReplaceFrom(input, replaceInput);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FindBaseCase()
        {
            string searchToSuccess = "texto";
            string expectedSuccess = "En el índice 11 de la cadena introducida hay una coincidencia: \"texto lo bastante largo como que pueda reemplazar parte del texto.\".";
            Assert.AreEqual(expectedSuccess, Utils.Find(input, searchToSuccess));
            string searchToFail = "patata";
            string expectedFailure = "No hay coincidencias.";
            Assert.AreEqual(expectedFailure, Utils.Find(input, searchToFail));
        }
        [TestMethod]
        public void FindEmptyStringReturnsNoCoincidence()
        {
            string expected = "No hay coincidencias.";
            Assert.AreEqual(expected, Utils.Find(input, ""));
        }
        [TestMethod]
        public void StartWithBaseCase()
        {
            string searchToSuccess = "Esto ";
            string expectedSuccess = "La cadena proporcionada empieza por \"Esto \".";
            Assert.AreEqual(expectedSuccess, Utils.StartWith(input, searchToSuccess));
            string searchToFail = "texto";
            string expectedFailure = "No hay coincidencias.";
            Assert.AreEqual(expectedFailure, Utils.StartWith(input, searchToFail));
        }
        [TestMethod]
        public void StartWithEmptyStringReturnsNoCoincidence()
        {
            string expected = "No hay coincidencias.";
            Assert.AreEqual(expected, Utils.StartWith(input, ""));
        }
        [TestMethod]
        public void ZeroFillBaseCase()
        {
            string expectedSuccess = "000000000001";
            string actualSuccess = Utils.ZeroFill("1");
            Assert.AreEqual(expectedSuccess, actualSuccess);
            string expectedFailure = "Esta operación solo está disponible para números enteros.";
            Assert.AreEqual(expectedFailure, Utils.ZeroFill("patata"));
        }
    }
}
