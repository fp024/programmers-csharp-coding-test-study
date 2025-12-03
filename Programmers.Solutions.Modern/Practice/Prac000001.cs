namespace Programmers.Solutions.Modern.Practice;

/// <summary>
/// Gemini가 출제한 문제: 단어 빈도 수 계산
///
/// 뭔가 힘들다..😂
/// </summary>
internal static class Prac000001
{
    public static Dictionary<string, int> Solutions(string s)
    {
        Dictionary<string, int> wordCountDict = new();

        for (var i = 0; i < s.Length; i++)
        {
            // 1. 구분자 (공백, 쉼표, 마침표) 건너 뛰기
            while (i < s.Length && (s[i] == ' ' || s[i] == ',' || s[i] == '.'))
            {
                i++;
            }

            if (i >= s.Length)
            {
                break;
            }

            // 2. 단어 시작 위치 기억
            var startIdx = i;

            // 3. 단어 끝 찾기
            while (i < s.Length && (s[i] != ' ' && s[i] != ',' && s[i] != '.'))
            {
                i++;
            }

            var lowerWord = s.Substring(startIdx, i - startIdx).ToLower();

            if (!wordCountDict.TryAdd(lowerWord, 1))
            {
                wordCountDict[lowerWord]++;
            }
        }

        return wordCountDict;
    }
}
