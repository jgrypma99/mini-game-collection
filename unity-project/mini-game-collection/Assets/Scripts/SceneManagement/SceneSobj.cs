using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameCollection.SceneManagement
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Scene ScriptableObject", menuName = "Scriptable Objects/Scene")]
    public sealed class SceneSobj : ScriptableObject
    {
        public SceneSobj() { }
        public SceneSobj(Scene scene)
        {
            SceneName = scene.name;
            BuildIndex = scene.buildIndex;
        }

        public static implicit operator string(SceneSobj sceneSobj)
        {
            return sceneSobj.ToString();
        }


#if UNITY_EDITOR
        /// <summary>
        ///     The UnityEditor.SceneAsset which this scriptable object takes information from.
        /// </summary>
        [field: SerializeField]
        public UnityEngine.Object SceneAsset { get; set; }
#endif

        /// <summary>
        ///     UnityEditor.SceneAsset name.
        /// </summary>
        [field: SerializeField]
        public string SceneName { get; set; }

        /// <summary>
        ///     UnityEditor.SceneAsset build index.
        /// </summary>
        /// <remarks>
        ///     DO NOT TRUST. Unity's scene management is unreliable and will likely return -1
        ///     even if the scene is in the build.
        /// </remarks>
        [field: SerializeField]
        public int BuildIndex { get; set; } = -1;

        /// <summary>
        ///     Returns the scene using sceneAsset's name since buildIndex is unreliable.
        /// </summary>
        public Scene Scene => SceneManager.GetSceneByName(SceneName);


        public override string ToString()
        {
            return SceneName;
        }
    }
}
