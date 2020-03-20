using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject stairpref;
    int index;
    [SerializeField]
    float stairWidht = 2f, stairHeight = 1f;
    [SerializeField]
    int MaxX=5, MiniX = -5;
    public static StairSpawner instance = null;
    List<GameObject> stairlist = new List<GameObject>();
    float hue;
    void Start()
    {
        if (instance == null)
            instance = this;
        makeobject();
        inIColor();
        for (int i = 0; i < 5; i++)
        {
            Makestair();
        }
    }

    void inIColor() {
        hue = UnityEngine.Random.Range(0f, 1f);
        Camera.main.backgroundColor = Color.HSVToRGB(hue,0.6f,0.8f);
    }
   void makeobject(){
        for (int i = 0; i < 5; i++) {
            GameObject stair = Instantiate(stairpref);
            stair.SetActive(false);
            stairlist.Add(stair);
                }
    }
    GameObject getstair() {
        GameObject obj = null;
        for (int i=0;i<stairlist.Count;i++) {
            if (!stairlist[i].activeInHierarchy) {
                obj = stairlist[i] ;
                return obj;
            }
        
        }
        return null;
    }

  public  void Makestair() {
        int randomposX;
        if (index == 0)
            randomposX = 0;
        else
            randomposX =UnityEngine.Random.Range(MiniX,MaxX);
        Vector2 newpos = new Vector2(randomposX,index *5);
        GameObject stair = getstair();
        if (stair == null)
            return;
        stair.SetActive(true);
        stair.transform.position=newpos;
        stair.transform.rotation = Quaternion.identity;
        stair.transform.localScale = new Vector2(stairWidht, stairHeight);
        stair.transform.SetParent(transform);
        stair.GetComponent<StairScript>().changpos();
        setcolor(stair);
        decreaseWidth();
        index++;
    }
    void decreaseWidth() {
        stairWidht -= 0.01f;
        if (stairWidht < 1)
            stairWidht = 1f;
    }
    void setcolor(GameObject stair) {
        if (UnityEngine.Random.Range(0,3)!=0) {
            hue += 0.11f;
            if (hue >= 1) { hue -= 1f; }
        
        }
        stair.GetComponent<SpriteRenderer>().color=Color.HSVToRGB(hue,0.6f,0.8f);
    }
    
}
