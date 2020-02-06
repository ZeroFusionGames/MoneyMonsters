using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AI Type",menuName = "AI/AI Systems/AI Type")]
public class AiType : ScriptableObject
{
    public float patrolSpeed;
    public float chaseSpeed;
    public float attackSpeed;
    public float viewRadius;
    public float attackDistance;
}
