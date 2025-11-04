namespace Programmers.Solutions.tests.Lv03;

using Programmers.Solutions.Lv03;

public class Exam42892Tests
{
    [Fact]
    public void Solution_Default_Test()
    {
        Assert.Equal(
            new Exam42892().Solution(
            [
                [5, 3],
                [11, 5],
                [13, 3],
                [3, 5],
                [6, 1],
                [1, 3],
                [8, 6],
                [7, 2],
                [2, 2]
            ])
            , [
                [7, 4, 6, 9, 1, 8, 5, 2, 3],
                [9, 6, 5, 8, 1, 4, 3, 2, 7]
            ]
        );
    }
}
