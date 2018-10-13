using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneHotelFront : UiSceneBase

{

    [SerializeField]
    private UiDialog uiDialog;

public void PlayDialog(int index)
{
    if (uiDialog == null) return;
    uiDialog.PlayDialog(index);
}

#if UNITY_EDITOR

    void Awake()
    {
            PlayDialog(0);

    }


#endif

}
