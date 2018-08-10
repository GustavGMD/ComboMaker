using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Gameplay/Attack", order = 0)]
public class AttackPattern : ScriptableObject
{
    public Vector2Int[] hitPositions;
}
