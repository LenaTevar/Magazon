using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parcel
{
    public int success;
    public int broken;
    public int lost = -1;
    public float delay;
    public float breakChance;

    public Parcel(int deliverSuccedPoints,
        int deliverBokenPoints,
        float delayToDestroyParcel,
        float probabilityBreakParcel)
    {
        success = deliverSuccedPoints;
        broken = deliverBokenPoints;
        delay = delayToDestroyParcel;
        breakChance = probabilityBreakParcel;

        if (lost > 0)
            Debug.Log("Debug: Lost points in parcel should be negative");
    }

    public bool getsDelivered()
    {
        if (Random.value > breakChance)
            return false;
        return true;
    }


}