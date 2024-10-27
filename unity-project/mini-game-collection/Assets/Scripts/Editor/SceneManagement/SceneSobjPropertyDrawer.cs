using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace MiniGameCollection.SceneManagement.Editor
{
    [CustomEditor(typeof(SceneSobj))]
    internal sealed class SceneSobjPropertyDrawer : UnityEditor.Editor
    {
        private readonly Color errorColor = new Color(1f, .6f, .6f);

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SceneSobj sobj = target as SceneSobj;

            // Display scene field
            Color guiColor = GUI.color;
            GUI.color = sobj.SceneAsset == null ? errorColor : guiColor;
            sobj.SceneAsset = EditorGUILayout.ObjectField("Scene", sobj.SceneAsset, typeof(SceneAsset), false) as SceneAsset;
            GUI.color = guiColor;

            // Set scriptable object values based on SceneAsset values
            SceneAsset sceneAsset = sobj.SceneAsset as SceneAsset;
            if (sceneAsset != null)
            {
                sobj.SceneName = sceneAsset.name;
                sobj.BuildIndex = SceneManager.GetSceneByName(sceneAsset.name).buildIndex;
            }
            else
            {
                sobj.SceneName = "";
                sobj.BuildIndex = -1;
            }

            //// Get the property
            //SceneAsset sceneAsset = sobj.SceneAsset as SceneAsset;
            //string sceneName = sceneAsset == null ? "" : sceneAsset.name;
            //int buildIndex = sceneAsset == null ? -1 : SceneManager.GetSceneByName(sceneName).buildIndex;

            //// Read-only view
            GUI.enabled = false;
            //EditorGUILayout.Separator();
            //EditorGUILayout.LabelField("Scene Asset", EditorStyles.boldLabel);
            //EditorGUILayout.TextField("Scene Name", sceneName);
            //EditorGUILayout.IntField("Build Index", buildIndex);
            EditorGUILayout.Separator();
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("ScriptableObject Cache", EditorStyles.boldLabel);
            EditorGUILayout.TextField("Scene Name", sobj.SceneName);
            EditorGUILayout.IntField("Build Index", sobj.BuildIndex);
            GUI.enabled = true;

            // Save changes
            serializedObject.ApplyModifiedProperties();
        }
    }
}