using GameMechanics;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelTuner))]
public class LevelTunerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelTuner levelTuner = (LevelTuner) target;
        if (GUILayout.Button("Tune level data"))
        {
            levelTuner.TryTuneLevelData();
        }
    }
}
