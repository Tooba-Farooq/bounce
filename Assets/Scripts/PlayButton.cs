using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] string scenetoLoad;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }
    
    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(scenetoLoad);
    }

}
