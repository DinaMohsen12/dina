using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairScript : MonoBehaviour
{
    Vector2 stairpos, targetpos;
    float randomX;
    float smoothtime = 0.1f;
    Vector2 velocity = Vector2.zero;
    
public  void changpos ()
    {
        targetpos = transform.position;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {

            randomX = -10;

        }
        else {
            randomX = 10;
        }
        stairpos = new Vector2(targetpos.x + randomX,targetpos.y);
        transform.position = stairpos;
    }
    void Update()
    {
        if (Vector2.Distance(targetpos, transform.position) > 0.01f) {

            movetotarget();
        }
    }
  private void movetotarget()
    {

      transform.position = Vector2.SmoothDamp(transform.position, targetpos, ref velocity, smoothtime);

    }
}
