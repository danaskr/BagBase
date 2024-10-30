using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace hdwj3h
{
    internal class Menu
    {
        private Bag bag = new Bag();
        public void Run()
        {
            int c;
            do
            {
                c = GetMenu();
                switch (c)
                {
                    case 1:
                        Insert();
                        PrintThatBag();
                        break;
                    case 2:
                        Remove();
                        PrintThatBag();
                        break;
                    case 3:
                        GetFrequency();
                        PrintThatBag();
                        break;
                    case 4:
                        TheMostFrequent();
                        break;
                    case 5:
                        PrintThatBag();
                        break;
                    default: 
                        Console.WriteLine("viszontlatasra!");
                        break;
                }
            } while (c != 0);
        }
        #region menu operations

        /// 1 //////////////////////////////////

        private void Insert()
        {
            Item i = new Item();
            i.readItem();
            try
            {
                bag.insert(i);
                Console.WriteLine("inserted correctly :) ");
            }
            catch (Bag.ElementAlreadyExists)
            {
                Console.WriteLine("Element Already Exidts !");
            }

        }

        /// 2 //////////////////////////////////

        private void Remove()
        {
           
            Item i = new Item();
            i.readItem() ;
            
            try
            {
               
                bag.remove(i) ;
                Console.WriteLine("The element " + i + " has been removed");
                
            }
            catch(Bag.BagIsEmpty){
                Console.WriteLine("Bag is Empty !! ");
            }
            catch (Bag.ElementNotFound)
            {
                Console.WriteLine("Element not in the Bag! Couldn't remove </3 ");
            }

        }

        /// 3 //////////////////////////////////

        private void GetFrequency()
        {
            Console.WriteLine("element :");
            string e =Console.ReadLine();

            try
            {
                Console.WriteLine("The frequency is : " + bag.getFrequency(e));
            }
            catch (Bag.ElementNotFound)
            {
                Console.WriteLine("Element not in the Bag!, unable to get frequency :( ");
            }
            catch (Bag.BagIsEmpty)
            {
                Console.WriteLine("Bag is empty, unable to get frequency :( ");
            }

        }
        ///  4 //////////////////////////////////

        private void TheMostFrequent()
        { Item i;
            try{
                i = bag.mostFrequant();
                Console.WriteLine("the most frequent element is " + i);
            }catch(Bag.BagIsEmpty)
            {
                Console.WriteLine("Bag is empty, mostFrequent couldn't be found :( ");
            }
        }

        /// 5 //////////////////////////////////

        private void PrintThatBag()
        {
            Console.WriteLine(bag);
        }

        /////////////////////////////////////


        private static int GetMenu()
        {
            int c;
            do
            {
                Console.WriteLine("\n****************Task 8 - Bag****************");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Insert an element");
                Console.WriteLine("2. Remove an element");
                Console.WriteLine("3. return the frequency of an element");
                Console.WriteLine("4. get the most frequent element");
                Console.WriteLine("5. Print out the Bag");
                Console.WriteLine("**********************************************");

                try
                {
                    c = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException) { c = -1; }
            } while (c < 0 || c > 5); 
            return c;
        }
        #endregion
    }
}
