using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GestureInput : MonoBehaviour
{
    public UnityEvent singleTap;
    public UnityEvent doubleTap;
    public UnityEvent tripleTap;
    public UnityEvent SlideUp;
    public UnityEvent SlideDown;
    public UnityEvent SlideL;
    public UnityEvent SlideR;

    private InputControl IC;
    //tap data
    [field : SerializeField] float tapInterval;
    [field : SerializeField] float tapFinishInterval;
    int tapCount;
    bool inFinishInterval;

    //gesture data
    [field: SerializeField] float minGestureDistance;
    public bool enable;
    void Awake()
    {
        IC = GetComponent<InputControl>();
        tapCount = 0;
        inFinishInterval = false;
        enable = false;
    }

    //Tap Functions
    public void OnTap()
    {
        if (tapCount == 0 && !inFinishInterval)
        {
            StartCoroutine("tapTimer1");
        }
        else if (tapCount == 1)
        {
            StopCoroutine("tapTimer1");
            StartCoroutine("tapTimer2");
        }
        else if (tapCount == 2)
        {
            StopCoroutine("tapTimer2");
            tap3();
        } 
    }
    IEnumerator tapTimer1()
    {
        tapCount++;
        yield return new WaitForSeconds(tapInterval);
        StartCoroutine(tapFinish());
        singleTap?.Invoke();
    }
    IEnumerator tapTimer2()
    {
        tapCount++;
        yield return new WaitForSeconds(tapInterval);
        StartCoroutine(tapFinish());
        doubleTap?.Invoke();
    }
    void tap3()
    {
        StartCoroutine(tapFinish());
        tripleTap?.Invoke();
    }
    IEnumerator tapFinish()
    {
        tapCount = 0;
        inFinishInterval = true;
        yield return new WaitForSeconds(tapFinishInterval);
        inFinishInterval = false;
    }

    //Gesture Functions
    public void onGestureFinish0()
    {
        if (!enable) return;
        if (IC.fingerRule[0] != 1) return;
        Vector3 difference = IC.fingerLocation[0] - IC.fingerStartLocation[0];
        if (difference.magnitude < minGestureDistance) return;
        if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
        {
            if(difference.x < 0)
            {
                SlideL?.Invoke();
            }
            else
            {
                SlideR?.Invoke();
            }
        }
        else if(Mathf.Abs(difference.x) < Mathf.Abs(difference.y))
        {
            if(difference.y < 0)
            {
                SlideDown?.Invoke();
            }
            else
            {
                SlideUp?.Invoke();
            }
        }
    }
    public void onGestureFinish1()
    {
        if (!enable) return;
        if (IC.fingerRule[1] != 1) return;
        Vector3 difference = IC.fingerLocation[1] - IC.fingerStartLocation[1];
        if (difference.magnitude < minGestureDistance) return;
        if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
        {
            if (difference.x < 0)
            {
                SlideL?.Invoke();
            }
            else 
            {
                SlideR?.Invoke();
            }
        }
        else if(Mathf.Abs(difference.x) < Mathf.Abs(difference.y))
        {
            if (difference.y < 0)
            {
                SlideDown?.Invoke();
            }
            else
            {
                SlideUp?.Invoke();
            }
        }
    }
}
