using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ScriptureApp
{
    public class ScriptureJson
    {
        public string Book { get; set; }
        public int StartVerse { get; set; }
        public int EndVerse { get; set; }
        public string Text { get; set; }
    }
}