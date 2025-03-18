using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//关联所有的方块
public class Walkable : MonoBehaviour
{
    
    //创建possiblePaths的list来储存gamepath的变量
    public List<WalkPath> possiblePaths = new List<WalkPath>();

    [Space]

    public Transform previousBlock;

    [Space]
 
    [Header("Booleans")]
    public bool isStair = false;
    public bool movingGround = false;
    public bool isButton;
    public bool dontRotate;

    [Space]

    [Header("Offsets")]
    public float walkPointOffset = .5f;
    public float stairOffset = .4f;
    //利用位移变量去确定玩家路径点
    public Vector3 GetWalkPoint()
    {
        float stair = isStair ? stairOffset : 0;
        return transform.position + transform.up * walkPointOffset - transform.up * stair;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        float stair = isStair ? .4f : 0;
        Gizmos.DrawSphere(GetWalkPoint(), .1f);

        if (possiblePaths == null)
            return;

        foreach (WalkPath p in possiblePaths)
        {
            if (p.target == null)
                return;
            Gizmos.color = p.active ? Color.black : Color.clear;
            Gizmos.DrawLine(GetWalkPoint(), p.target.GetComponent<Walkable>().GetWalkPoint());
        }
    }
}

[System.Serializable]


public class WalkPath
{
    public Transform target;
    public bool active = true;
}
