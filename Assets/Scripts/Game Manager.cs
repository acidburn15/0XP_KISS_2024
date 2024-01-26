using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int numberOfNotes;
    private GameObject[] respawns;
    private FollowPlayer[] notes;
    private int notesCollected;
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
        }
    }
}
