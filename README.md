# 택배왔냥 (Cat Delivery)

<img width="224" height="217" alt="택배왔냥 로고" src="https://github.com/user-attachments/assets/d4a0e658-94af-4106-bb5c-420a21e5e3c6" />


> **고양이 테마의 소코반 퍼즐 게임** 🎮  
> 방꾸미기와 퀘스트 시스템을 결합한 Unity 2D 게임

## 📑 목차

- [📋 프로젝트 소개](#-프로젝트-소개)
- [✨ 핵심기능 요약](#-핵심기능-요약)
  - [🧩 소코반 퍼즐 게임](#-소코반-퍼즐-게임)
  - [🏠 방꾸미기 시스템](#-방꾸미기-시스템)
  - [🎯 퀘스트 & 진행도 관리](#-퀘스트--진행도-관리)
  - [🖼️ UI 프레임워크](#️-ui-프레임워크)
- [🛠️ 기술스택/구조](#️-기술스택구조)
  - [플랫폼 & 엔진](#플랫폼--엔진)
  - [아키텍처 패턴](#아키텍처-패턴)
  - [핵심 디자인 패턴](#핵심-디자인-패턴)
- [🔧 구현 내용/챌린지](#-구현-내용챌린지)
  - [Challenge 1: 타일맵은 어떻게 그려질까?](#-challenge-1-타일맵은-어떻게-그려질까)
    - [CSV 파일 형식을 선택한 이유](#csv-파일-형식을-선택한-이유)
  - [Challenge 2: 확장 가능한 가구 관리 시스템](#-challenge-2-확장-가능한-가구-관리-시스템)
  - [Challenge 3: 복잡한 게임 데이터 영속성](#-challenge-3-복잡한-게임-데이터-영속성)
  - [Challenge 4: 생산성 높은 UI 개발 환경](#️-challenge-4-생산성-높은-ui-개발-환경)

<br>

## 📋 프로젝트 소개

**택배왔냥**은 귀여운 고양이가 주인공인 소코반 퍼즐 게임입니다. 
플레이어는 고양이를 조작하여 택배 상자를 올바른 위치에 밀어넣는 퍼즐을 해결하고, 
얻은 보상으로 고양이의 방을 꾸밀 수 있습니다.

프로젝트 상세 페이지 :  [https://www.notion.so/f5c855cd75e34b1c9861fd7f16df6a5f](https://cypress-screw-800.notion.site/f5c855cd75e34b1c9861fd7f16df6a5f?source=copy_link)

### 🎯 주요 목표
- **직관적인 퍼즐 게임플레이** 제공
- **방꾸미기 컨텐츠**를 통한 플레이 동기 부여  
- **퀘스트 시스템**으로 장기적인 목표 설정
- **확장 가능한 아키텍처** 구현

<br>

## ✨ 핵심기능 요약

### 🧩 소코반 퍼즐 게임
- 2단계 충돌 검사 시스템을 통한 정교한 게임 로직
- CSV 파일 기반 동적 스테이지 로딩
- 그리드 기반 타일맵 시스템

### 🏠 방꾸미기 시스템
- 20여 종의 이상의 가구 아이템 수집 및 배치
- 실시간 상점 인터페이스
- 인덱스 기반 인벤토리 관리

### 🎯 퀘스트 & 진행도 관리
- JSON 기반 퀘스트 저장/로드 시스템
- 싱글톤 패턴 기반 전역 상태 관리
- 활성/완료 퀘스트 분리 관리

### 🖼️ UI 프레임워크
- 제네릭 기반 자동 바인딩 시스템
- Enum 기반 타입 안전한 UI 관리
- 추상 클래스를 활용한 일관된 UI 패턴

<br>

## 🛠️ 기술스택/구조

### **플랫폼 & 엔진**
- `Unity 2021.x` - 게임 엔진
- `C# 9.0` - 프로그래밍 언어
- `JSON.NET` - 데이터 직렬화

### **아키텍처 패턴**
```
📁 Core Systems
├── 🎮 Game Logic (소코반 로직)
│   ├── ButtonManager.cs - 플레이어 입력 처리
│   ├── SokobanManager.cs - 게임 규칙 관리  
│   └── MapManager.cs - 타일맵 & 좌표 시스템
│
├── 💾 Data Management (데이터 관리)
│   ├── GameManagerR.cs - 게임 데이터 통합 관리
│   ├── CSVReader.cs - 맵 데이터 파싱
│   └── DataManager.cs - 저장/로드 시스템
│
├── 🎯 Quest System (퀘스트)
│   ├── QuestSystem.cs - 싱글톤 퀘스트 매니저
│   ├── Quest.cs - 퀘스트 기본 클래스
│   └── QuestSaveData.cs - 저장 데이터 구조
│
└── 🖼️ UI Framework (UI 프레임워크)
    ├── UI_Base.cs - 제네릭 바인딩 시스템
    ├── Utils.cs - 유틸리티 함수
    └── EnumManager.cs - 타입 정의
```

### **핵심 디자인 패턴**
- **싱글톤 패턴**: 전역 매니저 시스템 (MapManager, QuestSystem)
- **인터페이스 패턴**: 확장 가능한 스테이지 구조
- **제네릭 패턴**: 타입 안전한 UI 바인딩
- **커맨드 패턴**: 플레이어 액션 처리

<br>

## 🔧 구현 내용/챌린지

### **Challenge 1: 타일맵은 어떻게 그려질까?**

소코반 게임의 타일맵은 크게 플레이어의 이동 가능 여부를 기준으로 구분됩니다.
또한, 이동 가능 여부에 따라 초기 상자의 위치, 그리고 상자를 옮겨 놓아야 하는 목표 지점등의 특성이 결정됩니다.
따라서 각 타일은 단순한 배경 요소가 아니라, 플레이어 이동 및 게임 규칙에 직접적으로 영향을 미치는 데이터 단위로 정의되어야 합니다.

이러한 특성을 반영하기 위해, 스테이지의 타일 정보는 엑셀(CSV) 파일 형태로 관리하고 있습니다.
게임 실행 시 해당 CSV 파일을 불러와 2차원 배열로 파싱한 뒤, 배열 값에 따라 타일맵을 동적으로 생성하는 구조를 채택했습니다.

예를 들어 스테이지 3의 타일 정보를 이런 형태로 저장하다고 했을 때 

|csv 파일 형식 | 인게임 |
|---|---|
| <img src="https://github.com/user-attachments/assets/085e372a-8776-4312-8ba2-ed53abbd5362" width="600" /> | <img src="https://github.com/user-attachments/assets/e74c1844-6d0b-4b7a-81c4-a705adc37539" width="300" /> |

CSV 파일에 정의된 데이터는 그대로 2차원 배열로 변환되어 게임 내 타일맵으로 매핑되며, 결과적으로 위와 같이 인게임 화면에서 동일한 스테이지 구조가 재현됩니다.

### csv 파일 형식을 선택한 이유

CSV 파일을 스테이지 데이터 저장 형식으로 채택한 이유는 여러 가지가 있습니다.

우선 CSV는 기본적으로 각 데이터가 쉼표(,)로 구분되기 때문에, 파일을 읽어올 때 행과 열 단위로 쉽게 분리할 수 있습니다. 이를 코드에 반영하면 2차원 배열 형태의 타일맵을 직관적으로 구성할 수 있어 별도의 복잡한 파싱 과정이 필요하지 않습니다.

또한 텍스트 기반 포맷이기 때문에 스테이지 구조를 직관적으로 확인할 수 있으며, 엑셀이나 구글 시트 같은 일반적인 도구에서도 손쉽게 편집할 수 있습니다. 덕분에 개발자뿐 아니라 레벨 디자이너 역시 별도의 전용 툴 없이도 곧바로 수정할 수 있다는 장점이 있습니다.

마지막으로 CSV는 별도의 메타데이터나 불필요한 포맷 정보가 없어 파일 크기가 작고, 다양한 프로그래밍 언어와 라이브러리에서 기본적으로 지원됩니다. 이러한 특성은 추후 스테이지 확장이나 다른 플랫폼으로의 이식 과정에서도 높은 호환성을 보장합니다.

---

### 🏠 **Challenge 2: 방꾸미기 시스템, 어떻게 확장 가능하게 만들까?**

소코반 퍼즐을 해결하면서 얻은 보상으로 고양이의 방을 꾸미는 것이 게임의 핵심 재미 중 하나입니다. 
하지만 단순히 가구를 배치하는 것을 넘어서, 플레이어가 수집한 가구들을 체계적으로 관리하고, 상점에서의 구매 상태를 실시간으로 반영하며, 향후 새로운 가구가 추가되어도 코드 수정 없이 확장 가능한 시스템을 구축하는 것이 과제였습니다.

### 가구 데이터 구조의 딜레마

초기에는 가구 정보를 단순한 문자열 배열이나 정수 ID로만 관리하려 했습니다. 하지만 이 방식은 몇 가지 문제점이 있었습니다:

1. **타입 안전성 부족**: 잘못된 ID를 전달해도 컴파일 타임에 발견할 수 없음
2. **가독성 저하**: 숫자 ID만으로는 어떤 가구인지 직관적으로 알기 어려움  
3. **확장성 한계**: 새로운 가구 추가 시마다 여러 곳의 코드를 수정해야 함

### Enum 기반 타입 안전 시스템 도입

이러한 문제를 해결하기 위해 Enum을 활용한 타입 안전 시스템을 도입했습니다:

```csharp
public enum eStage1List
{
    None,
    f1_침대,
    f1_의자, 
    책상,
    바닥,
    벽지,
    창문,
    책장,
    시계,
    화분,
    /* ... 총 20여 종 */
    Max
}
```

이 구조의 장점은 다음과 같습니다:

- **컴파일 타임 검증**: 존재하지 않는 가구 타입 사용 시 즉시 컴파일 에러 발생
- **IntelliSense 지원**: IDE에서 자동 완성으로 사용 가능한 가구 목록 확인 가능
- **리팩토링 안전성**: Enum 이름 변경 시 모든 참조가 자동으로 업데이트

### 중복 구매 방지 알고리즘

가구 인벤토리에서 가장 중요한 것은 중복 구매를 방지하는 것입니다. 같은 가구를 여러 번 구매할 수 없도록 하는 검증 로직을 구현했습니다:

```csharp
public void AddFuniture(int furnitureId)
{
    // 이미 소유한 가구인지 선형 검색으로 확인
    for (int i = 0; i < furniture.Count; i++)
    {
        if (furniture[i] == furnitureId)
        {
            Debug.Log("이미 소유한 가구입니다!");
            return; // 중복 방지
        }
    }
    
    // 새로운 가구 추가
    furniture.Add(furnitureId);
    Debug.Log($"가구 {furnitureId} 구매 완료!");
}
```

### 실시간 상점 UI 동기화

구매한 가구는 즉시 상점 UI에 반영되어야 합니다. 이를 위해 GameObject 배열과 Boolean 배열을 활용한 상태 관리 시스템을 구축했습니다:

```csharp
public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject[] _stage1Furniture;     // 가구 UI 오브젝트
    [SerializeField] GameObject[] _soldOutIndicators;   // 품절 표시 UI
    public bool[] _purchaseStates;                      // 구매 상태 배열
    
    void UpdateShopUI()
    {
        for(int i = 0; i < _stage1Furniture.Length; i++)
        {
            bool isPurchased = Managers.Game.SaveData.FindFuniture(i);
            
            _stage1Furniture[i].SetActive(!isPurchased);      // 구매 안함: 활성화
            _soldOutIndicators[i].SetActive(isPurchased);     // 구매함: 품절 표시
        }
    }
}
```

### 확장성을 고려한 설계

새로운 가구를 추가할 때는 다음 3단계만 거치면 됩니다:

1. **Enum에 새 항목 추가**
2. **프리팹 배열에 해당 가구 오브젝트 추가**  
3. **가격 정보를 별도 클래스에 정의**

```csharp
public class stage1Price
{
    public int 침대 = 21;
    public int 의자 = 12;
    public int 책상 = 15;
    // 새 가구 추가 시 여기에 한 줄만 추가하면 됨
    public int 새가구 = 30;
}
```

### 성과

이러한 구조를 통해 다음과 같은 성과를 달성했습니다:

- **100% 중복 방지**: 동일 가구 중복 구매 완전 차단
- **실시간 UI 동기화**: 구매 즉시 상점 UI 상태 변경  
- **확장성 확보**: 새 가구 추가 시 기존 코드 수정 최소화
- **타입 안전성**: 컴파일 타임 에러 검출로 런타임 버그 방지

결과적으로 20여 종의 가구를 체계적으로 관리하면서도, 향후 50종, 100종으로 확장해도 안정적으로 동작할 수 있는 기반을 마련했습니다.

---

### 💾 **Challenge 3: 게임 데이터 저장, 어떻게 안전하게 관리할까?**

택배왔냥은 퍼즐 해결 진행도, 수집한 가구 정보, 완료한 퀘스트, 게임 설정 등 다양한 데이터를 관리해야 합니다. 특히 플레이어가 게임을 종료했다가 다시 실행해도 모든 진행 상황이 그대로 유지되어야 하고, 씬 전환 과정에서도 데이터가 손실되지 않아야 합니다.

### 초기 데이터 저장 방식의 한계

처음에는 각 시스템별로 개별적인 저장 방식을 사용했습니다:

- 게임 진행도: `PlayerPrefs.SetInt("Stage", currentStage)`
- 가구 인벤토리: `PlayerPrefs.SetString("Furniture", furnitureString)`  
- 사운드 설정: `PlayerPrefs.SetBool("BGM", bgmEnabled)`

하지만 이 방식은 여러 문제점이 있었습니다:

1. **데이터 일관성 부족**: 각 시스템이 독립적으로 저장하다 보니 동기화 문제 발생
2. **복잡한 구조 표현 불가**: 퀘스트처럼 여러 필드를 가진 복잡한 객체 저장 어려움
3. **확장성 한계**: 새로운 데이터 타입 추가 시마다 저장 로직 재작성 필요

### JSON 기반 통합 저장 시스템 도입

이러한 문제를 해결하기 위해 JSON 직렬화를 활용한 통합 저장 시스템을 구축했습니다.

#### 퀘스트 시스템의 복잡한 데이터 구조

퀘스트는 단순한 숫자나 문자열이 아닌 복잡한 구조를 가집니다:

```csharp
public struct QuestSaveData
{
    public string codeName;        // 퀘스트 고유 식별자
    public QuestState state;       // 진행 상태 (활성, 완료, 취소)
    public int taskGroupIndex;     // 현재 태스크 그룹
    public int[] taskSuccessCounts; // 각 태스크별 진행도
}
```

이런 구조화된 데이터를 JSON으로 저장하면 다음과 같은 형태가 됩니다:

```json
{
  "activeQuests": [
    {
      "codeName": "collectFurniture",
      "state": 1,
      "taskGroupIndex": 0,
      "taskSuccessCounts": [3, 0, 0]
    }
  ],
  "completedQuests": [
    {
      "codeName": "firstStage",
      "state": 2,
      "taskGroupIndex": 1,
      "taskSuccessCounts": [1]
    }
  ]
}
```

#### 저장/로드 프로세스 구현

```csharp
public void Save()
{
    var root = new JObject();
    
    // 활성 퀘스트와 완료 퀘스트를 분리하여 저장
    root.Add("activeQuests", CreateSaveDatas(activeQuests));
    root.Add("completedQuests", CreateSaveDatas(completedQuests));
    root.Add("activeAchievements", CreateSaveDatas(activeAchievements));
    root.Add("completedAchievements", CreateSaveDatas(completedAchievements));

    // 단일 문자열로 직렬화하여 PlayerPrefs에 저장
    PlayerPrefs.SetString("questSystem", root.ToString());
    PlayerPrefs.Save();
}

private JArray CreateSaveDatas(IReadOnlyList<Quest> quests)
{
    var saveDatas = new JArray();
    foreach (var quest in quests)
    {
        if (quest.IsSavable)  // 저장 가능한 퀘스트만 선별
            saveDatas.Add(JObject.FromObject(quest.ToSaveData()));
    }
    return saveDatas;
}
```

### 싱글톤 패턴으로 전역 접근성 확보

게임의 모든 곳에서 퀘스트 데이터에 접근할 수 있도록 싱글톤 패턴을 적용했습니다:

```csharp
public static QuestSystem Instance
{
    get
    {
        if (!isApplicationQuitting && instance == null)
        {
            instance = FindObjectOfType<QuestSystem>();
            if (instance == null)
            {
                // 인스턴스가 없으면 자동으로 생성
                instance = new GameObject("Quest System").AddComponent<QuestSystem>();
                DontDestroyOnLoad(instance.gameObject);
            }
        }
        return instance;
    }
}
```

### 씬 전환 간 데이터 지속성 보장

Unity에서 씬이 전환될 때 기본적으로 모든 GameObject가 파괴됩니다. 하지만 퀘스트 데이터는 게임 전반에 걸쳐 유지되어야 하므로 `DontDestroyOnLoad()`를 사용하여 씬 전환에도 살아남도록 했습니다.

```csharp
private void Awake()
{
    // 데이터베이스 로드
    questDatabase = Resources.Load<QuestDatabase>("QuestDatabase");
    achievementDatabase = Resources.Load<QuestDatabase>("AchievementDatabase");
    
    // 저장된 데이터 복원 시도
    if (!Load())
    {
        // 저장된 데이터가 없으면 초기 업적 등록
        foreach (var achievement in achievementDatabase.Quests)
        {
            Register(achievement);
        }
    }
}
```

### 데이터 무결성 검증

로드 과정에서 데이터 무결성을 검증하는 로직도 추가했습니다:

```csharp
private void LoadSaveDatas(JToken datasToken, QuestDatabase database, System.Action<QuestSaveData, Quest> onSuccess)
{
    var datas = datasToken as JArray;
    foreach (var data in datas)
    {
        var saveData = data.ToObject<QuestSaveData>();
        var quest = database.FindQuestBy(saveData.codeName);
        
        if (quest != null)  // 유효한 퀘스트인지 확인
        {
            onSuccess.Invoke(saveData, quest);
        }
        else
        {
            Debug.LogWarning($"Unknown quest: {saveData.codeName}");
        }
    }
}
```

### 성과

이러한 JSON 기반 저장 시스템을 통해 다음과 같은 성과를 달성했습니다:

- **100% 데이터 복원**: 게임 종료 후 재실행 시 모든 진행 상황 완벽 복원
- **구조화된 저장**: 복잡한 객체도 안전하게 직렬화/역직렬화
- **확장성**: 새로운 데이터 타입 추가 시 기존 저장 로직 재사용 가능
- **무결성 보장**: 잘못된 데이터 로드 시 안전하게 처리

결과적으로 플레이어는 언제 게임을 종료하고 재시작해도 끊김 없는 게임 경험을 누릴 수 있게 되었습니다.

---

### 🖼️ **Challenge 4: UI 개발, 어떻게 효율적으로 할까?**

택배왔냥에는 메인 메뉴, 스테이지 선택, 옵션 창, 상점, 인벤토리 등 다양한 UI 화면이 있습니다. 각 화면마다 수십 개의 버튼, 텍스트, 이미지 등의 UI 요소들을 코드에서 참조해야 하는데, 기존의 Unity 방식으로는 매번 반복적인 바인딩 작업을 해야 했습니다.

### 전통적인 UI 바인딩의 문제점

Unity에서 UI 요소를 사용하려면 보통 다음과 같은 과정을 거칩니다:

```csharp
public class TraditionalUI : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button optionButton;
    [SerializeField] Button quitButton;
    [SerializeField] Text titleText;
    [SerializeField] Text versionText;
    [SerializeField] Image backgroundImage;
    [SerializeField] Image logoImage;
    
    void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
        optionButton.onClick.AddListener(OnOptionClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
        // ... 더 많은 바인딩 코드
    }
}
```

이 방식의 문제점들:

1. **수작업 드래그&드롭**: 각 UI 요소를 인스펙터에서 일일이 드래그해서 연결해야 함
2. **오타 가능성**: 변수명과 실제 오브젝트 이름이 달라도 컴파일 타임에 발견 불가
3. **확장성 부족**: UI 요소가 추가될 때마다 변수 선언 → 인스펙터 연결 → 초기화 코드 추가
4. **유지보수 어려움**: UI 구조 변경 시 여러 곳의 코드를 수정해야 함

### Enum 기반 자동 바인딩 시스템 설계

이러한 문제를 해결하기 위해 Enum과 제네릭을 조합한 자동 바인딩 시스템을 설계했습니다.

#### 1단계: UI 요소를 Enum으로 정의

```csharp
// 메인 메뉴 UI의 버튼들
enum MainMenuButtons
{
    StartBtn,
    OptionBtn, 
    QuitBtn,
    ShopBtn
}

// 메인 메뉴 UI의 텍스트들
enum MainMenuTexts  
{
    TitleText,
    VersionText,
    PlayerNameText
}
```

#### 2단계: 제네릭 바인딩 메서드 구현

```csharp
protected void Bind<T>(Type enumType) where T : UnityEngine.Object
{
    string[] names = Enum.GetNames(enumType);
    UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
    _objects.Add(typeof(T), objects);

    for (int i = 0; i < names.Length; i++)
    {
        if (typeof(T) == typeof(GameObject))
            objects[i] = Utils.FindChild(gameObject, names[i], true);
        else
            objects[i] = Utils.FindChild<T>(gameObject, names[i], true);

        if (objects[i] == null)
            Debug.LogWarning($"Failed to bind({names[i]})");
    }
}
```

#### 3단계: 편의 메서드 제공

```csharp
// 타입별 바인딩 편의 메서드
protected void BindButton(Type type) { Bind<Button>(type); }
protected void BindText(Type type) { Bind<TextMeshProUGUI>(type); }
protected void BindImage(Type type) { Bind<Image>(type); }

// 타입별 접근 편의 메서드  
protected Button GetButton(int idx) { return Get<Button>(idx); }
protected TextMeshProUGUI GetText(int idx) { return Get<TextMeshProUGUI>(idx); }
protected Image GetImage(int idx) { return Get<Image>(idx); }
```

### 실제 사용 예시

이제 UI 클래스에서는 다음과 같이 간단하게 사용할 수 있습니다:

```csharp
public class MainMenuUI : UI_Base
{
    enum Buttons { StartBtn, OptionBtn, QuitBtn, ShopBtn }
    enum Texts { TitleText, VersionText, PlayerNameText }
    enum Images { BackgroundImg, LogoImg }

    public override bool Init()
    {
        if (base.Init() == false) return false;

        // 한 줄로 모든 UI 요소 바인딩 완료!
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));  
        BindImage(typeof(Images));

        // 타입 안전한 접근
        GetButton((int)Buttons.StartBtn).onClick.AddListener(OnStartClicked);
        GetButton((int)Buttons.OptionBtn).onClick.AddListener(OnOptionClicked);
        
        GetText((int)Texts.TitleText).text = "택배왔냥";
        GetText((int)Texts.VersionText).text = "v1.0.0";

        return true;
    }
}
```

### Utils.FindChild 구현

자동 바인딩의 핵심인 `FindChild` 메서드도 재귀 검색을 지원하도록 구현했습니다:

```csharp
public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
{
    if (go == null) return null;

    if (recursive == false)
    {
        Transform transform = go.transform.Find(name);
        if (transform != null)
            return transform.GetComponent<T>();
    }
    else
    {
        // 재귀적으로 모든 자식 오브젝트 검색
        foreach (T component in go.GetComponentsInChildren<T>())
        {
            if (string.IsNullOrEmpty(name) || component.name == name)
                return component;
        }
    }
    return null;
}
```

### 추상 클래스 기반 일관된 패턴

모든 UI 클래스가 동일한 패턴을 따르도록 추상 클래스를 제공합니다:

```csharp
public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    protected bool _init = false;

    public virtual bool Init()
    {
        if (_init) return false;
        
        Managers.Init();
        _init = true;
        return true;
    }

    private void Start()
    {
        Init(); // 자동 초기화
    }
}
```


<br>
