using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{ 
    public List<bool> objectivesDone = new List<bool>();
    GameObject player;
    public Objective objective;
    public Text objectiveText1;
    public Text objectiveText2;
    public GameObject check1, check2;
    public string ifKeyGottenBeforeExitFound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        bool objectiveBool = false;
        foreach (var obj in objective.objectiveDescription)
        {
            objectivesDone.Add(objectiveBool);
        }
        //set UI text
        objectiveText1.text = objective.objectiveDescription[0];
        objectiveText2.text = objective.objectiveDescription[1];
    }

    public void CompletedObjective(ObjectiveType type)
    {
        if (type == ObjectiveType.Key)
        {
            //get which index and mark as done in list
            int index = objective.objectiveOfType.IndexOf(ObjectiveType.Key);

            objectivesDone[index] = true;

            switch (index)
            {
                case 0:
                    check1.SetActive(true);
                    break;
                case 1:
                    check2.SetActive(true);
                    break;
            }

           
            int indexExit = objective.objectiveOfType.IndexOf(ObjectiveType.Exit);
            if (!objectivesDone[indexExit])
            {
                switch (indexExit)
                {
                    case 0:
                        objectiveText1.text = ifKeyGottenBeforeExitFound;
                        break;
                    case 1:
                        objectiveText2.text = ifKeyGottenBeforeExitFound;
                        break;
                }
            }          
        }

        if (type == ObjectiveType.Exit)
        {
            //get which index and mark as done in list
            int index = objective.objectiveOfType.IndexOf(ObjectiveType.Exit);

            objectivesDone[index] = true;

            switch (index)
            {
                case 0:
                    check1.SetActive(true);
                    break;
                case 1:
                    check2.SetActive(true);
                    break;
            }
        }
    }

    public bool GetIfObjectiveComplete(ObjectiveType type)
    {
        int index = objective.objectiveOfType.IndexOf(type);

        if(objectivesDone[index])
        {
            return true;
        }

        return false;
    }

    public void ResetObjectives()
    {
        check1.SetActive(false);
        check2.SetActive(false);
        objectiveText1.text = objective.objectiveDescription[0];
        objectiveText2.text = objective.objectiveDescription[1];
    }
}
