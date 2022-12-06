using System;

namespace Script.Data {
    [Serializable]
    public class Choice {

        public string Description;
        public string ThumbnailGuid;

        public Choice(string description, string thumbnailGuid) {
            Description = description;
            ThumbnailGuid = thumbnailGuid;
        }
        
    }
}