using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBehaviour : MonoBehaviour
{
    public UnityEvent OnClick;

    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
    }
}
