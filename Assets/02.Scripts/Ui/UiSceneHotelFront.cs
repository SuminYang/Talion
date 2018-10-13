using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneHotelFront : UiSceneBase
{
    private void Start()
    {
        UiDialog.Instance.PlayDialog(0);
    }
}
