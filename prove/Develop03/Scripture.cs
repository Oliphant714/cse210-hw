using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ScriptureApp
{
    public class Scripture
    {
        private Reference _reference;
        private List<string> _words;
        private List<bool> _hiddenWords;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').ToList();
            _hiddenWords = new List<bool>(_words.Count);
            for (int i = 0; i < _words.Count; i++)
            {
                _hiddenWords.Add(false);
            }
        }

        public static Scripture LoadFromJson(string filePath)
        {
            var scriptures = JsonConvert.DeserializeObject<List<ScriptureJson>>(File.ReadAllText(filePath));
            var scripture = scriptures[0];  // Choose the first scripture (or handle logic to select)
            var reference = new Reference(scripture.Book, scripture.StartVerse, scripture.EndVerse);
            return new Scripture(reference, scripture.Text);
        }

        public string GetDisplayText()
        {
            string referenceText = _reference.GetFormattedReference();
            string wordsText = string.Join(" ", _words.Select((word, index) => _hiddenWords[index] ? "_____" : word));
            return $"{referenceText}\n{wordsText}";
        }

        public void HideRandomWord()
        {
            var visibleWordIndices = _hiddenWords
                .Select((isHidden, index) => new { isHidden, index })
                .Where(x => !x.isHidden)
                .Select(x => x.index)
                .ToList();

            if (visibleWordIndices.Count == 0) return;

            int index = visibleWordIndices[_random.Next(visibleWordIndices.Count)];
            _hiddenWords[index] = true;
        }

        public bool IsCompletelyHidden()
        {
            return _hiddenWords.All(isHidden => isHidden);
        }
    }
}
