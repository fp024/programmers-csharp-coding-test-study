# 프로그래머스 C# 코딩 테스트 - 스터디

> 코딩 테스트 연습을 JS/TS, Java, C++, Python 환경에서 가끔씩 😅 하고 있었는데, 
> C#으로도 한번 만들어보고 싶어서 만들었다.
>
> 최근에 C# 기본서 초반만 보았는데, 뭔가 .NET 환경이 프로젝트 및 테스트 프로젝트 만드는데 
> 쉽고 체계적인 것을 느끼게 되서 코딩 테스트 프로젝트를 만들어보고 싶었다.
>
> * JS/TS
>   * https://github.com/fp024/programmers-js-coding-test-study
>
> * Java
>   * https://github.com/fp024/programmers-java-coding-test-study
> * C++
>   * https://github.com/fp024/programmers-c-coding-test-study
> * Python
>   * https://github.com/fp024/programmers-python-coding-test-study
>
>



## 스터디 프로젝트  구성

### 프로젝트 구조

```
Programmers.CSharp.Coding.Study/
├── 🔧 설정 파일
│   ├── .editorconfig              # 코드 스타일 설정
│   ├── .gitignore                 # Git 제외 파일
│   ├── cspell.config.yaml         # 맞춤법 검사 설정
│   ├── NuGet.Config               # NuGet 패키지 소스
│   └── README.md                  # 프로젝트 설명
│
├── 📂 .vscode/                    # VS Code 작업 공간 설정
│   ├── extensions.json            # 권장 확장 프로그램
│   └── settings.json              # 워크스페이스 설정
│
├── 📦 Programmers.Solutions/      # 메인 솔루션 프로젝트
│   ├── Programmers.Solutions.csproj
│   └── Lv03/
│       └── Exam42892.cs          # 레벨 3 문제
│
└── 🧪 Programmers.Solutions.tests/ # 테스트 프로젝트
    ├── Programmers.Solutions.tests.csproj
    └── Lv03/
        └── Exam42892Tests.cs     # 레벨 3 테스트
```

## 개발 도구

### .NET SDK 설치

* **9.0**
  * https://dotnet.microsoft.com/ko-kr/download/dotnet/9.0

프로그래머스의 C# 컴파일러가 **Mono C# Compiler 6.10.0** 인데, C# 8.0 RC 대응이다. (부분지원?) .

NET SDK는 현시점의 최신으로 사용하면서, 문제풀이 프로젝트는 C# 7.0으로 언어 버전을 낮춰서 쓰고,

테스트 프로젝트만 버전 제한 없이 설치된 SDK가 제공하는 C#  버전을 사용하도록 하자. 

> .NET 9.0이면 C# 13 버전이다.



### VSCode

* https://code.visualstudio.com/

> Python도 지원이 좋았지만, C#도 만만치 않다 MS에서 나온 언어이니 당연히 좋아야겠지만..😊
>
> * C# Dev Kits
>   * https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit



### Rider

* https://www.jetbrains.com/ko-kr/rider/
  * Rider면 다 된다고 함 👍 Windows Forms의 위지윅 개발도 되는 것 같음.





## 디펜던시 관리자 (NuGet)

.NET SDK에 포함되어있음.

테스트 프로젝트를 만들 때도, MSBuild나 xUnit 프로젝트로 별도로 만들 때, 그냥 디펜던시가 추가되고,

특별한 라이브러리를 추가할 일도 없을 것 같아서, 따로 디펜던시 관리 관련해서는 따로 할일이 없을 것 같다.






## 단위 테스트 프레임워크

Java와는 다르게 src/test에다 한 프로젝트에 테스트 코드를 만들지 않고, 

타겟 프로젝트에 대한 테스트 전용 프로젝트를 만들어서 테스트 코드를 추가함.

JUnit과 가장 비슷한게 xUnit 기반 프로젝트라고 해서 그걸로 만들기로 함.





## 코드 포맷터

VSCode나 Rider나 .editorconfig 인식한다고해서 해당 파일 만듬.

* VSCode에서는 포멧터를 C# Dev Kits으로 지정하더라도 editorconfig 인식한다고함.

  

