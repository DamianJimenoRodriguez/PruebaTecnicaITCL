using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public abstract class PickUp : MonoBehaviour
{
    private Collider myCollider;
    private AudioSource myAudioSource;
    [SerializeField] private int timeToDisable;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myCollider = GetComponent<Collider>();
    }

    public abstract void OnPickUp(Player player);

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            if (myAudioSource != null)
            {
                myAudioSource.Play();
            }
            myCollider.enabled = false;
            OnPickUp(player);
            StartCoroutine(DisablePickUp());
        }
    }

    public IEnumerator DisablePickUp()
    {
        yield return new WaitForSeconds(timeToDisable);
        gameObject.SetActive(false);
    }
}