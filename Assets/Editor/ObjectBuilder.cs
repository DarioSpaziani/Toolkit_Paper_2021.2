using _01_Scripts;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(ObjectBuilderScript))]
    public class ObjectBuilder : EditorWindow
    {
        [MenuItem("Tools/SpawnerIMGUI")]
        public void OnInspectorGUI()
        {
            //     DrawDefaultInspector();
            //
            //
            //     if(Input.GetKeyDown(KeyCode.A))
            //     {
            //         myScript.BuildObject();
            //     }
        }
    }
}