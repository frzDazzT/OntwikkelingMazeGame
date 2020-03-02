using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    DialogObject currentDialog;
    public float rayDistance;
    public GameObject dialogCanvas;
    public Text dialogText;
    public Text dialogName;
    public Text actionText;
    [HideInInspector]
    public bool isDialogOpen;
    int dialogIndex;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.transform.gameObject.GetComponent<DialogHolder>() && !isDialogOpen)
            {
                actionText.text = "Press [e] to interact";
                actionText.gameObject.SetActive(true);
                if (Input.GetButtonDown("Interact"))
                {                   
                    currentDialog = hit.transform.gameObject.GetComponent<DialogHolder>().dialog;
                    dialogName.text = currentDialog.nameOfInteractible;
                    actionText.gameObject.SetActive(false);
                    dialogCanvas.SetActive(true);
                    isDialogOpen = true;
                    DialogUpdate();
                }
            }
        }
        else
        {
            actionText.gameObject.SetActive(false);
        }
    }

    public void DialogUpdate()
    {
        //setting and continue dialog
        if (isDialogOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (dialogIndex <= currentDialog.dialog.Count - 1)
            {
                dialogText.text = currentDialog.dialog[dialogIndex];
            }
            else
            {
                //close dialog
                dialogCanvas.SetActive(false);
                isDialogOpen = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                dialogIndex = 0;
            }
        }
    }

    public void ContinueButtonDialog()
    {
        dialogIndex++;
        DialogUpdate();
    }
}
