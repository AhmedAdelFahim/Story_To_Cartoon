using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //public Animator Animator;
    
    private VideoController videoController;
    
    public AnimationClip HumanIdle;
    public AnimationClip HumanWalking;
    public AnimationClip HumanJumping;
    public AnimationClip HumanDancing;
    private InstantiateScene instantiateScene;

    // Start is called before the first frame update
    void Start()
    {
       
        instantiateScene = GetComponentInChildren<InstantiateScene>();
        Animator instantiateSceneBelly = instantiateScene.iBelly.GetComponentInChildren<Animator>();
       

        videoController = new VideoController();
       // AnimationsClips animationsClips = new AnimationsClips();
        Track track = new Track(instantiateSceneBelly);
        List<AnimationClip> Clips = new List<AnimationClip>();
        Clips.Add(HumanWalking);
        Clips.Add(HumanWalking);
        Clips.Add(HumanWalking);
        Clips.Add(HumanWalking);
        Clips.Add(HumanDancing);
        Debug.Log(HumanWalking);
        
        track.Clips = Clips;
        
        videoController.CreateVideo();
        
        videoController.AddTrack(track);
        
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
