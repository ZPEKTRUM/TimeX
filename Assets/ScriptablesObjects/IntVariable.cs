using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new IntVariable", menuName = "Variables/Int Variable")]
public class IntVariable : ScriptableObject // change heritage to Scriptable Object
{
    #region Exposed
    public int m_value;
    #endregion
}


 

