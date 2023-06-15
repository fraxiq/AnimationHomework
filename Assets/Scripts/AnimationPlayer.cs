using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animation Anim;
   
    public void PlayAnimation(bool playing)
    {
        Anim.Play();
        
    }
    public void StopAnimation(bool playing)
    {
        Anim.Stop();
    }
}
