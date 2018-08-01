using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("SortChild")]
    public void sortChild()
    {
        float posititititi = -7.5f;

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 Pos = transform.GetChild(i).localPosition;
            Pos.x = posititititi;
            transform.GetChild(i).localPosition = Pos;

            posititititi += 2;

        }
    }
}
