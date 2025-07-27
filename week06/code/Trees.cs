using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int Value { get; private set; }
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public Node(int value)
    {
        Value = value;
    }

    public void Insert(int value)
    {
        if (value == Value)
            return;  // Problem 1: reject duplicates

        if (value < Value)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Value)
            return true;
        if (value < Value)
            return Left?.Contains(value) ?? false;
        else
            return Right?.Contains(value) ?? false;
    }

    public int GetHeight()
    {
        int leftH = Left?.GetHeight() ?? 0;
        int rightH = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftH, rightH);
    }
}

public class BinarySearchTree : IEnumerable<int>
{
    private Node? root;

    public void Insert(int value)
    {
        if (root == null)
            root = new Node(value);
        else
            root.Insert(value);
    }

    public bool Contains(int value)
        => root?.Contains(value) ?? false;

    public int GetHeight()
        => root?.GetHeight() ?? 0;

    public IEnumerable<int> Reverse()
    {
        var list = new List<int>();
        TraverseBackward(root, list);
        return list;
    }

    private void TraverseBackward(Node? node, IList<int> output)
    {
        if (node == null)
            return;
        TraverseBackward(node.Right, output);
        output.Add(node.Value);
        TraverseBackward(node.Left, output);
    }

    public override string ToString()
    {
        if (root == null)
            return "<Bst>{}";
        var list = this.ToList();
        return "<Bst>{" + string.Join(", ", list) + "}";
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (root != null)
            foreach (var v in TraverseForward(root))
                yield return v;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private IEnumerable<int> TraverseForward(Node node)
    {
        if (node.Left != null)
            foreach (var v in TraverseForward(node.Left))
                yield return v;
        yield return node.Value;
        if (node.Right != null)
            foreach (var v in TraverseForward(node.Right))
                yield return v;
    }
}

public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        if (sortedNumbers == null || sortedNumbers.Length == 0)
            return bst;
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;

        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
