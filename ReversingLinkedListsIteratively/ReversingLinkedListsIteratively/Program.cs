using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversingLinkedListsIteratively
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

            DisplayLinkedList(head);
            head = ReverseLinkedList(head);
            Console.WriteLine();
            DisplayLinkedList(head);
            Console.ReadLine();
        }

        /// <summary>
        /// Reverses a Linked List with the current head supplied as a paramter.
        /// </summary>
        /// <param name="head">head: Node (the head of the Linked List)</param>
        /// <returns>the head of the reversed Linked List</returns>
        private static Node ReverseLinkedList(Node head)
        {
            // Set the current node to head, meaning the first element in the Linked List.
            Node current = head;
            // Previous is set to null, as there are no preceeding nodes of head.
            Node previous = null;
            Node next = null;

            while (current != null)
            {
                // Save the address of the next node, so we don't lose the link.
                next = current.Next;
                // Set the next node of the current node to its previous node
                // thus effectively changing the direction of the link.
                current.Next = previous;
                // Change the previous node to the current node, so that we can
                // change the direction of the next link to previous.
                previous = current;
                // Go to the next node in the list, and repeat the process.
                current = next;
            }

            // The head will be the final node of the list, saved in previous
            head = previous;

            return head;
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

        /// <summary>
        /// Prints the entire list pointed to by the supplied Node object.
        /// </summary>
        /// <param name="head">head: Node (the head object of the linked list)</param>
        private static void DisplayLinkedList(Node head)
        {
            while (head != null)
            {
                Console.Write("{0}, ", head.Data);
                head = head.Next;
            }
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
