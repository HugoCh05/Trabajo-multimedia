using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class credits : MonoBehaviour
{
    public Button creditsButton;

    // Start is called before the first frame update
    void Start()
    {
        creditsButton.onClick.AddListener(creditsButtonClicked);
    }

    private void creditsButtonClicked()
    {
        SceneManager.LoadScene("creditos");
    }
}
