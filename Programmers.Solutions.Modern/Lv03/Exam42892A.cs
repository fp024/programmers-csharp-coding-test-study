namespace Programmers.Solutions.Modern.Lv03;

/*
  길 찾기 게임 - 42892
  - 이진 트리 생성 / 전위 순회 / 후위 순회를 반복으로 구현
*/
public static class Exam42892A
{
    /// <summary>
    /// 이진 트리의 노드
    /// </summary>
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

    /// <summary>
    /// 주어진 노드 데이터를 사용하여 이진 트리를 생성하고, 생성된 트리를 전위 순회와 후위 순회한 결과를 반환합니다.
    /// </summary>
    /// <param name="nodeInfo">노드들의 좌표 정보를 포함한 2차원 배열. 배열의 각 행은 [x, y] 형태로 노드의 좌표를 나타냅니다.</param>
    /// <returns>2차원 배열로, 첫 번째 행은 전위 순회 결과이고 두 번째 행은 후위 순회 결과입니다.</returns>
    public static int[][] Solution(int[][] nodeInfo)
    {
        var nodes = nodeInfo
            .Select((info, i) => new Node(i + 1, info[0], info[1]))
            .OrderByDescending(node => node.Y)
            .ToArray();

        var root = ConstructTree(nodes);

        var preorder = new List<int>();
        Pre(root, preorder);

        var postorder = new List<int>();
        Post(root, postorder);

        return [preorder.ToArray(), postorder.ToArray()];
    }

    /// <summary>
    /// 주어진 노드 리스트를 사용하여 이진 트리를 구성합니다.
    /// </summary>
    /// <param name="nodes">노드의 배열로, 각 노드는 X와 Y 좌표값을 포함하고 있습니다.</param>
    /// <returns>구성된 이진 트리의 루트 노드.</returns>
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

    private sealed class PostOrderStackFrame
    {
        private Node Node { get; }
        private bool Visited { get; }

        internal PostOrderStackFrame(Node node, bool visited)
        {
            Node = node;
            Visited = visited;
        }

        internal void Deconstruct(out Node node, out bool visited)
        {
            node = Node;
            visited = Visited;
        }
    }

    /// <summary>
    /// 후위 순회 L -> R -> P
    /// </summary>
    /// <param name="rootNode">현재 노드</param>
    /// <param name="visits">방문 노드 저장용도 리스트</param>
    private static void Post(Node rootNode, List<int> visits)
    {
        var stack = new Stack<PostOrderStackFrame>();
        stack.Push(new PostOrderStackFrame(rootNode, false));

        while (stack.Count > 0)
        {
            var (currentNode, visited) = stack.Pop();

            if (visited)
            {
                visits.Add(currentNode.Value);
            }
            else
            {
                stack.Push(new PostOrderStackFrame(currentNode, true));

                if (currentNode.Right != null)
                {
                    stack.Push(new PostOrderStackFrame(currentNode.Right, false));
                }

                if (currentNode.Left != null)
                {
                    stack.Push(new PostOrderStackFrame(currentNode.Left, false));
                }
            }
        }
    }
}
