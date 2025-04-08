using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public TextMeshProUGUI levelText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        //transitionAnimation.SetTrigger("EndTransition");
        yield return new WaitForSeconds(2);

        // Add null check before using levelText
        if (levelText != null)
        {
            levelText.enabled = true;
            levelText.SetText("Level " + (SceneManager.GetActiveScene().buildIndex + 1));

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            yield return new WaitForSeconds(2);

            // Add null check again in case it was destroyed during scene loading
            if (levelText != null)
            {
                levelText.enabled = false;
            }
        }
        else
        {
            Debug.LogError("levelText is null! Make sure it's properly set and is a child of the persistent GameObject.");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //transitionAnimation.SetTrigger("StartTransition");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}