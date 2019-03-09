using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Himani Raval
 * 104874756
 */

public class AudioManager : MonoBehaviour //manages all audio 
{
    public AudioSource blah; //variable names and I don't get along
    public AudioClip cardclick, match, unmatched, winner, Lost;
    public static AudioManager instance; //to make it accessible everywhere
    public float stopseconds; //for defeat sound, its a song, i wanted to manage it here

    public void Awake()
    {
        instance = this;
    }

    public void MatchedCard()
    {
        Debug.Log("Matched"); //debugging puposes
        blah.PlayOneShot(match);
    }

    public void UnMatchedCard()
    {
        Debug.Log("UnMatched");
        //debugging puposes
        blah.PlayOneShot(unmatched);
    }

    public void ClickedCard()
    {
        Debug.Log("Clicked");
        //debugging puposes
        blah.PlayOneShot(cardclick);
    }

    public void Won()
    {
        Debug.Log("Won"); //debugging puposes
        blah.clip = winner;
        /* blah.time = 45;
         blah.Play();
         StartCoroutine(stopsound());*/
        blah.PlayOneShot(winner);
    }

    public void Defeated()
    {
        Debug.Log("Lost"); //debugging puposes
        blah.clip = Lost; //set clip
        blah.time = 1; //star time at 1 second
        blah.Play(); //play
        StartCoroutine(stopsound()); //stop at specifies time in unity editor
    }

    private IEnumerator stopsound()
    {
        yield return new WaitForSeconds(stopseconds);
        blah.Stop();
    }

    public void StopSounds()
    {
        blah.Stop(); //when clicked rebattle all sounds should stop
    }
}
