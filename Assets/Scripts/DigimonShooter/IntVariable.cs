using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
    public int Value;

    private void OnEnable()
    {
        Value = 0;
    }
}
