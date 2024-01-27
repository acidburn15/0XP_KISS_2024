using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform doorTransform;
    [SerializeField] private TextMeshProUGUI countNote;
    [SerializeField] private TextMeshProUGUI countDead;

    //[SerializeField] private Transform transitionTransform;
    public int death;
    public int numberOfNotes;
    private GameObject[] respawns;
    private FollowPlayer[] notes;
    private GameObject[] noteObjects;
    public GameObject setting;
    public GameObject son;
    public GameObject hud;
    public int notesCollected;

    [SerializeField] private AudioClip[] noteSounds;

    // Start is called before the first frame update
    void Start()
    {
        setting.SetActive(false);
        hud.SetActive(true);
        son.SetActive(false);
        RespawnNotes();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            setting.SetActive(true);
            hud.SetActive(false);
        }
    }

    public void AddNoteCollected()
    {
        notesCollected++;
        countNote.text = notesCollected.ToString() + "/3";

    }

    public void RespawnNotes()
    {
        notes = GameObject.FindObjectsOfType<FollowPlayer>();
        respawns = GameObject.FindGameObjectsWithTag("NoteSpawn");

        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].GetComponent<FollowPlayer>().ChangePickedState();
            notes[i].transform.position = respawns[i].transform.position;
            notesCollected = 0;
            countNote.text = notesCollected.ToString() + "/3";
        }
    }

    public void OpenDoor()
    {
        noteObjects = GameObject.FindGameObjectsWithTag("Note");
        StartCoroutine(DelayCoroutine(noteObjects));

    }

    IEnumerator DelayCoroutine(GameObject[] noteObjects)
    {
        foreach (GameObject note in noteObjects)
        {
            FollowPlayer noteObject = note.GetComponent<FollowPlayer>();
            noteObject.EndLevel();
            SoundFXManager.Instance.PlaySoundFXClip(noteObject.GetNoteSound(), noteObject.transform,
                noteObject.GetNoteSoundVolume());
            // activation du son pour la note.

            yield return new WaitForSeconds(0.35f);
        }
    }

    public void addDeath()
    {
        death += 1;
        countDead.text = death.ToString() + "x";
    }

    public void returnGame()
    {
        Time.timeScale = 1;
        hud.SetActive(true);
        setting.SetActive(false);
    }

    public void returnSetting()
    {
        setting.SetActive(true);
        son.SetActive(false);
    }

    public void setSon()
    {
        setting.SetActive(false);
        son.SetActive(true);
    }

    public void returnMain()
    {
        SceneManager.LoadScene(0);
    }
}
