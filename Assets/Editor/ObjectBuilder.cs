using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectBuilderScript))]
public class ObjectBuilder : EditorWindow
{
    [MenuItem("Tools/SpawnerIMGUI")]
     public  void OnInspectorGUI()
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