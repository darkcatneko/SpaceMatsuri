using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] private ObjectPoolClass audioSourcePool_;
    [SerializeField] private GameObject SEPrefeab;
    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.WeaponSuccessFireEvent.AddListener(CallSpawnSoundEffect);
        GameManager.Instance.M_MainGameEvent.BossSpawnEvent.AddListener(() => { CallSpawnSoundEffect(0); });
        GameManager.Instance.M_MainGameEvent.EnterFeverTimeEvent.AddListener(() => { CallSpawnSoundEffect(4); });
        GameManager.Instance.M_MainGameEvent.CallFireworkSpawnEvent.AddListener(() => { CallSpawnSoundEffect(2); });
        GameManager.Instance.M_MainGameEvent.ExitFeverTimeEvent.AddListener(() => { CallSpawnSoundEffect(1); });
    }
    public void CallSpawnSoundEffect(int Id)
    {
        var SEObject = audioSourcePool_.GetGameObject(SEPrefeab, transform.position, Quaternion.identity);
        var clip = DataBaseCenter.Instance.SoundEffectDataBase.GetSoundEffectByID(Id);
        SEObject.GetComponent<AudioSource>().clip = clip.Clip;
        SEObject.GetComponent<AudioSource>().Play();
        var destroyer = SEObject.GetComponent<PoolObjectDestroyer>();
        destroyer.Pool = audioSourcePool_;//加入自毀器
        destroyer.StartDestroyTimer(20f);
    }
}
