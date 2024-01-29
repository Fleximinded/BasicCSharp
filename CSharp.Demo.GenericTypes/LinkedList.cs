using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.GenericTypes
{
    public class LinkedList<T>  where T : class
    {
        internal class ListItem<T> where T : class
        {
            public ListItem() { }
            public ListItem(T item, ListItem<T>? next = null)
            {
                Value = item;
                Next = next;
            }
            public T? Value { get; set; } = null;
            public ListItem<T>? Next { get; set; } = null;
        }

        ListItem<T>? Start { get; set; } = null;
        ListItem<T>? End { get; set; } = null;
        ListItem<T>? Current { get; set; } = null;


        public void Add(T item)
        {
            if(Start == null)
            {
                Start = new ListItem<T>(item);
                End = Start;               
            }
            else {
                var newItem = new ListItem<T>(item);
                End.Next = newItem;
                End = newItem;
            }
            Current = End;
        }
        public T? this[int pos] { 
            get {
                int i = 0;
                Current = Start;
                while(i < pos && Current?.Next!=null) {
                    Current = Current.Next;
                    i++;                        
                }
                return Current?.Value;            
            } 
        }
    
    }
}
