using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SaveData
{
    public int Version { get; protected set; }
    public abstract SaveData VersionUp();

}

[Serializable]
public class SaveDataV1 : SaveData // �̸����� �� �޶����. ����ȭ ������ȭ�� ����
                                   // ���ο� ������ ������ ���ο� Ŭ������ ���� �߰��ϴ� ����??
{
    public string PlayerName { get; set; } = string.Empty;
    public SaveDataV1()
    {
        Version = 1;
    }
    public override SaveData VersionUp()
    {
        var saveDataV2 = new SaveDataV2
        {
            Name = PlayerName,
            Gold = 0
        };
        return saveDataV2;
    }
}

[Serializable]
public class SaveDataV2 : SaveData
{
    public int Gold; //�������� �ʵ� �������� ����, ���ο��ʵ�� ����
    public string Name { get; set; } = string.Empty; 
    public SaveDataV2()
    {
        Version = 2;
    }

    public override SaveData VersionUp() // ����Ŭ������ ������ �޼ҵ带 �ٲ������ //������ ���ŵǷ��� ���̺��ư�� ������ ������ ���ŵ�.
    {
        var saveDataV3 = new SaveDataV3();
        //saveDataV3.Name = Name;
        //saveDataV3.Gold = Gold;
        return saveDataV3;
    }
}

[Serializable]
public class SaveDataV3 : SaveData
{
    public List<SaveItemData> saveItemDatas { get; set; }

    public SaveDataV3()
    {
        Version = 3;
    }
    public override SaveData VersionUp()
    {
        throw new NotImplementedException();
    }
}
