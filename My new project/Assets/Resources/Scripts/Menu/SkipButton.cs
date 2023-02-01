using UnityEngine;
using UnityEngine.Playables;

public class SkipButton : MonoBehaviour
{
    [SerializeField]
    PlayableDirector playableDirector;

    public void Play(float time)
    {
        playableDirector.time = time;
    }
}
