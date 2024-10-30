using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace hdwj3h
{
    public class Item
    {
        public int frequency;
        public string element;


        public Item(string e,int f)
        {
            frequency = f;
            element = e;
        }
        public Item() { }


        public void readItem()
        {

            bool IntInput;

            Console.WriteLine(" element: ");
            element = Console.ReadLine();

            do
            {
                try
                {
                    Console.WriteLine(" frequency: ");
                    IntInput = int.TryParse(Console.ReadLine(),out frequency); // must be true here
                }
                catch (System.FormatException)
                {
                    IntInput = false;
                }

            } while (!IntInput);

        }

       

        public override string ToString()
        {
            return "(" + element + "," + frequency + ")"; 
        }

    }

    public class Bag
    {

        List<Item> vec = new List<Item>();
        
        private Item mostFrequent;
        

        public class BagIsEmpty : Exception { }
        public class ElementNotFound : Exception { }
        public class ElementAlreadyExists : Exception { }

        /// helpers
        private bool isEmpty()
        {
            return vec.Count == 0;
        }
        public int getSize()
        {
            return vec.Count;
        }

        private Item findElem(string e)
        {
            if (isEmpty())
            {
                throw new BagIsEmpty();
            }
            Item I = new Item();
            bool found = false;
            for(int i =0; i< vec.Count; i++)
            {
                if (vec[i].element == e)
                {
                    I.element = e;
                    I.frequency = vec[i].frequency;
                    found = true;

                }
                
            }

            if (!found)
            {
                throw new ElementNotFound();
            }
            return I;

        }

        
        private bool isElem(Item I)
        {
            if(isEmpty())
                throw new BagIsEmpty();

            bool found = false;
            for(int i =0; i< vec.Count; i++)
            {
                if (vec[i].element == I.element) {
                    found = true;
                    break;
                }
            }
            return found;
        }
        private bool isElem2(Item I)
        {

            bool found = false;
            for (int i = 0; i < vec.Count; i++)
            {
                if (vec[i].element == I.element)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        /// 
        public void insert(Item i)
        {
            if(isElem2(i)) throw new ElementAlreadyExists();

            vec.Add(i);
            mostFrequant();


        }
        public void remove(Item I)
        {
            if (isEmpty())
                throw new BagIsEmpty();
            if (!isElem(I))
                throw new ElementNotFound();
                
         
            List<Item> temp = new List<Item>();
            for(int i =0; i< vec.Count; i++)
            {
                if (vec[i].element != I.element)
                {
                     
                    temp.Add(vec[i]);
                }
                
            }
            
            vec.Clear();
            vec.AddRange(temp);

            mostFrequant();
        }
        
      
        public int getFrequency(string e)
        {
            if (isEmpty())
            {
                throw new BagIsEmpty();
            }
            if(!isElem(findElem(e)))
                throw new ElementNotFound();

            return findElem(e).frequency;
        }

        public Item mostFrequant()
        {
            if (!isEmpty())
            {
                int ind = 0;
                int maxFreq = 0;

                for (int i = 1; i < vec.Count; i++)
                {
                    if (vec[i].frequency > maxFreq)
                    {
                        ind = i;
                        maxFreq = vec[i].frequency;

                    }
                }
                mostFrequent = vec[ind];
                return mostFrequent;
            }
            else
            {
                throw new BagIsEmpty() ;
            }
        }

        

        public override string ToString()
        {
            string str = "[";
            str = str + string.Join(",", vec);
            str += "]\n";

            return str;

        }




    }
}
