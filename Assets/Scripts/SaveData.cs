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
public class SaveDataV1 : SaveData // 이름들이 다 달라야함. 직렬화 역직렬화와 관련
                                   // 새로운 버전이 나오면 새로운 클래스를 만들어서 추가하는 형태??
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
    public int Gold; //이전버전 필드 없어졌다 가정, 새로운필드로 만듦
    public string Name { get; set; } = string.Empty; 
    public SaveDataV2()
    {
        Version = 2;
    }

    public override SaveData VersionUp() // 이전클래스의 버전업 메소드를 바꿔줘야함 //파일이 갱신되려면 세이브버튼을 눌러야 파일이 갱신됨.
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
