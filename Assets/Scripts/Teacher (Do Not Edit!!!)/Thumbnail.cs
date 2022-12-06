using System;
using System.Collections.Generic;

namespace Script.Data {
    [Serializable]
    public class Thumbnail {

        public string Guid;
        public string Title;
        public string Description;
        public List<Choice> Choices;

    }
}