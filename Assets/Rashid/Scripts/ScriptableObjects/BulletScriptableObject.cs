using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptable", menuName = "ScriptableObjects/BulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public float Speed;
    public float Damage;
    public AudioClip HitSound;
    public GameObject HitEffect;
}
