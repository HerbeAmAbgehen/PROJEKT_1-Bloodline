using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrapArms : MonoBehaviour
{


    public IEnumerator ArmWaitTimer(bool ArmsWait, float StunTimer)
    {
        ArmsWait = true;
        yield return new WaitForSeconds(StunTimer);
        ArmsWait = false;
        yield return ArmsWait;
    }

}
