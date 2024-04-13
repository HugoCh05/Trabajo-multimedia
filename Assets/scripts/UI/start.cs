using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startButtonClicked);
    }

    private void startButtonClicked()
    {
        SceneManager.LoadScene("level1");
    }
}
