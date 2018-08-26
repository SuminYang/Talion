using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiGachaMachine : MonoBehaviour, IPointerClickHandler
{
    private enum MachineState
    {
        Waiting, Opening
    }

    [SerializeField]
    private Text touchText;

    [SerializeField]
    private Animator shakeAnimator;

    [SerializeField]
    private Image flash;

    [SerializeField]
    private UiGachaPopup uiGachaPopup;

    [SerializeField]
    private Transform itemSpawnPosit;

    [SerializeField]
    private Transform itemStopPosit;

    [SerializeField]
    private UiGoinInfo uiCoinInfo;

    //연출 설정값
    private float flashTime = 0.7f;
    private float ballSpawnTime = 1.5f;
    private float confirmButtonSpawnTime = 1f;
    private float itemSpawnTime = 1f;

    private MachineState state = MachineState.Waiting;

    //임시 리소스
    [SerializeField]
    private List<Sprite> ballSprites;

    private void Start()
    {
        SetMachineWaiting();
    }

    private void SetMachineWaiting()
    {
        state = MachineState.Waiting;
        TextFading(true);
    }

    private void SetMachineOpening()
    {
        if (state != MachineState.Waiting) return;

        state = MachineState.Opening;
        TextFading(false);
    }

    private void UseCoin()
    {
        PlayerDataManager.UseCoin(1);
        uiCoinInfo.UpdateCoinData();
    }

    private void TextFading(bool OnOff)
    {
        if (OnOff == true)
        {
            touchText.gameObject.SetActive(true);
            touchText.color = Color.white;
            iTween.FadeTo(touchText.gameObject, iTween.Hash("alpha", 0f, "loopType", "pingpong", "easeType", "easeInOutCubic"));
        }
        else
        {
            touchText.gameObject.SetActive(false);
            iTween.Stop(touchText.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (state == MachineState.Waiting)
        {
            if (PlayerDataManager.CanBuyItem(1) == true)
            {
                StartCoroutine(GachaDirectionRoutine());
            }
            else
            {
                Debug.LogError("코인이 부족합니다");
            }
        }
    }

    IEnumerator GachaDirectionRoutine()
    {
        SetMachineOpening();

        UseCoin();

        yield return new WaitForSeconds(0.5f);

        //흔들림
        shakeAnimator.SetTrigger("Shake");
        yield return new WaitForSeconds(2.0f);

        //상자 나타남
        uiGachaPopup.gameObject.SetActive(true);
        uiGachaPopup.transform.position = itemSpawnPosit.position;
        uiGachaPopup.SetIcon(ballSprites[Random.Range(0, ballSprites.Count)]);
        uiGachaPopup.FadeImage(ballSpawnTime);
        iTween.MoveTo(uiGachaPopup.gameObject, iTween.Hash("position", itemStopPosit.position, "time", ballSpawnTime, "easeType", "easeOutQuart"));
        yield return new WaitForSeconds(ballSpawnTime);

        //화면 밝아지는 연출
        flash.color = new Color(1f, 1f, 1f, 0f);
        iTween.FadeTo(flash.gameObject, iTween.Hash("alpha", 1f, "Time", flashTime, "loopType", "pingpong", "easeType", "easeInQutQuart"));

        yield return new WaitForSeconds(flashTime * 0.5f);
        uiGachaPopup.SetIcon(null);
        yield return new WaitForSeconds(flashTime * 0.5f);

        flash.color = new Color(1f, 1f, 1f, 0f);
        iTween.Stop(flash.gameObject);

        uiGachaPopup.ShowItemInfoText(itemSpawnTime, "Test Item");
        yield return new WaitForSeconds(itemSpawnTime);

        uiGachaPopup.ShowConfirmButton(confirmButtonSpawnTime);

    }

    private void ShowGachaBall()
    {
        Debug.Log("상자 나타남");
    }

    private void ShowItem()
    {
        Debug.Log("아이템 보여줌");
    }

    public void OnConfirmButtonClick()
    {
        uiGachaPopup.ResetPopUp();
        SetMachineWaiting();
    }
}
