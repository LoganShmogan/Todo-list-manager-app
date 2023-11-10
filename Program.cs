using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Creates the todoList
        TodoList todoList = new TodoList();

        while (true)
        {
            //Displays a set of options for the user
            Console.WriteLine("Todo List");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. List Tasks");
            Console.WriteLine("4. Add Category");
            Console.WriteLine("5. Exit");
            Console.Write("Enter a number 1-5: ");

            //Asks the user for input
            string choice = Console.ReadLine();

            //Reads user input
            switch (choice) 
            {//If user inputs one it will ask the user for detailas based on the task
                case "1":
                    Console.Write("Enter description: ");
                    string taskDescription = Console.ReadLine();
                    Console.Write("Enter name: ");
                    string categoryName = Console.ReadLine();
                    todoList.AddTask(taskDescription, categoryName);
                    Console.WriteLine("Task added");
                    break;

                case "2"://if the user puts 2  it will ask the user which item to remove
                    Console.Write("Enter task to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int taskIndex))
                    {
                        todoList.RemoveTask(taskIndex - 1);
                        Console.WriteLine("Task removed!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid task. IE (Number that task is)");
                    }
                    break;

                case "3"://If user inputs 3 the tasks will be listed
                    todoList.ListTasks();
                    break;

                case "4"://If the user write 4 it will ask for category information
                    Console.Write("Enter name: ");
                    string newCategory = Console.ReadLine();
                    todoList.AddCategory(newCategory);
                    Console.WriteLine("Category added");
                    break;

                case "5"://if a user inputs 5 it will exit the enviourment
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please try again.");
                    break;
            }
        }
    }
}


//Gets and sets taskitem information as a class
public class TaskItem
{
    public string Description { get; set; }
    public string Category { get; set; }
}

public class TodoList
{
    //creates list for the added information
    private List<TaskItem> tasks = new List<TaskItem>();
    private List<string> categories = new List<string>();
    //adds task information to the list
    public void AddTask(string description, string categoryName)
    {
        tasks.Add(new TaskItem { Description = description, Category = categoryName });
    }
    //removes task
    public void RemoveTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Please try again");
        }
    }
    //adds a categoory to the list
    public void AddCategory(string name)
    {
        categories.Add(name);
    }
    //lists task information
    public void ListTasks()
    {
        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].Description} - {tasks[i].Category}");
        }
    }
}
