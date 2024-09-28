using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Serializable] 
public class ItemSO : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Sprite;
    public ItemType Type;
    public int StatChangeValue;
}
