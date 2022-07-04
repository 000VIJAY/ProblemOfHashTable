using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HashTable
{
    public class myMapNode<k, v>
    {
        int size;
        LinkedList<Node<k, v>>[] items;
        public myMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<Node<k, v>>[size];
        }
        public int GetHashPosition(k key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public LinkedList<Node<k, v>> GetLinkedList(int position)
        {
            LinkedList<Node<k, v>> result = items[position];
            if (result == null)
            {
                result = new LinkedList<Node<k, v>>();
                items[position] = result;
            }
            return result;
        }
        public void Add(k key, v value)
        {
            int position = GetHashPosition(key);
            LinkedList<Node<k, v>> list = GetLinkedList(position);
            Node<k, v> item = new Node<k, v>() { Key = key, Value = value };
            list.AddLast(item);
        }
        public v Get(k key)
        {
            int position = GetHashPosition(key);
            LinkedList<Node<k, v>> list = GetLinkedList(position);
            foreach (Node<k, v> item in list)
            {
                item.Key.Equals(key);
                return item.Value;

            }
            return default(v);
        }
        public void Remove(k key)
        {
            int position = GetHashPosition(key);
            LinkedList<Node<k, v>> list = GetLinkedList(position);
            bool iFound = false;
            Node<k, v> items = default(Node<k, v>);
            foreach (Node<k, v> item in list)
            {
                if (item.Key.Equals(key))
                {
                    iFound = true;
                    items = item;
                }
                if (iFound)
                {
                    list.Remove(items);
                }
            }
        }

    }
}
