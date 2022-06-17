using UnityEngine;
using UnityEngine.UI;

public class Survey : MonoBehaviour
{
    public GameObject[] questionGroups;
    public QuestionAndAnswer[] questionAndAnswers;
    public GameObject answerConfirmationPanel;
    public string myResults;

    private readonly string Question = "Question";
    private readonly string Answer = "Answer";
    private readonly string Lable = "Label";
    private readonly string Text = "Text";

    private void Start()
    {
        questionAndAnswers = new QuestionAndAnswer[questionGroups.Length];
    }

    public void SubmitAnswer()
    {
        for (int i = 0; i < questionAndAnswers.Length; i++)
        {
            questionAndAnswers[i] = ReadQuestionAndAnswer(questionGroups[i]);
        }

        DisplayResults();
    }

    private QuestionAndAnswer ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QuestionAndAnswer result = new QuestionAndAnswer();
        GameObject question = questionGroup.transform.Find(Question).gameObject;
        GameObject answer = questionGroup.transform.Find(Answer).gameObject;
        result.question = question.GetComponent<Text>().text;

        if (answer.GetComponent<ToggleGroup>() != null)
        {
            FindTextForTheToggle(answer, result);
        }
        else if (answer.GetComponent<InputField>() != null)
        {
            FindTextInput(answer, result, Text);
        }

        else if (answer.GetComponent<Dropdown>() != null)
        {
            FindTextInput(answer, result, Lable);
        }

        else if (answer.GetComponent<ToggleGroup>() == null && answer.GetComponent<InputField>() == null)
        {
            FindToggleGroupsForInputFields(answer, result);
        }

        return result;
    }

    private void FindTextForTheToggle(GameObject answer, QuestionAndAnswer result)
    {
        for (int i = 0; i < answer.transform.childCount; i++)
        {
            if (answer.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                result.answer = answer.transform.GetChild(i).Find(Lable).GetComponent<Text>().text;
                break;
            }
        }
    }

    private void FindTextInput(GameObject answer, QuestionAndAnswer result, string text)
    {
        result.answer = answer.transform.Find(text).GetComponent<Text>().text;
    }

    private void FindToggleGroupsForInputFields(GameObject answer, QuestionAndAnswer result)
    {
        string myLocalString = "";
        int counter = 0;

        for (int i = 0; i < answer.transform.childCount; i++)
        {
            if (answer.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                if (counter != 0)
                {
                    myLocalString = $"{myLocalString}, ";
                }

                myLocalString += answer.transform.GetChild(i).Find(Lable).GetComponent<Text>().text;
                counter++;
            }

            if (i == answer.transform.childCount - 1)
            {
                myLocalString = $"{myLocalString}.";
            }
        }

        result.answer = myLocalString;
    }

    public void DisplayResults()
    {
        answerConfirmationPanel.SetActive(true);
        string myLocalString = "";

        for (int i = 0; i < questionAndAnswers.Length; i++)
        {
            myLocalString = $"{myLocalString}{questionAndAnswers[i].question}\n";
            myLocalString = $"{myLocalString}{questionAndAnswers[i].answer}\n\n";
            answerConfirmationPanel.transform.Find(Answer).GetComponent<Text>().text = myLocalString;
        }

        myResults = myLocalString;
    }
}

[System.Serializable]
public class QuestionAndAnswer
{
    public string question = "";
    public string answer = "";
}