using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneHandler : MonoBehaviour
{
    [SerializeField] Animator blackScreenAnimator;

    public void closeCutscene()
    {
        blackScreenAnimator.SetBool("cutscene", true);
    }


}
