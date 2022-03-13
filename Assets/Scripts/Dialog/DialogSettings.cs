using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="Script Dialogo", menuName ="Criar Dialogo/Novo dialogo")]
public class DialogSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialog")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogs = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portugues;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSettings ds = (DialogSettings)target;
        Languages linguage = new Languages();
        linguage.portugues = ds.sentence;

        Sentences sentence = new Sentences();
        sentence.profile = ds.speakerSprite;
        sentence.sentence = linguage;

        if (GUILayout.Button("Create_Dialog"))
        {
            if (ds.sentence != "") 
            {
                ds.dialogs.Add(sentence);
                ds.speakerSprite = null;
                ds.sentence = "";
            } 
        }
    }
}

#endif
