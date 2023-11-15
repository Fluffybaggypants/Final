using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public List<Vector3> Path;
    public int Index;
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Path[Index], Speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Path[Index]) < 0.01f)
        {
            Index++;
            if (Index >= Path.Count)
            {
                Index = 0;
            }
        }
    }
}
