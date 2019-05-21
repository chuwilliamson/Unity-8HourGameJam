using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelBehaviour : MonoBehaviour
{

    public IntVariable score;

    private void Start()
    {
        score = Resources.Load<IntVariable>("Score");
    }

    private void Update()
    {
        if (score.Value > 5)
        {
            score.Value = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
