using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveElement : MonoBehaviour
{
    [SerializeField]
    GameObject targetElement;

    public void toggleElementActive() {
        targetElement.SetActive(!targetElement.activeSelf);
    }

}
