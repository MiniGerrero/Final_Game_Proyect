

using UnityEngine;
using TMPro;
using System.Collections;
public class NPC_Text_Sistem : MonoBehaviour
{
    private InputPlayer ctrl;
    [Header("Parameter")]
    [SerializeField]private GameObject dialogoField;
    [SerializeField]private TMP_Text dialogoText;
    [SerializeField]private string playerLayer;
    [SerializeField]private Animator animator;
    [Header("Text Parameter")]
    [SerializeField,TextArea(4,6)]private string[] dialogLine;
    [SerializeField] private float sleepTime;

    private int lineIndex;
    private bool activeDialogo = false;
    private bool inRange; 
    private Player playerMode;
    
    private bool mapacheActive = false;

    private void Awake()
    {

        ctrl = new();
    } 
    private void OnEnable()
    {
        ctrl.Enable();
    }
    private void OnDisable()
    {
        ctrl.Disable();
    }
    // Update is called once per frame
    private void Update()
    {
        if (ctrl.Player.Interation.WasPerformedThisFrame() && inRange)
        {
            if (!mapacheActive)
            {
                mapacheActive = true; 
                animator.SetBool("MapacheActive", mapacheActive);
            }
            else
            {
                SistemaDeDialogo();
            }
        }
    }
    public void DialogoAnimator()
    {
        if (!activeDialogo)
        {
            SistemaDeDialogo();
        }
    }
    private void SistemaDeDialogo()
    {
        if (!activeDialogo)
        {
            StartDialoge();
        }else if (dialogoText.text == dialogLine[lineIndex])
        {
            NextDialogo();
        }
        else
        {
           StopAllCoroutines();
            dialogoText.text = dialogLine[lineIndex];
        }
    }
    private void StartDialoge()
    {
        playerMode.dialogoMode = false;
        dialogoField.SetActive(true);
        activeDialogo = true;
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    private void NextDialogo()
    {
        lineIndex++;
        if (lineIndex < dialogLine.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogoField.SetActive(false);
            activeDialogo = false;
            playerMode.dialogoMode = true;
        }
    }
    private IEnumerator ShowLine()
    {
        dialogoText.text = string.Empty;
        foreach(char ch in dialogLine[lineIndex])
        {
            dialogoText.text += ch;
            yield return new WaitForSeconds(sleepTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == playerLayer)
        {
            inRange = true;
            playerMode = other.GetComponent<Player>();

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == playerLayer)
        {
            inRange = false;

        }
    }
}
