using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        AnimationsClips animationsClips = new AnimationsClips();
        Video video = new Video(Animator);
        video.Clips.Add(animationsClips.HumanWalking);
        video.Clips.Add(animationsClips.HumanWalking);
        video.Clips.Add(animationsClips.HumanWalking);
        video.Clips.Add(animationsClips.HumanWalking);
        video.Clips.Add(animationsClips.HumanDancing);
        VideoController videoController = new VideoController();
        
        videoController.CreateVideo();
        
        videoController.AddTrack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
