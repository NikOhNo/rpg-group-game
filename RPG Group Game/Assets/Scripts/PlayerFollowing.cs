using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowing : MonoBehaviour
{

    [SerializeField] [Range(1,3)] int orderInParty;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (orderInParty == 0)
        {
            
        }
    }
}
