using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MissionManagerWindow : EditorWindow {


    [MenuItem("Tools/Mission Editor")]
    static void Open() {
        GetWindow<MissionManagerWindow>();
    }

    public Transform missionRoot;

    private void OnGUI()
    {

        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("missionRoot"));

        if (missionRoot == null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }

    //buttons to do stuff in the window
    void DrawButtons() {

        if (GUILayout.Button("Create a Different Type Mission"))
        {
            CreateMission();
        }
        if (GUILayout.Button("Car Chase"))
        {
            CarChase();
        }
        if (GUILayout.Button("Delivery"))
        {
            Delivery();
        }
        if (GUILayout.Button("Tail A Car"))
        {
            Tail();
        }
    }

    //Setup a custom mission
    void CreateMission() {

        GameObject MissionObjective = new GameObject("Mission " + missionRoot.childCount, typeof(MissionManager));
        MissionObjective.transform.SetParent(missionRoot, false);
        MissionManager mission = MissionObjective.GetComponent<MissionManager>();
        Selection.activeGameObject = mission.gameObject;
    }

    //what to do if the user wants a delivery mission
    //Should be done
    void Delivery() {

        //create a mission object
        GameObject MissionObjective = new GameObject("Delivery Mission " + missionRoot.childCount, typeof(MissionManager));
        MissionObjective.transform.SetParent(missionRoot, false);
        MissionManager mission = MissionObjective.GetComponent<MissionManager>();
        Selection.activeGameObject = mission.gameObject;

        //creating the end position object
        GameObject positionToGetTo = new GameObject("PositionToGetTo " + MissionObjective.transform.childCount, typeof(DeliveryEnd));
        positionToGetTo.transform.SetParent(MissionObjective.transform, false);
        //sets a trigger box on the empty end pos
        positionToGetTo.AddComponent<BoxCollider>().isTrigger = true;

        //creating the Mission Giver object
        GameObject missionGiver = new GameObject("Mission Giver Delivery " + MissionObjective.transform.childCount, typeof(MissionGiver));
        missionGiver.transform.SetParent(MissionObjective.transform, false);
        //sets a trigger box on the empty end pos
        missionGiver.AddComponent<BoxCollider>().isTrigger = true;

        //sets the mission type
        mission.missionType("Delivery");
        //set the mission end position
        mission.endPos = positionToGetTo;

    }

    //what to do if it is a tailing mission
    void Tail()
    {

        //create a mission object
        GameObject MissionObjective = new GameObject("Tailing Mission " + missionRoot.childCount, typeof(MissionManager));
        MissionObjective.transform.SetParent(missionRoot, false);
        MissionManager mission = MissionObjective.GetComponent<MissionManager>();
        Selection.activeGameObject = mission.gameObject;


        //creating the Tailing Car StartPos Object
        GameObject positionToGetTo = new GameObject("Tailing Car Goes Here " + MissionObjective.transform.childCount);
        positionToGetTo.transform.SetParent(MissionObjective.transform, false);

        //creating the Mission Giver object
        GameObject missionGiver = new GameObject("Mission Giver Tailing " + MissionObjective.transform.childCount, typeof(MissionGiver));
        missionGiver.transform.SetParent(MissionObjective.transform, false);
        //sets a trigger box on the empty end pos
        missionGiver.AddComponent<BoxCollider>().isTrigger = true;

        //sets the mission type
        mission.missionType("Tail a Car");
    }

    //what to do if the user wants a car Chase mission
    void CarChase() {

        //create a mission object
        GameObject MissionObjective = new GameObject("Car Chase Mission " + missionRoot.childCount, typeof(MissionManager));
        MissionObjective.transform.SetParent(missionRoot, false);
        MissionManager mission = MissionObjective.GetComponent<MissionManager>();
        Selection.activeGameObject = mission.gameObject;

        //creating the Mission Giver object
        GameObject missionGiver = new GameObject("Mission Giver Car Chase " + MissionObjective.transform.childCount, typeof(MissionGiver));
        missionGiver.transform.SetParent(MissionObjective.transform, false);
        //sets a trigger box on the empty end pos
        missionGiver.AddComponent<BoxCollider>().isTrigger = true;

        //sets the mission type
        mission.missionType("CarChase");
    }
}
