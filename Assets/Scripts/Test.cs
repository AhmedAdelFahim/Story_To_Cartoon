using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Animator Animator;

    private VideoController videoController;
    public AnimationClip HumanIdle;
    public AnimationClip HumanWalking;
    public AnimationClip HumanJumping;
    public AnimationClip HumanDancing;

    // Start is called before the first frame update
    void Start()
    {
        videoController = new VideoController();
       // AnimationsClips animationsClips = new AnimationsClips();
        Track video = new Track(Animator);
        List<AnimationClip> Clips = new List<AnimationClip>();
        Clips.Add(HumanWalking);
        Clips.Add(HumanWalking);
        Clips.Add(HumanWalking);
        Clips.Add(HumanWalking);
        Clips.Add(HumanDancing);
        Debug.Log(HumanWalking);
        video.Clips = Clips;
        
        videoController.CreateVideo();
        
        videoController.AddTrack(video);
        
        videoController.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        //videoController.UpdateClips();
    }

    private void FixedUpdate()
    {
        videoController.UpdateClips();
    }

    private void LateUpdate()
    {
        
        videoController.MatchOffsetsWithPrevious();
    }

    private void OnDestroy()
    {
        videoController.Destroy();
    }
}
