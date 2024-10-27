using UnityEngine;
using UnityEngine.SceneManagement;


namespace MiniGameCollection.SceneManagement
{
    public class BootstrapSceneLoader : MonoBehaviour
    {
        [field: SerializeField] public SceneSobj Scene;

        void LateUpdate()
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
