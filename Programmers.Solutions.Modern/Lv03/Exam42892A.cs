namespace Programmers.Solutions.Modern.Lv03;

/*
  길 찾기 게임 - 42892
  - 이진 트리 생성 / 전위 순회 / 후위 순회를 반복으로 구현
*/
public static class Exam42892A
{
    private sealed class Node
    {
        internal int Value { get; }
        internal int X { get; }
        internal int Y { get; }

        internal Node? Left { get; set; }
        internal Node? Right { get; set; }

        internal Node(int value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
    }

    public static int[][] Solution(int[][] nodeInfo)
    {
        var nodes = new Node[nodeInfo.Length];

        for (var i = 0; i < nodeInfo.Length; i++)
        {
            nodes[i] = new Node(i + 1, nodeInfo[i][0], nodeInfo[i][1]);
        }

        Array.Sort(nodes, (a, b) => b.Y.CompareTo(a.Y));

        var root = ConstructTree(nodes);

        var preorder = new List<int>();
        Pre(root, preorder);

        var postorder = new List<int>();
        Post(root, postorder);

        return [preorder.ToArray(), postorder.ToArray()];
    }

    private static Node ConstructTree(Node[] nodes)
    {
        var root = nodes[0];

        for (var i = 1; i < nodes.Length; i++)
        {
            Insert(root, nodes[i]);
        }

        return root;
    }

    /// <summary>
    /// 노드 삽입
    /// </summary>
    /// <param name="rootNode">루트 노드</param>
    /// <param name="newNode">추가할 신규 노드</param>
    private static void Insert(Node rootNode, Node newNode)
    {
        var parentNode = rootNode;

        while (true)
        {
            if (parentNode.X > newNode.X)
            {
                if (parentNode.Left == null)
                {
                    parentNode.Left = newNode;
                    break;
                }

                parentNode = parentNode.Left;
            }
            else if (parentNode.X < newNode.X)
            {
                if (parentNode.Right == null)
                {
                    parentNode.Right = newNode;
                    break;
                }

                parentNode = parentNode.Right;
            }
        }
    }

    /// <summary>
    /// 전위 순회  P -> L -> R
    /// </summary>
    /// <param name="rootNode">루트 노드</param>
    /// <param name="visits">방문 노드 저장용도 리스트</param>
    private static void Pre(Node rootNode, List<int> visits)
    {
        var stack = new Stack<Node>();
        stack.Push(rootNode);

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();
            visits.Add(currentNode.Value);

            if (currentNode.Right != null)
            {
                stack.Push(currentNode.Right);
            }

            if (currentNode.Left != null)
            {
                stack.Push(currentNode.Left);
            }
        }
    }

    private static void Post(Node? node, List<int> visits)
    {
        if (node == null)
        {
            return;
        }

        Post(node.Left, visits);
        Post(node.Right, visits);
        visits.Add(node.Value);
    }
}
