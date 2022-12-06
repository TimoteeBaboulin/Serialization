using Script.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailUI : MonoBehaviour{ 
    [SerializeField] private TextMeshProUGUI _storyText;
    [SerializeField] private GameObject _choiceContainer;
    [SerializeField] private StoryHandler _storyHandler;

    [SerializeField] private GameObject _choicePrefab;
    
    private Thumbnail _thumbnail;

    public void SetThumbnail(Thumbnail thumbnail){
        if (thumbnail == null) return;

        _thumbnail = thumbnail;
        _storyText.text = thumbnail.Description;
        foreach (Transform choices in _choiceContainer.transform){
            Destroy(choices.gameObject);
        }

        foreach (Choice choice in thumbnail.Choices){
            ChoiceUI newChoice = Instantiate(_choicePrefab, _choiceContainer.transform).GetComponent<ChoiceUI>();
            newChoice.Load(choice);
            newChoice.GetComponent<Button>().onClick.AddListener(() => {
                Thumbnail thumbnail = _storyHandler.GetThumbnail(choice.ThumbnailGuid);
                if (thumbnail == null) _storyHandler.EndStory();
                SetThumbnail(thumbnail);
            });
        }
    }

    public void ClearThumbnail(){
        _storyText.text = "";
        foreach (Transform choices in _choiceContainer.transform){
            Destroy(choices.gameObject);
        }

        _thumbnail = null;
    }
}
