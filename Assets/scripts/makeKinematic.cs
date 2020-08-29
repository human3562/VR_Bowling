using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeKinematic : MonoBehaviour
{
    public void makePinsKinematic()
    {
        foreach(pinGroup pg in GetComponentsInChildren<pinGroup>())
        {
            pg.makePinsKinematic();
        }
    }

    public void removePinsKinematic()
    {
        foreach (pinGroup pg in GetComponentsInChildren<pinGroup>())
        {
            pg.removeKinematic();
        }
    }

    public void removePins()
    {
        foreach (pinGroup pg in GetComponentsInChildren<pinGroup>())
        {
            pg.deletePins();
        }
    }

    public void straightenPins()
    {
        foreach (pinGroup pg in GetComponentsInChildren<pinGroup>())
        {
            pg.straighten();
        }
    }
}
