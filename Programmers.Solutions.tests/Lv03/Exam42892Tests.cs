namespace Programmers.Solutions.tests.Lv03;

using LegacyLv03 = Programmers.Solutions.Lv03;
using ModernLv03 = Programmers.Solutions.Modern.Lv03;

public class Exam42892Tests
{
    public record TestCase(int[][] NodeInfo, int[][] Expected);

#pragma warning disable xUnit1045
    // xUnit은 Test Explorer에서 각 테스트 케이스를 개별적으로 표시하기 위해 TheoryData<T>의 타입을 직렬화한다.
    // 그러나 레코드나 커스텀 타입은 직렬화 보장이 없어서 xUnit1045 경고가 발생함.
    // 💡 나는 테스트 데이터의 의미 있는 필드 이름 지정이 중요하므로, 경고는 무시하고 사용하자!
    public static TheoryData<TestCase> DefaultTestCases =>
    [
        new(
            NodeInfo: [[5, 3], [11, 5], [13, 3], [3, 5], [6, 1], [1, 3], [8, 6], [7, 2], [2, 2]],
            Expected: [[7, 4, 6, 9, 1, 8, 5, 2, 3], [9, 6, 5, 8, 1, 4, 3, 2, 7]]
        )
    ];


    [Theory]
    [MemberData(nameof(DefaultTestCases))]
    public void Solution_Legacy_Test(TestCase testCase)
    {
        Assert.Equal(testCase.Expected, new LegacyLv03.Exam42892().Solution(testCase.NodeInfo));
    }

    [Theory]
    [MemberData(nameof(DefaultTestCases))]
    public void Solution_Modern_Test(TestCase testCase)
    {
        Assert.Equal(testCase.Expected, ModernLv03.Exam42892.Solution(testCase.NodeInfo));
    }

    [Theory]
    [MemberData(nameof(DefaultTestCases))]
    public void Solution_Modern_Test_A(TestCase testCase)
    {
        Assert.Equal(testCase.Expected, ModernLv03.Exam42892A.Solution(testCase.NodeInfo));
    }
}
