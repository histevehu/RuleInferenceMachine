using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIM;
namespace RIM
{
    class TEST
    {
        static void Main(string[] args)
        {

            LinkedList<int> A = new RIM.LinkedList<int>();
            LinkedListNode<int> a1 = new LinkedListNode<int>(A,1);
            LinkedListNode<int> a2 = new LinkedListNode<int>(A, 2);
            LinkedListNode<int> a3 = new LinkedListNode<int>(A, 3);
            LinkedListNode<int> a4 = new LinkedListNode<int>(A, 4);
            A.AddLast(a1);
            A.AddLast(a2);
            A.AddLast(a3);
            A.AddLast(a4);
            LinkedListNode<int> b1 = a1.next;
            Console.Write(b1.Item.ToString());
            b1.next = a3.next;
            Console.Write(b1.Item.ToString());
        }
    }
}
