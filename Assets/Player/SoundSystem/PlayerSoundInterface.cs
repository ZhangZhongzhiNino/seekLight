using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSoundInterface : MonoBehaviour,IMakeSound
{
    [field:SerializeField]List<Collider2D> collisions;
    void IMakeSound.makeSound()
    {
        tryMakeSound();
    }

    public void tryMakeSound()
    {
        if (collisions.Count == 0) return;
        foreach (Collider2D c in collisions)
        {
            IHearSound HearSoundInterface = c.GetComponent<IHearSound>();
            if (HearSoundInterface == null) continue;
            if (HearSoundInterface.wakeUp) continue;
            HearSoundInterface.hearSound();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        collisions = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != Tags.Enemy.ToString()) return;
        if (!collisions.Contains(collision)) collisions.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != Tags.Enemy.ToString()) return;
        if (collisions.Contains(collision)) collisions.Remove(collision);
    }
}
