using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private string SongMessage = "Song: ";
    private string SongTitle = " ";
    private int SongID = 0;

    public Text songTxt;
    public AudioSource Jukebox;
    public AudioClip[] Song = new AudioClip[6];
    public Image[] Image = new Image[6];

    private void Start()
    {
        for (int x = 0; x < 6; x++)
        {
            Image[x].enabled = false;
        }
        Image[0].enabled = true;
        GetTitle();
        Jukebox.PlayOneShot(Song[SongID]);
    }

    void Update()
    {
        songTxt.text = SongMessage + SongTitle; 
        if(Jukebox.isPlaying == false)
        {
            SongID += 1;
            if(SongID == 6) { SongID = 0; }
            for (int x = 0; x < 6; x++)
            {
                Image[x].enabled = false;
            }
            Image[SongID].enabled = true;
            GetTitle();
            Jukebox.PlayOneShot(Song[SongID]);
        }
    }

    private void GetTitle()
    {
        if (SongID == 0) { SongTitle = "A New Beginning"; }
        else if (SongID == 1) { SongTitle = "Creative Minds"; }
        else if (SongID == 2) { SongTitle = "Happy Rock"; }
        else if (SongID == 3) { SongTitle = "Jazzy Frenchy"; }
        else if (SongID == 4) { SongTitle = "Little Idea"; }
        else if (SongID == 5) { SongTitle = "Ukulele"; }
    }

    public void ChangeSongUp()
    {
        SongID += 1;
        if (SongID == 6) SongID = 0;
        GetTitle();
        Jukebox.Stop();
        Jukebox.PlayOneShot(Song[SongID]);
        
        for(int x = 0; x < 6; x++)
        {
            Image[x].enabled = false;
        }
        Image[SongID].enabled = true;
    }

    public void ChangeSongDown()
    {
        SongID -= 1;
        if (SongID == -1) SongID = 5;
        GetTitle();
        Jukebox.Stop();
        Jukebox.PlayOneShot(Song[SongID]);
        for (int x = 0; x < 6; x++)
        {
            Image[x].enabled = false;
        }
        Image[SongID].enabled = true;
    }
}
