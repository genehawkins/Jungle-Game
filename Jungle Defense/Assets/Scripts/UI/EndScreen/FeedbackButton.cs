using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackButton : MonoBehaviour
{
    // Google Form: https://forms.gle/tnaojFfSAZnfKZHY8
    public void OpenFeedbackForm()
    {
        Application.OpenURL("https://forms.gle/tnaojFfSAZnfKZHY8");
    }
}
