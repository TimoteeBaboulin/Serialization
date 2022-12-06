using System;
using Script.Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceUI : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI _tmp;
    private Choice _choice;

    private string _Guid;

    public void Load(Choice choice){
        _choice = choice;
        _tmp.text = choice.Description;
        _Guid = choice.ThumbnailGuid;
    }
}
