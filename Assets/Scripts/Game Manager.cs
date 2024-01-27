using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform doorTransform;
    //[SerializeField] private Transform transitionTransform;
    public int numberOfNotes;
    private GameObject[] respawns;
    private FollowPlayer[] notes;
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

    public void OpenDoor()
    {
        notes = GameObject.FindObjectsOfType<FollowPlayer>();

        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].GetComponent<FollowPlayer>().ChangePickedState();
            //notes[i].transform.position = Vector3.Lerp(notes[i].transform.position, transitionTransform.position, 3f * Time.deltaTime);
            //notes[i].transform.position = Vector3.Lerp(notes[i].transform.position, doorTransform.position, 3f * Time.deltaTime);
            notes[i].transform.position = Vector2.MoveTowards(notes[i].transform.position, doorTransform.position, numberOfNotes/i * Time.deltaTime);
        }
    }
}
