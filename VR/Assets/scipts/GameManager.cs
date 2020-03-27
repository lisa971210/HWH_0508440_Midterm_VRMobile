using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject lightgroup;
    [Header("抽屜")]
    public Transform drawer;
    [Header("門")]
    public Transform door;
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
        for (int i = 0; i < 30; i++)
        {
            drawer.position -= drawer.forward*0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        drawer.GetComponent<CapsuleCollider>().enabled = false;
    }

    private void Start()
    {
        StartCoroutine(LightEffect());
    }
}