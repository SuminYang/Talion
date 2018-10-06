using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UiDialog : MonoBehaviour
{
    [SerializeField]
    private Image speakerLeftProfile;
    [SerializeField]
    private Text speakerLeftName;
    [SerializeField]
    private Text speakerLeftText;
    [SerializeField]
    private GameObject leftNameFrame;

    [SerializeField]
    private Image speakerRightProfile;
    [SerializeField]
    private Text speakerRightName;
    [SerializeField]
    private Text speakerRightText;
    [SerializeField]
    private GameObject rightNameFrame;

    [SerializeField]
    private GameObject dialogObjects;

    [SerializeField]
    private GameObject dialogMask;

    private List<DialogData> dialogDatas;

    private Dictionary<string, Sprite> profiles = new Dictionary<string, Sprite>();

    private StringBuilder sb = new StringBuilder();

    private bool nowPlaying = false;

    private const float typingSpeed = 0.03f;

    private WaitForSeconds typingWs = new WaitForSeconds(typingSpeed);

    private DialogData.SpeakerPosition currentPosition;

    private bool isUserClickTouchScreen = false;

    public void PlayDialog(int dialogIndex)
    {
        if (nowPlaying == true)
        {
            Debug.LogError("이미 대화가 진행 중 입니다.");
            return;
        }

        ShowMask(true);

        dialogObjects.gameObject.SetActive(true);

        List<DialogData> dialogDatas = DataManager.Instance.dataBaseLoader.GetDialog(dialogIndex);

        if (dialogDatas == null)
        {
            Debug.LogError("해당 대화가 없습니다");
            return;
        }

        this.dialogDatas = dialogDatas;

        nowPlaying = true;

        StartCoroutine(PlayDialog());
    }

    private void ShowMask(bool OnOff)
    {
        dialogMask.gameObject.SetActive(OnOff);
    }

    private void EndDialog()
    {
        ResetDialog();
        dialogObjects.gameObject.SetActive(false);
        nowPlaying = false;
        isUserClickTouchScreen = false;
    }

    private void ResetDialog()
    {
        speakerLeftProfile.gameObject.SetActive(false);
        speakerLeftProfile.sprite = null;

        speakerLeftName.gameObject.SetActive(false);
        speakerLeftName.text = string.Empty;

        speakerLeftText.gameObject.SetActive(false);
        speakerLeftText.text = string.Empty;

        leftNameFrame.gameObject.SetActive(false);

        speakerRightProfile.gameObject.SetActive(false);
        speakerRightProfile.sprite = null;

        speakerRightName.gameObject.SetActive(false);
        speakerRightName.text = string.Empty;

        speakerRightText.gameObject.SetActive(false);
        speakerRightText.text = string.Empty;

        rightNameFrame.gameObject.SetActive(false);

        dialogDatas = null;

        ShowMask(false);

    }



    private IEnumerator PlayDialog()
    {
        int nowDialogIndex = 0;

        while (nowPlaying == true)
        {
            if (nowDialogIndex >= dialogDatas.Count)
            {
                break;
            }

            StartDialog(dialogDatas[nowDialogIndex]);

            DialogData data = dialogDatas[nowDialogIndex];

            string dialog = data.message;
            int currentDialogIndex = 0;

            while (true)
            {
                //타이핑이 다 끝났다.
                if (currentDialogIndex >= dialog.Length)
                {
                    //입력이 있으면?
                    if (isUserClickTouchScreen == true)
                    {
                        isUserClickTouchScreen = false;
                        ClearStringBuilder();
                        break;
                    }

                    //대기
                    yield return null;
                    continue;
                }

                //타이핑 중에 화면을 유저가 터치했다?
                if (isUserClickTouchScreen == true)
                {
                    isUserClickTouchScreen = false;
                    currentDialogIndex = dialog.Length;
                    TypingTextAll(dialog);

                }
                else
                {
                    TypingText(dialog[currentDialogIndex]);
                    currentDialogIndex++;
                }

                yield return typingWs;
            }
            nowDialogIndex++;

            yield return null;
        }

        //대화 종료
        EndDialog();
    }

    private void ClearStringBuilder()
    {
        sb.Length = 0;
        speakerLeftText.text = string.Empty;
        speakerRightText.text = string.Empty;
    }
    private void TypingText(char text)
    {
        sb.Append(text);

        switch (currentPosition)
        {
            case DialogData.SpeakerPosition.LEFT:
                {
                    speakerLeftText.text = sb.ToString();
                }
                break;
            case DialogData.SpeakerPosition.RIGHT:
                {
                    speakerRightText.text = sb.ToString();
                }
                break;
        }
    }
    private void TypingTextAll(string text)
    {
        sb.Length = 0;

        switch (currentPosition)
        {
            case DialogData.SpeakerPosition.LEFT:
                {
                    speakerLeftText.text = text;
                }
                break;
            case DialogData.SpeakerPosition.RIGHT:
                {
                    speakerRightText.text = text;
                }
                break;
        }
    }

    private void StartDialog(DialogData data)
    {
        currentPosition = data.position;

        switch (data.position)
        {
            case DialogData.SpeakerPosition.LEFT:
                {


                    HidePlayer(DialogData.SpeakerPosition.RIGHT);

                    leftNameFrame.gameObject.SetActive(true);
                    speakerLeftText.gameObject.SetActive(true);
                    speakerLeftText.text = data.message;

                    speakerLeftName.gameObject.SetActive(true);
                    speakerLeftName.text = data.speaker;

                    speakerLeftProfile.transform.SetAsLastSibling();
                    speakerLeftProfile.color = Color.white;

                    if (profiles.ContainsKey(data.speaker) == true)
                    {
                        speakerLeftProfile.gameObject.SetActive(true);
                        speakerLeftProfile.sprite = profiles[data.speaker];
                    }
                    else
                    {
                        //로드후 세팅
                        if (LoadCharacterSprite(data.speaker) == true)
                        {
                            speakerLeftProfile.gameObject.SetActive(true);
                            speakerLeftProfile.sprite = profiles[data.speaker];
                        }

                    }
                }
                break;
            case DialogData.SpeakerPosition.RIGHT:
                {
                    HidePlayer(DialogData.SpeakerPosition.LEFT);

                    rightNameFrame.gameObject.SetActive(true);
                    speakerRightText.gameObject.SetActive(true);
                    speakerRightText.text = data.message;

                    speakerRightName.gameObject.SetActive(true);
                    speakerRightName.text = data.speaker;


                    speakerRightProfile.transform.SetAsLastSibling();
                    speakerRightProfile.color = Color.white;

                    if (profiles.ContainsKey(data.speaker) == true)
                    {
                        speakerRightProfile.gameObject.SetActive(true);
                        speakerRightProfile.sprite = profiles[data.speaker];
                    }
                    else
                    {
                        //로드후 세팅
                        if (LoadCharacterSprite(data.speaker) == true)
                        {
                            speakerRightProfile.gameObject.SetActive(true);
                            speakerRightProfile.sprite = profiles[data.speaker];
                        }


                    }

                }
                break;
        }
    }
    private void HidePlayer(DialogData.SpeakerPosition position)
    {
        switch (position)
        {
            case DialogData.SpeakerPosition.LEFT:
                {
                    leftNameFrame.gameObject.SetActive(false);
                    speakerLeftProfile.transform.SetAsFirstSibling();
                    speakerLeftProfile.color = Color.grey;

                    speakerLeftName.gameObject.SetActive(false);
                    speakerLeftText.gameObject.SetActive(false);

                }
                break;
            case DialogData.SpeakerPosition.RIGHT:
                {
                    rightNameFrame.gameObject.SetActive(false);
                    speakerRightProfile.transform.SetAsFirstSibling();
                    speakerRightProfile.color = Color.grey;
                    speakerRightName.gameObject.SetActive(false);
                    speakerRightText.gameObject.SetActive(false);
                }
                break;
        }
    }
    //로드 성공 true / 실패 false
    private bool LoadCharacterSprite(string name)
    {
        Sprite sprite = Resources.Load<Sprite>(string.Format("Characters/{0}/{1}", name, name));

        if (sprite != null && profiles.ContainsKey(name) == false)
        {
            profiles.Add(name, sprite);
            return true;
        }

        Debug.LogError("캐릭터 리소스 로드 실패");
        return false;
    }

    private void CheckTouchInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isUserClickTouchScreen = true;
        }
    }

    private void Update()
    {
        CheckTouchInput();
    }
}
