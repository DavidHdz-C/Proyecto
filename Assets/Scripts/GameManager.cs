using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour {

    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;



    private QuizBD m_quizBD = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSorce = null;


    private void Start()
    {
        m_quizBD = GameObject.FindObjectOfType<QuizBD>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        m_audioSorce = GetComponent<AudioSource>();

        NextQuestion();
    }
    private void NextQuestion()
    {
        m_quizUI.Construtc(m_quizBD.GetRandom(), GiveAnswer);

    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }
    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {

        if (m_audioSorce.isPlaying)
            m_audioSorce.Stop();

        m_audioSorce.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.SetColor( optionButton.Option.correct ? m_correctColor : m_incorrectColor);

        m_audioSorce.Play();


        yield return new WaitForSeconds(m_waitTime);

        if (optionButton.Option.correct)

            NextQuestion();

        else
            GameOver();

    }

    private void GameOver()
    {
        SceneManager.LoadScene(1);
    }

}

