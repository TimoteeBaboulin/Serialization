using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreenUI : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI _tmp;
    [SerializeField] private StoryHandler _storyHandler;

    private void OnEnable(){
        _tmp.text = "L'histoire " + _storyHandler.CurrentStoryName + " vient de prendre fin\nTu peut cliquer en bas à gauche afin de tenter une autre histoire.";
    }
}
