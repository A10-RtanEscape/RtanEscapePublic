using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfoSO", menuName = "PlayerInfoData", order = 0)]
[Serializable]
public class PlayerInfo : ScriptableObject
{
    public Sprite sprite;
    public RuntimeAnimatorController animator;
}
