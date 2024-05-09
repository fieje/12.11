using System;

public class Subscriber
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Subscriber(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}

public class ListNode
{
    public Subscriber Subscriber { get; set; }
    public ListNode Next { get; set; }

    public ListNode(Subscriber subscriber)
    {
        Subscriber = subscriber;
        Next = null;
    }
}

public class TreeNode
{
    public Subscriber Subscriber { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(Subscriber subscriber)
    {
        Subscriber = subscriber;
        Left = null;
        Right = null;
    }
}

public class PhoneDirectory
{
    private ListNode head;
    private TreeNode root;

    public void AddToList(Subscriber subscriber)
    {
        ListNode newNode = new ListNode(subscriber);
        newNode.Next = head;
        head = newNode;
    }

    public void AddToTree(Subscriber subscriber)
    {
        root = AddToTreeRecursive(root, subscriber);
    }

    private TreeNode AddToTreeRecursive(TreeNode node, Subscriber subscriber)
    {
        if (node == null)
        {
            return new TreeNode(subscriber);
        }

        if (string.Compare(subscriber.PhoneNumber, node.Subscriber.PhoneNumber) < 0)
        {
            node.Left = AddToTreeRecursive(node.Left, subscriber);
        }
        else if (string.Compare(subscriber.PhoneNumber, node.Subscriber.PhoneNumber) > 0)
        {
            node.Right = AddToTreeRecursive(node.Right, subscriber);
        }

        return node;
    }

    public void DisplayDirectory()
    {
        Console.WriteLine("Phone Directory:");

        ListNode current = head;
        while (current != null)
        {
            Console.WriteLine($"Name: {current.Subscriber.Name}, Phone Number: {current.Subscriber.PhoneNumber}");
            current = current.Next;
        }

        Console.WriteLine("\nPhone Directory (in-order traversal):");
        InOrderTraversal(root);
    }

    private void InOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.WriteLine($"Name: {node.Subscriber.Name}, Phone Number: {node.Subscriber.PhoneNumber}");
            InOrderTraversal(node.Right);
        }
    }

    public double CalculateCallCost(string phoneNumber, TimeSpan callDuration)
    {
        double costPerMinute = 0.1;
        double totalCost = callDuration.TotalMinutes * costPerMinute;
        Console.WriteLine($"Phone call to number {phoneNumber} lasting {callDuration.TotalMinutes} minutes. Cost: ${totalCost}");
        return totalCost;
    }

    public ListNode GetHead()
    {
        return head;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        PhoneDirectory directory = new PhoneDirectory();

        while (true)
        {
            Console.WriteLine("\nPhone Directory Menu:");
            Console.WriteLine("1. Add Subscriber");
            Console.WriteLine("2. Display Directory");
            Console.WriteLine("3. Calculate Call Cost");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter subscriber name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    string phoneNumber = Console.ReadLine();
                    directory.AddToList(new Subscriber(name, phoneNumber));
                    directory.AddToTree(new Subscriber(name, phoneNumber));
                    break;
                case "2":
                    directory.DisplayDirectory();
                    break;
                case "3":
                    Console.Write("Enter phone number: ");
                    string phone = Console.ReadLine();
                    Console.Write("Enter call duration in minutes: ");
                    int minutes = Convert.ToInt32(Console.ReadLine());
                    directory.CalculateCallCost(phone, TimeSpan.FromMinutes(minutes));
                    break;
                case "4":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please enter a number from 1 to 4.");
                    break;
            }
        }
    }
}
