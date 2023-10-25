using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunState", menuName = "ScriptableQuit/GunState")]
public class GunState : ScriptableObject
{
    internal static int fire;
    internal static int fireInitial;
    [SerializeField] float _rate;
    [SerializeField] float _power;
    [SerializeField] GameObject _prefab;

    public float Rate { get => _rate; }
    public float Power { get => _power; }
    public GameObject Prefab { get => _prefab; }
}