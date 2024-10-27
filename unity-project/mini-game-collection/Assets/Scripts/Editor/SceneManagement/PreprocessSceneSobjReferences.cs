using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameCollection.SceneManagement.Editor
{
    [InitializeOnLoad]
    internal sealed class PreprocessSceneSobjReferences :
        IPreprocessBuildWithReport,
        IOrderedCallback
    {
        private static string SearchQuery => string.Format($"t:{typeof(SceneSobj)}");
        int IOrderedCallback.callbackOrder => 1;


        [MenuItem("Tools/Process Scene ScriptableObject References")]
        internal static void OnPreprocessBuild()
        {
            string[] paths = AssetDatabase.FindAssets(SearchQuery);

            foreach (string guid in paths)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var sobjAsset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(SceneSobj)) as SceneSobj;

                var sobjExists = sobjAsset != null;
                var sobjHasSceneAsset = sobjExists ? sobjAsset?.SceneAsset != null : false;
                if (sobjExists && sobjHasSceneAsset)
                {
                    // Target
                    var sceneAsset = sobjAsset.SceneAsset;
                    var sceneName = sceneAsset.name;
                    var sceneBuildIndex = SceneManager.GetSceneByName(sceneName).buildIndex;
                    var sceneFileName = "scene-sobj-" + sceneName;

                    // Current
                    var sobjSceneName = sobjAsset.SceneName;
                    var sobjSceneBuildIndex = SceneManager.GetSceneByName(sobjSceneName).buildIndex;
                    var sobjFileName = sobjAsset.name;

                    bool doModifySobjAsset =
                        sobjSceneName != sceneName ||
                        sobjSceneBuildIndex != sceneBuildIndex ||
                        sobjFileName != sceneFileName;

                    if (doModifySobjAsset)
                    {
                        AssetDatabase.RenameAsset(assetPath, sceneFileName);
                        sobjAsset.SceneAsset = sceneAsset;
                        sobjAsset.SceneName = sceneName;
                        sobjAsset.BuildIndex = sceneBuildIndex;
                        EditorUtility.SetDirty(sobjAsset);
                        AssetDatabase.SaveAssets();
                    }
                }
                else
                {
                    if (sobjExists)
                        Debug.LogWarning($"File <i>{sobjAsset.name}</i> is missing a {nameof(SceneAsset)} reference!");
                }
            }
        }

        public void OnPreprocessBuild(BuildReport report)
        {
            OnPreprocessBuild();
        }

        // Source:
        // https://answers.unity.com/questions/447701/event-for-unity-editor-pause-and-playstop-events.html
        static PreprocessSceneSobjReferences()
        {
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        private static void OnPlayModeChanged(PlayModeStateChange modeState)
        {
            if (modeState == PlayModeStateChange.EnteredPlayMode)
            {
                OnPreprocessBuild();
            }
        }
    }
}