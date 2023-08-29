using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    public Animation[] animations;
    
    // Start is called before the first frame update
    // IEnumerator QueueAnim(params AnimationClip[] anim)
    // {
    //     int index = 0;
    //     GetComponent<Animation>().clip = anim[index];
    //
    //     while (index < anim.Length)
    //     {
    //         GetComponent<Animation>().Play;
    //         yield return new WaitForSeconds(anim[index].length);
    //         index++;
    //         GetComponent<Animation>().clip = anim[index];
    //     }
    //
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
