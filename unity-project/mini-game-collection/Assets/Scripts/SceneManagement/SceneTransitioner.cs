using MiniGameCollection.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    [field: SerializeField]
    public SceneSobj Scene { get; private set; }

    /// <summary>
    ///     Try to load scene.
    /// </summary>
    /// <returns>
    ///     True if scene can be loaded, false otherwise.
    /// </returns>
    public bool TryLoadScene()
    {
        if (Scene == null)
        {
            Debug.LogWarning($"{nameof(SceneTransitioner)}.{nameof(Scene)} not assigned to object {name}.");
            return false;
        }

        SceneManager.LoadScene(Scene);
        return true;
    }

    /// <summary>
    ///     Load scene.
    /// </summary>
    public void LoadScene()
        => TryLoadScene();
}
