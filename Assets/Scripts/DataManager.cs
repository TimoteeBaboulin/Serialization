using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using FullSerializer;
using Script.Data;

public class DataManager : MonoBehaviour{
    private static readonly fsSerializer _serializer = new fsSerializer();
    private static readonly string storyPath = Application.streamingAssetsPath;

    public static List<string> LoadStoryNames(){
        return Directory.GetFiles(storyPath, "*sty").Select(Path.GetFileName).ToList();
    }

    public static Story LoadStory(string storyName){
        string path = storyPath + Path.DirectorySeparatorChar + storyName;

        if (!File.Exists(path)) throw new NullReferenceException("Couldn't find the story file");
        string fullText = File.ReadAllText(path);

        return Deserialize(typeof(Story), fullText) as Story;
    }

    private static object Deserialize(Type type, string json){
        fsData data = fsJsonParser.Parse(json);

        object deserialized = null;
        _serializer.TryDeserialize(data, type, ref deserialized);
        return deserialized;
    }
}
