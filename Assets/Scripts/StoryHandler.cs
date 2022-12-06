using System;
using System.Collections;
using System.Collections.Generic;
using Script.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryHandler : MonoBehaviour{
    [SerializeField] private ThumbnailUI _thumbnailUI;
    [SerializeField] private GameObject _buttonPrefab;

    [SerializeField] private GameObject _victoryScreen;

    private Story _currentStory;
    public string CurrentStoryName => _currentStory.StoryName;

    private void Start(){
        List<string> storyNames = DataManager.LoadStoryNames();

        foreach (string storyName in storyNames){
            Button button = Instantiate(_buttonPrefab, transform).GetComponent<Button>();
            button.onClick.AddListener(() => {
                LoadStory(storyName);
            });
            button.GetComponentInChildren<TextMeshProUGUI>().text = storyName.Remove(storyName.Length - 4, 4);
        }
    }

    private void OnEnable(){
        _thumbnailUI.ClearThumbnail();
    }

    public Thumbnail GetThumbnail(string guid){
        foreach (var thumbnail in _currentStory.Thumbnails){
            if (thumbnail.Guid == guid) return thumbnail;
        }
        
        return null;
    }

    public void EndStory(){
        _victoryScreen.SetActive(true);
        gameObject.SetActive(true);
    }
    
    private void LoadStory(string name){
        Story story = DataManager.LoadStory(name);
        _currentStory = story;
        
        _thumbnailUI.SetThumbnail(story.Thumbnails[0]);
        gameObject.SetActive(false);
    }
}
