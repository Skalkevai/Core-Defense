using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionMobile : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Screen.width > 1920)
        {
            Screen.SetResolution(1920,1080,true);
        }
    }
}
