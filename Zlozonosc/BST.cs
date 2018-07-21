using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Lab2.cs")]
namespace Zlozonosc
{
    class BST
    {

        internal class Node
        {
            public dList value;
            public Node left;
            public Node right;
        }

        internal class Tree
        {
            public Node Insert(Node root, dList v)
            {

                if (root == null)
                {
                    root = new Node();
                    root.value = v;
                }
                else if (v.English.CompareTo(root.value.English) < 0)
                {
                    root.left = Insert(root.left, v);
                }
                else
                {
                    root.right = Insert(root.right, v);
                }

                return root;
            }

            public void Traverse(Node root)
            {
                if (root == null)
                {
                    return;
                }

                Console.WriteLine(root.value.English + " - " + root.value.Polish);
                Traverse(root.left);
                Traverse(root.right);
            }

            public void LookFor(Node root, string toFind, int i)
            {

                if (root == null)
                {
                    Console.WriteLine($"{i}.kupa");
                    return;
                }

                if (root.value.English == toFind)
                {
                    Console.WriteLine($"{i}.Znaleziono {root.value.English} oraz {root.value.Polish}");
                }
                else if (toFind.CompareTo(root.value.English) < 0)
                {
                    LookFor(root.left, toFind, i);
                }
                else
                {
                    LookFor(root.right, toFind, i);
                }

            }

        }
    }
}
