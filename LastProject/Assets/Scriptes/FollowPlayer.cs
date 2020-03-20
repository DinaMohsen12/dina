using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    public float smoothtime = 0.3f;
    Vector2 velocity = Vector2.zero;
    public float yoffset;
 
    void Update()
    {
        Vector2 targetpos = target.transform.TransformPoint(new Vector2(0,yoffset));
        if (targetpos.y < transform.position.y)
            return;
        targetpos = new Vector2(0,targetpos.y);
        transform.position = Vector2.SmoothDamp(transform.position, targetpos, ref velocity, smoothtime);
        transform.position = new Vector3(transform.position.x,transform.position.y,-10);
    }
}
