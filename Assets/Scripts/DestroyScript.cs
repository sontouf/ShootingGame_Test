using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        //delay = 2.5f;
        Destroy(gameObject, delay);
    }
}
