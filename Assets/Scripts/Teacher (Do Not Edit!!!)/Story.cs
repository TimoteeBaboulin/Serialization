using System;
using System.Collections.Generic;

namespace Script.Data {
    [Serializable]
    public class Story {
        
        public string StoryName;
        public List<Thumbnail> Thumbnails;

        public Story(string storyName) {
            StoryName = storyName;
            Thumbnails = new List<Thumbnail>();
        }
        
    }
}
