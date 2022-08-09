using UnityEngine;
using UnityEngine.SceneManagement;

public class portalSwitchScene : MonoBehaviour {

    public string toWhichScene;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            switchScene(toWhichScene);
    }

    private void switchScene(string toWhichScene) {
        SceneManager.LoadSceneAsync(toWhichScene);
        Debug.Log(toWhichScene);
    }
}