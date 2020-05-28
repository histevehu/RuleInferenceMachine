using System;
using System.Collections;
using System.Collections.Generic;

namespace RIM
{
    public interface ICollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// 返回列表中项的总数
        /// </summary>       
        int Count { get; }

        /// <summary>
        /// 添加一个新的项到列表中
        /// </summary>
        void Add(T item);

        /// <summary>
        /// 从列表中清除所有的项
        /// </summary>
        void Clear();

        /// <summary>
        /// 返回列表是否包含特定的项
        /// </summary>
        bool Contains(T item);

        /// <summary>
        /// 从列表复制到数组中
        /// </summary>
        void CopyTo(T[] array, int arrayIndex);

        /// <summary>
        /// 移除特定对象的第一个匹配项
        /// </summary>
        bool Remove(T item);
    }

    public class LinkedList<T> : ICollection<T>
    {
        //表头
        public LinkedListNode<T> mHead = null;
        //表尾
        public LinkedListNode<T> mLast = null;
        private int mCount = 0;
        public LinkedList() { }

        public LinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            foreach (T item in collection)
            {
                AddLast(item);
            }
        }

        public LinkedListNode<T> First
        {
            get
            {
                return mHead;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                return mLast;
            }
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            LinkedListNode<T> newNode = new LinkedListNode<T>(node.list, value);
            InsertAfterNode(node, newNode);
            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            LinkedListNode<T> newNode = new LinkedListNode<T>(node.list, value);
            InsertBeforeNode(node, newNode);
            return newNode;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
            {
                throw new ArgumentNullException();
            }
            newNode.list = node.list;
            InsertAfterNode(node, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
            {
                throw new ArgumentNullException();
            }
            if (Contains(newNode.Item))
            {
                throw new InvalidOperationException();
            }
            newNode.list = node.list;
            InsertBeforeNode(node, newNode);
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(this, value);
            AddFirst(node);
            return node;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(this, value);
            AddLast(node);
            return node;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            if (mHead == null)
            {
                InsertEmptyLinkedList(node);
            }
            else
            {
                InsertBeforeNode(mHead, node);
            }
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            if (mLast == null)
            {
                InsertEmptyLinkedList(node);
            }
            else
            {
                InsertAfterNode(mLast, node);
            }
        }

        public void InsertEmptyLinkedList(LinkedListNode<T> node)
        {
            node.next = null;
            node.prev = null;
            //把新增节点赋值为最新的Head, Last节点
            mHead = node;
            mLast = node;
            mCount++;
        }

        public void InsertAfterNode(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node.next == null)
            {
                newNode.next = null;
                //把新增节点的prev指向之前的Last节点
                newNode.prev = mLast;
                //把之前的Last节点的next指向新增节点
                mLast.next = newNode;
                //把新增节点赋值为最新的Last节点
                mLast = newNode;
                mCount++;
            }
            else
            {
                //把新增节点的next指向之前的node节点的next
                newNode.next = node.next;
                //把新增节点的prev指向之前的node节点
                newNode.prev = node;
                //把之前的node节点的next的prev指向新增节点
                node.next.prev = newNode;
                //把之前的node节点的next指向新增节点
                node.next = newNode;
                mCount++;
            }
        }

        public void InsertBeforeNode(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node.prev == null)
            {
                //把新增节点的next指向之前的Head节点
                newNode.next = mHead;
                newNode.prev = null;
                //把之前的Head节点的prev指向新增节点
                mHead.prev = newNode;
                //把新增节点赋值为最新的Head节点
                mHead = newNode;
                mCount++;
            }
            else
            {
                //把新增节点的next指向之前的node节点
                newNode.next = node;
                //把新增节点的prev指向之前的node节点的prev
                newNode.prev = node.prev;
                //把之前的node节点的prev的next指向新增节点
                node.prev.next = newNode;
                //把之前的node节点的prev指向新增节点
                node.prev = newNode;
                mCount++;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            if (value == null)
            {
                return null;
            }
            LinkedListNode<T> node = mHead;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (node != null)
            {
                do
                {
                    if (comparer.Equals(node.Item, value))
                    {
                        return node;
                    }
                    node = node.next;
                } while (node != null);
            }
            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            if (value == null)
            {
                return null;
            }
            LinkedListNode<T> node = mLast;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (node != null)
            {
                do
                {
                    if (comparer.Equals(node.Item, value))
                    {
                        return node;
                    }
                    node = node.prev;
                } while (node != null);
            }
            return null;
        }

        public int Count
        {
            get
            {
                return mCount;
            }
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            LinkedListNode<T> node = mHead;
            while (node != null)
            {
                LinkedListNode<T> node1 = node;
                node1.Clear();
                node1.Item = default(T);
                //当next == list.mLast时，node.Next返回null，跳出循环
                node = node.Next;
            }
            mHead = null;
            mLast = null;
            mCount = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> node = mHead;
            while (node != null)
            {
                array[arrayIndex] = node.Item;
                node = node.next;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            LinkedListNode<T> node = mHead;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (node != null)
            {
                if (comparer.Equals(node.Item, item))
                {
                    LinkedListNode<T> node1 = node.prev;
                    LinkedListNode<T> node2 = node.next;
                    if (node1 != null)
                    {
                        node1.next = node2;
                    }
                    else
                    {
                        mHead = node2;
                    }
                    if (node2 != null)
                    {
                        node2.prev = node1;
                    }
                    else
                    {
                        mLast = node1;
                    }
                    node.Clear();
                    mCount--;
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public void Remove(LinkedListNode<T> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException();
            }
            T item = newNode.Item;
            LinkedListNode<T> node = mHead;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (node != null)
            {
                if (comparer.Equals(node.Item, item))
                {
                    LinkedListNode<T> node1 = node.prev;
                    LinkedListNode<T> node2 = node.next;
                    if (node1 != null)
                    {
                        node1.next = node2;
                    }
                    else
                    {
                        mHead = node2;
                    }
                    if (node2 != null)
                    {
                        node2.prev = node1;
                    }
                    else
                    {
                        mLast = node1;
                    }
                    node.Clear();
                    mCount--;
                    break;
                }
                node = node.next;
            }
        }

        public void RemoveFirst()
        {
            LinkedListNode<T> node = mHead.next;
            node.prev = null;
            Remove(mHead);
            mHead = node;
        }

        public void RemoveLast()
        {
            LinkedListNode<T> node = mLast.prev;
            node.next = null;
            Remove(mLast);
            mLast = node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private LinkedList<T> list;
            private LinkedListNode<T> node;
            private int index;
            private T current;

            public Enumerator(LinkedList<T> list)
            {
                this.list = list;
                node = list.mHead;
                index = 0;
                current = default(T);
            }

            public T Current
            {
                get
                {
                    if (index <= 0 || index > list.Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index <= 0 || index > list.Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return current;
                }
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (index >= 0 && index < list.Count)
                {
                    if (node != null)
                    {
                        current = node.Item;
                        node = node.next;
                        index++;
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                index = 0;
                current = default(T);
            }
        }
    }

    public sealed class LinkedListNode<T>
    {
        public LinkedList<T> list;
        public LinkedListNode<T> next;
        public LinkedListNode<T> prev;
        private T item;

        internal LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            item = value;
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public LinkedListNode<T> Next
        {
            get { return next == null || next == list.mLast ? null : next; }
        }

        public void Clear()
        {
            list = null;
            next = null;
            prev = null;
        }
    }
}
