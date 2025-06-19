using UnityEngine;
using UnityEngine.Rendering;

public enum BGMSound
{
    Main,
    Map1,
    TraingMap,
    Map2
}
public enum SFXSound
{
    Ready,
    ReadyGo,
    Motor,
    Drift,
    Booster
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] static GameObject _BGMManager;
    [SerializeField] static GameObject _SFXManager;

    static public SoundManager _sound;

    [SerializeField] AudioClip[] _bgmClip;
    [SerializeField] AudioClip[] _sfxClip;
    static AudioSource _audioBgmSource;
    static AudioSource _audioSfxSource;

    public float bgmVolume = 0.7f;
    public float sfxVolume = 0.7f;

    static void Init()
    {
        if (_sound == null)
        {
            GameObject gm = GameObject.Find("SoundManager");
            if (gm == null)
            {
                gm = new GameObject { name = "SoundManager" };

                gm.AddComponent<SoundManager>();
            }
            DontDestroyOnLoad(gm);
            _sound = gm.GetComponent<SoundManager>();

            _BGMManager = GameObject.Find("BGMManager");
            _SFXManager = GameObject.Find("SFXManager");
            _audioBgmSource = _BGMManager.GetComponent<AudioSource>();
            _audioSfxSource = _SFXManager.GetComponent<AudioSource>();
        }
    }
    void Awake()
    {
        Init();
    }

    //�ӽ� ����
    private void Start()
    {
        //ó������ �����ױ��� ����
        PlayBGM(0);
    }

    void Update()
    {
        _audioBgmSource.volume = bgmVolume;
        _audioSfxSource.volume = sfxVolume;
    }
    public void PlayBGM(int musicNum)
    {
        _audioBgmSource.clip = _bgmClip[musicNum];
        _audioBgmSource.volume = bgmVolume;//��� �����ǰ� �ٱ����� ��
        _audioBgmSource.loop = true;
        _audioBgmSource.Play();
    }
    public void StopBGM(int musicNum)
    {
        _audioBgmSource.clip = _bgmClip[musicNum];
        if (_audioBgmSource.isPlaying)
        {
            _audioBgmSource.Stop();
        }
    }
    public void PlaySfx(int soundNum)
    {
        _audioSfxSource.volume = sfxVolume;//���� ������ ����
        _audioSfxSource.playOnAwake = true;
        _audioSfxSource.loop = false;
        _audioSfxSource.PlayOneShot(_sfxClip[soundNum]);//�Ѱ��� ����
    }

    /// <summary>
    /// �� ���� bgm���
    /// ���� : �� �̵���
    /// </summary>
    public void MapBGMSetting(string prevMapName)
    {
        string playerCurMapname = PlayerManager.PlayerInstance.CurMapName;
        int curMapNum = MapAndProtalList.curMapNum;

        //������ ������?
        if (playerCurMapname.Substring(0,3) == prevMapName.Substring(0,3))
        {
            //Ŀ�׽�Ƽ�� ���
            if(MapManager.playerMapLocal == LocalMapName.KerningCity)
            {
                if (curMapNum == 21)
                {
                    PlayBGM(5);
                }
                else if (curMapNum > 21)
                    PlayBGM(6);
                else
                    PlayBGM(4);
            }
            else if(MapManager.playerMapLocal == LocalMapName.SleepyWood)
            {
                if (curMapNum <= 26)
                    PlayBGM(7);
                else if (curMapNum >= 29)
                    PlayBGM(9);
                else
                    PlayBGM(8);
            }
        }
        else//�ٸ��� �ٸ� bgm���
        {
            switch (MapManager.playerMapLocal)
            {
                case LocalMapName.LithHarbor:
                    PlayBGM(0);
                    break;
                case LocalMapName.Henesys:
                    PlayBGM(1);
                    break;
                case LocalMapName.Ellinia:
                    PlayBGM(2);
                    break;
                case LocalMapName.Perion:
                    PlayBGM(3);
                    break;
                case LocalMapName.KerningCity:
                    if(curMapNum == 21)
                    {
                        PlayBGM(5);
                    }else if (curMapNum>21)
                        PlayBGM(6);
                    else
                        PlayBGM(4);
                    break;
                case LocalMapName.SleepyWood:
                    if (curMapNum <=26)
                        PlayBGM(7);
                    else if (curMapNum >= 29)
                        PlayBGM(9);
                    else
                        PlayBGM(8);
                    break;
                default:
                    break;
            }
        }
    }
}
