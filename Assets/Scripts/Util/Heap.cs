using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace Heap
{
    public class ItemHeap
    {
        private List<Item> _list;
        public Item this[int index]
        {
            get
            {
                return _list[index];
            }

            //set
            //{
            //    _list[index] = value;
            //}
        }

        private void Swap(ref int left, int right)
        {
            Item temp;

            temp = _list[left - 1];
            _list[left - 1] = _list[right - 1];
            _list[right - 1] = temp;

            left = right;
        }

        public Item Top()
        {
            return _list[0];
        }

        public bool Empty()
        {
            return _list.Count == 0;
        }

        public int Size()
        {
            return _list.Count;
        }

        public void Push(Item item)
        {
            _list.Add(item);

            if (item.Data.IsTarget)
            {
                return;
            }

            int currentIndex = Size();

            while (currentIndex > 1)
            {
                int parentIndex = currentIndex / 2;

                if (_list[parentIndex - 1].Data.IsTarget)
                {
                    Swap(ref currentIndex, parentIndex);
                    continue;
                }

                if (_list[parentIndex - 1].Data.Size < _list[currentIndex - 1].Data.Size)
                {
                    break;
                }
                else if (_list[parentIndex - 1].Data.Weight >= _list[currentIndex - 1].Data.Weight)
                {
                    break;
                }

                Swap(ref currentIndex, parentIndex);
            }
        }

        public void Pop()
        {
            Remove(0);
        }

        public void Remove(int index)
        {
            _list[index] = _list[_list.Count - 1];

            _list.RemoveAt(_list.Count - 1);

            int currentSize = _list.Count;
            int currentIndex = index + 1;

            while (currentIndex < currentSize)
            {
                int left = currentIndex * 2;
                int right = left + 1;

                if (left > currentSize)
                {
                    break;
                }

                int child = left;
                if (right <= currentSize)
                {
                    if (_list[right].Data.IsTarget)
                    {
                        child = left;
                    }
                    else if (_list[left - 1].Data.Size > _list[right - 1].Data.Size)
                    {
                        child = right;
                    }
                    else if (_list[left - 1].Data.Size == _list[right - 1].Data.Size && _list[left - 1].Data.Weight < _list[right - 1].Data.Weight)
                    {
                        child = right;
                    }
                }

                if (_list[currentIndex - 1].Data.IsTarget)
                {
                    Swap(ref currentIndex, child);
                    continue;
                }

                if (_list[child - 1].Data.IsTarget)
                {
                    break;
                }
                else if (_list[currentIndex - 1].Data.Size < _list[child - 1].Data.Size)
                {
                    break;
                }
                else if (_list[currentIndex - 1].Data.Size == _list[child - 1].Data.Size && _list[currentIndex - 1].Data.Weight > _list[child - 1].Data.Weight)
                {
                    break;
                }

                Swap(ref currentIndex, child);
            }
        }

        public void Remove(Item item)
        {
            ItemSearch _is = new ItemSearch(item);
            Remove(_list.FindIndex(_is.EqualsTo));
        }

        private class ItemSearch
        {
            Item _item;

            public ItemSearch(Item item)
            {
                _item = item;
            }

            public bool EqualsTo(Item item)
            {
                return _item == item;
            }
        }
    }

    public class Heap<T>
    {
        private List<T> _list;
        public delegate bool Compare<T1, T2>(T1 left, T2 right);

        private Compare<T, T> _compare;

        public Heap (Compare<T, T> compare)
        {
            _compare = compare;
        }

        public T this[int index]
        {
            get
            {
                return _list[index];
            }

            //set
            //{
            //    _list[index] = value;
            //}
        }

        private void Swap(ref int left, int right)
        {
            T temp;

            temp = _list[left - 1];
            _list[left - 1] = _list[right - 1];
            _list[right - 1] = temp;

            left = right;
        }

        public T Top()
        {
            return _list[0];
        }

        public bool Empty()
        {
            return _list.Count == 0;
        }

        public int Size()
        {
            return _list.Count;
        }

        public void Push(T obj)
        {
            _list.Add(obj);

            int currentIndex = Size();

            while (currentIndex > 1)
            {
                int parentIndex = currentIndex / 2;

                if (_compare(_list[parentIndex], _list[currentIndex]))
                {
                    break;
                }

                Swap(ref currentIndex, parentIndex);
            }
        }

        public void Pop()
        {
            _list[0] = _list[_list.Count - 1];

            _list.RemoveAt(_list.Count - 1);

            int currentSize = _list.Count;
            int currentIndex = 1;

            while (currentIndex < currentSize)
            {
                int left = currentIndex * 2;
                int right = left + 1;

                if (left > currentSize)
                {
                    break;
                }

                int child = left;
                if (right <= currentSize)
                {
                    if (_compare(_list[left - 1], _list[right - 1]))
                    {
                        child = right;
                    }
                }

                if (_compare(_list[currentIndex - 1], _list[child - 1]))
                {
                    break;
                }
                
                Swap(ref currentIndex, child);
            }
        }
    }
}
