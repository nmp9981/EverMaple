using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public int questNum;//����Ʈ ��ȣ
    public int reqLv;//�䱸 ����
    public int questState = 0;//�� ����, 1:����, 2:������, 3:�Ϸ�, 4:Ŭ����

    public List<Sprite> stateSpriteList = new List<Sprite>();

    /// <summary>
    /// ����Ʈ ���� ���̱�
    /// </summary>
    public void ShowQuestState()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stateSpriteList[questState];
    }

}
