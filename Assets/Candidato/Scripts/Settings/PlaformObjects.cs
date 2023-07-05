using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to activate and deactivate objects
/// based on whether we are playing on a mobile device or on a PC
/// </summary>
public class PlaformObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] mobileObjects;
    [SerializeField] private GameObject[] pcObjects;

    private void Awake()
    {
        SetUp();
    }

    private void SetUp()
    {
#if UNITY_ANDROID || UNITY_IOS
        ToogleObjects(mobileObjects, true);
        ToogleObjects(pcObjects, false);

#else
        ToogleObjects(pcObjects, true);
        ToogleObjects(mobileObjects, false);

#endif
    }

    public void ToogleObjects(GameObject[] objects, bool value)
    {
        foreach (var obj in objects)
        {
            obj.gameObject.SetActive(value);
        }
    }
}