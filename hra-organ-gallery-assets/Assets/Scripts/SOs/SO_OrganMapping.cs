using Assets.Scripts.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName = "OrganMapping")]
public class SO_OrganMapping : ScriptableObject
{
    public List<Mapping> mappingList = new List<Mapping>();
}

[Serializable]
public class Mapping
{
    public OrganMapping organMapping;
    public Transform[] organList  = new Transform[1];
}
