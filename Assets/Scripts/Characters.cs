using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Characters : ScriptableObject, ISerializationCallbackReceiver
{
    public string cName;
    public string description;
    public TextAsset inkFile;
    public bool combine;
    public List<Item> list;

    public bool aktiv;

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        
    }
}
