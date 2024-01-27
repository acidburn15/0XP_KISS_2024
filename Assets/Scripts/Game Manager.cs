using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
    public int notesCollected;
    // Start is called before the first frame update
    void Start()
    {
        RespawnNotes();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            note.GetComponent<FollowPlayer>().EndLevel();
            // activation du son pour la note.

            yield return new WaitForSeconds(0.35f);
        }
    }

    public void addDeath()
    {
        death += 1;
        countDead.text = death.ToString() + "x";
    }
}
