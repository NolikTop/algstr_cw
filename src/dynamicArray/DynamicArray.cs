using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace src.dynamicArray
{
    public class DynamicArray<T> : ICollection<T>, ICloneable
    {
        private T[] _internalArray = new T[2];

        public int Count { get; private set; }

        private int _capacity = 2;
        public int Capacity
        {
            get => _capacity;
            set
            {
                var newArray = new T[value];
                _capacity = value;

                _internalArray.CopyTo(newArray, 0);
                _internalArray = newArray;
            }
        }

        public bool IsEmpty => Count == 0;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => _internalArray[index];
            set
            {
                if (index >= Count)
                {
                    Count = index + 1;
                }
                
                if (index >= Capacity)
                {
                    Capacity = Math.Max(index+1, Capacity * 2);
                }
                _internalArray[index] = value;
            }
        }
        
        public DynamicArray(){}

        public DynamicArray(IEnumerable<T> array)
        {
            var enumerable = array as T[] ?? array.ToArray();
            
            _internalArray = enumerable;
            Count = enumerable.Length;
            _capacity = Count;
        }

        public void Add(T item)
        {
            
            if (Count >= Capacity)
            {
                Capacity *= 2;
            }

            _internalArray[Count++] = item;
        }
        
        public void Clear()
        {
            _internalArray = new T[2];
            Count = 0;
            _capacity = 2;
        }

        public bool Contains(T item)
        {
            return _internalArray.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _internalArray.CopyTo(array, arrayIndex);
        }
        

        public void CopyTo(DynamicArray<T> array, int arrayIndex)
        {
            _internalArray.CopyTo(array._internalArray, arrayIndex);
        }
        
        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; ++i)
            {
                if (!EqualityComparer<T>.Default.Equals(_internalArray[i], item)) continue;

                return i;
            }

            return -1;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            
            return true;
        }

        public void RemoveAt(int index)
        {
            Array.Copy(_internalArray, index + 1, _internalArray, index, _internalArray.Length - index - 1); // ???????????????? ???????????? 
            Count--;
        }
        
        public override string ToString()
        {
            var r = $"[Count={Count}, Capacity={Capacity}]<";
            if (Count == 0)
            {
                r += "Empty dynamic array";
            }
            else
            {
                r += ToElementsString();
            }

            r += ">";

            return r;
        }

        public string ToElementsString()
        {
           return string.Join(",", this);
        }

        public object Clone()
        {
            var newArr = new DynamicArray<T>
            {
                _internalArray = (T[])_internalArray.Clone(),
                _capacity = _capacity,
                Count = Count
            };

            return newArr;
        }

        // ?????????? ???????????? ???????????? ?? ?????? ?????? ????????. ???????? ???? ?????? ???????? ?????? ???? ??????????????????, ?? ???????????????????? ?????? ?????? ?? ??????????????
        public T GetOrAdd(T value)
        {
            var index = IndexOf(value);
            if (index != -1) return this[index];
            
            Add(value);
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}