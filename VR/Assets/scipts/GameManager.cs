using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject lightgroup;
    [Header("抽屜")]
    public Transform drawer;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("木板上滑動音效")]
    public AudioClip woodsound;
    [Header("鐵製品移動音效")]
    public AudioClip metalsound;
    [Header("敲門音效")]
    public AudioClip doorsound;
    [Header("開門音效")]
    public AudioClip opensound;
    public Animator anidoor,anishelf,anidrawer, aniclothe, aniclothe2,anifly, anifly2,anicolor;
    private int countdoor, countshelf, countdrawer, countclothe,countclothe2,countcolor;

    public void Lookdoor()
    {
        countdoor++;
        if (countdoor == 1)
        {
            aud.PlayOneShot(doorsound, 5);
        }else if (countdoor == 2)
        {
            aud.PlayOneShot(opensound, 4.5f);
            anidoor.SetTrigger("開門觸發");
        }
    }
    public void Shelfdrop()
    {
        countshelf++;
        if (countshelf == 1)
        {
            aud.PlayOneShot(doorsound, 5);
            anishelf.SetTrigger("動");
        }
        if (countshelf == 2)
        {
            aud.PlayOneShot(doorsound, 5);
            anishelf.SetTrigger("動");
        }
        else if (countshelf == 3)
        {
            aud.PlayOneShot(opensound, 4.5f);
            anishelf.SetTrigger("掉");
        }
    }
    public void Draweroac()
    {
        countdrawer++;
        if (countdrawer == 1)
        {
            aud.PlayOneShot(doorsound, 5);
            anidrawer.SetTrigger("開");
 

        }
        else if (countdrawer == 2)
        {
            aud.PlayOneShot(opensound, 4.5f);
            anidrawer.SetTrigger("關");

        }
 
    }
    public void Shelfopen2()
    {
        countclothe2++;
        if (countclothe2 == 1)
        {
            aud.PlayOneShot(doorsound, 5);
            aniclothe2.SetTrigger("開");
        }
        else if (countclothe2 == 2)
        {
            aud.PlayOneShot(opensound, 4.5f);
            aniclothe2.SetTrigger("關");
            countclothe2= 0;
        }

    }
    public void Shelfopen1()
    {
        countclothe++;
        if (countclothe == 1)
        {
            aud.PlayOneShot(doorsound, 5);
            aniclothe.SetTrigger("開");
        }
        else if (countclothe == 2)
        {
            aud.PlayOneShot(opensound, 4.5f);
            aniclothe.SetTrigger("關");
            countclothe = 0;
        }
    }
    public void Bedfly()
    {
        aud.PlayOneShot(doorsound, 5);
        anifly.Play("fly");
    }
    public void Bedfly2()
    {
        aud.PlayOneShot(doorsound, 5);
        anifly2.Play("fly");
    }
    public void Changecolor()
    {
        countcolor++;
        if (countcolor == 1)
        {
            aud.PlayOneShot(doorsound, 5);
            anicolor.SetTrigger("a");
        }
        else if (countcolor == 2)
        {
            aud.PlayOneShot(opensound, 4.5f);
            anicolor.SetTrigger("b");
        }
        else if (countcolor == 3)
        {
            aud.PlayOneShot(opensound, 4.5f);
            anicolor.SetTrigger("c");
        }

    }
    public IEnumerator LightEffect()
    {
        lightgroup.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        lightgroup.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lightgroup.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        lightgroup.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lightgroup.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        lightgroup.SetActive(true);
    }
    public void StartObjectMove()
    {
        StartCoroutine(ObjectMove());
    }
    public IEnumerator ObjectMove()
    {
        drawer.GetComponent<CapsuleCollider>().enabled = false;
        for (int i = 0; i < 30; i++)
        {
            drawer.position -= drawer.forward*0.1f;
            yield return new WaitForSeconds(0.01f);
        }

        aud.PlayOneShot(woodsound, 2.5f);
    }

    private void Start()
    {
        StartCoroutine(LightEffect());
    }
}