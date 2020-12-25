using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
        DestroyObjectOnClick();
    }

    void DestroyObjectOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.CompareTag("CanBePickedUp") == true)
            {
                Destroy(gameObject);
            }

        }
    }
}