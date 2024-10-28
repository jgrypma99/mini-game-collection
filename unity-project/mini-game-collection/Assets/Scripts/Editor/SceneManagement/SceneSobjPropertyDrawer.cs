using UnityEngine;
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
            sobj.SceneName = sceneAsset == null ? "" : sceneAsset.name;

            // Read-only view
            GUI.enabled = false;
            EditorGUILayout.TextField("Scene Name", sobj.SceneName);
            GUI.enabled = true;

            // Save changes
            serializedObject.ApplyModifiedProperties();
        }
    }
}