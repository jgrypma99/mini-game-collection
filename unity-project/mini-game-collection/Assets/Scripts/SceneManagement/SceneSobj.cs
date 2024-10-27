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

        public override string ToString()
        {
            return SceneName;
        }
    }
}
