using UnityEngine;

namespace MiniGameCollection.SceneManagement
{
    public class DontDestroyOnLoadTag : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
        }

    }
}
