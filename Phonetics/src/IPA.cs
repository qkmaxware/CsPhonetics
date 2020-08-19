using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Qkmaxware.Phonetics {
    public class IPA {
    
        private Dictionary<string, string> dictionary;

        public IPA () {
            this.dictionary = new Dictionary<string, string>();
            var assembly = typeof(IPA).Assembly;
            var resource = assembly.GetName().Name + ".data.CMU.in.IPA.txt";

            using(var stream = assembly.GetManifestResourceStream(resource)) 
            using(var reader = new StreamReader(stream)) {
                string line = null;
                while ((line = reader.ReadLine()) != null) {
                    var parts = line.Split(',', 2);
                    if (parts.Length == 2)
                        dictionary[parts[0].Trim()] = parts[1].Trim();
                }
            }
            
        }

        public IPA (Dictionary<string, string> dictionary) {
            this.dictionary = dictionary;
        }

        public string EnglishToIPA(string text) {
            var builder = new StringBuilder();
            string[] words = Regex.Split(text, @"([\s\p{P}])"); // Split on spaces or punctuation

            foreach (var match in words) {
                var lower = match.ToLower();
                if (dictionary.ContainsKey(lower)) {
                    builder.Append(dictionary[lower]);
                } else {
                    builder.Append(lower);
                }
            }
            return builder.ToString();
        }

    }
}
