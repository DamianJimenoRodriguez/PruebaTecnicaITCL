using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public abstract class PickUp : MonoBehaviour
{
    private Collider myCollider;
    private AudioSource myAudioSource;
    private MeshRenderer myMeshRenderer;
    [SerializeField] private int timeToDisable;
    private string dissolvePropertyname = "_Dissolve";

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myCollider = GetComponent<Collider>();
        myMeshRenderer = GetComponentInChildren<MeshRenderer>();
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
        float timeElapsed = 0;
        while (timeElapsed < timeToDisable)
        {
            yield return null;
            timeElapsed += Time.deltaTime;
            float lerpValue = Mathf.Lerp(0, 1, timeElapsed / timeToDisable);
            myMeshRenderer.material.SetFloat(dissolvePropertyname, lerpValue);
        }
        gameObject.SetActive(false);
    }
}