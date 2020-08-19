# C# Text To IPA 

This library is a text to IPA converter written in C#. It comes included with a core dictionary which was provided from [CMU-IPA](http://people.umass.edu/nconstan/CMU-IPA/). A simple lookup and replacement mechanism is used to replace known words with their IPA equivalents. 

## Usage
```cs
var converter = new Qkmaxware.Phonetics.IPA();
var text = converter.EnglishToIPA("This is some English Text");
```

