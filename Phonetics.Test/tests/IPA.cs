using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Qkmaxware.Phonetics.Test {
    [TestClass]
    public class TestIPA {
        [TestMethod]
        public void TestWord() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var converter = new IPA(); // Default dictionary
            var text = converter.EnglishToIPA("Colin");
            Assert.AreEqual("kowˈlɪn", text);
        }
        [TestMethod]
        public void TestPhrase() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var phrase = "Colin, I am hungry!";
            var ipa = "kowˈlɪn, ajˈ æˈm hʌˈŋgɹi!";

            var converter = new IPA();
            var converted = converter.EnglishToIPA(phrase);
            Assert.AreEqual(ipa.Length, converted.Length);
            for (var i = 0; i < ipa.Length; i++) {
                var charA = ipa[i];
                var charB = converted[i];
                Assert.AreEqual(charA, charB);
            }
        }
    }
}
