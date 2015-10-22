using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintValuesOfALinkedListRecursion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node head = null;

            head = AttachNodeToList(head, 0);
            head = AttachNodeToList(head, 1);
            head = AttachNodeToList(head, 2);
            head = AttachNodeToList(head, 3);
            head = AttachNodeToList(head, 4);
            head = AttachNodeToList(head, 5);
            head = AttachNodeToList(head, 6);
            head = AttachNodeToList(head, 7);
            head = AttachNodeToList(head, 8);
            head = AttachNodeToList(head, 9);

            Console.WriteLine("Printing Linked List from start to end:");
            NormalDisplay(head);
            Console.WriteLine();
            Console.WriteLine("Printing Linked List from end to start:");
            ReverseDisplay(head);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the elements of a Linked List from beginning to end recursively.
        /// </summary>
        /// <param name="head">head: Node (the head of the Linked List)</param>
        private static void NormalDisplay(Node head)
        {
            if (head == null)
            {
                return;
            }
            
            Console.WriteLine(head.Data);
            NormalDisplay(head.Next);
        }

        /// <summary>
        /// Prints the elements of a Linked List from end to beginning recursively.
        /// </summary>
        /// <param name="head">head: Node (the head of the Linked List)</param>
        private static void ReverseDisplay(Node head)
        {
            if (head == null)
            {
                return;
            }

            ReverseDisplay(head.Next);
            Console.WriteLine(head.Data);
        }

        /// <summary>
        /// Attaches a new node to the next property of head.
        /// </summary>
        /// <param name="head">head: Node (the tail node in the list)</param>
        /// <param name="data">data: int (the data to be stored in the new node)</param>
        /// <returns></returns>
        private static Node AttachNodeToList(Node head, int data)
        {
            Node temp = new Node();
            temp.Data = data;
            temp.Next = null;

            // If the list has not been created yet, set head as the first
            // node.
            if (head == null)
            {
                head = temp;
            }
            // Else go to the last node in the list and set the next node
            // to the new node.
            else
            {
                Node temp2 = head;
                while (temp2.Next != null)
                {
                    temp2 = temp2.Next;
                }
                temp2.Next = temp;
            }

            return head;
        }
    }

    /**
     * In a effort to make this solution fit most programming languages, I refrained
     * from using the C# version of the Linked List. Rest assured, many languages
     * support a Linked List collection type.
     **/
    public class Node
    {
        public int Data { get; set; }       // Stores the data contained in each node.
        public Node Next { get; set; }      // Stores the address of the next node in the list
    }
}
