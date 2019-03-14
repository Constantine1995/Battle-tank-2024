using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {

	void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
            FindObjectOfType<GameController>().isPlayerAlive = true;
        });
    }
}
