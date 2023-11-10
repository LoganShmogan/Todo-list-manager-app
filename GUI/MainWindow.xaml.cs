using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Schema;
using static ToDoAppVSWPF.MainWindow;
using static ToDoAppVSWPF.MainWindow.Priority;

namespace ToDoAppVSWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Adds the categories to the comboboxs
            ToDoItemCategorycbx.ItemsSource = categories;
            ToDoItemCategorycbx.DisplayMemberPath = "CategoryTitle";

            TaskItemCategorycbx.ItemsSource = categories;
            TaskItemCategorycbx.DisplayMemberPath = "CategoryTitle";

            //Creates priority levels
            List<Priority> priorities = new List<Priority>
            {
                new Priority { PriorityLevel = "High" },
                new Priority { PriorityLevel = "Medium" },
                new Priority { PriorityLevel = "Low" },
            };

            //Outs these priorities into the comboboxs
            ToDoItemPrioritycbx.ItemsSource = priorities;
            ToDoItemPrioritycbx.DisplayMemberPath = "PriorityLevel";

            //resets the boxs to an empty state
            ToDoItemCategorycbx.SelectedItem = null;
            ToDoItemPrioritycbx.SelectedItem = null;
            ToDoItemLabeltbx.Clear();
            ToDoItemDueDatetbx.Clear();
            ToDoItemDesctbx.Clear();
            ToDoItemIDtbx.Clear();
            ToDoItemTitletbx.Clear();
            TaskItemDesctbx.Clear();
            TaskItemIDtbx.Clear();
            TaskItemTitletbx.Clear();
            TaskItemCategorycbx.SelectedItem = null;
            CategoryTitletbx.Clear();
            CategoryIDtbx.Clear();
        }
        
        //Creates Standard Categories that can be added to
        private List<Category> categories = new List<Category>
        {
            new Category { CategoryTitle = "Home", CategoryID = "1" },
            new Category { CategoryTitle = "Work", CategoryID = "2" },
        };

        //Creates a priority class
        public class Priority
        {
            public string PriorityLevel { get; set; }
        }

        //Creates a Category class
        public class Category
        {
            public string CategoryTitle { get; set; }
            public string CategoryID { get; set; }
        }

        //Adds a ToDoItem to the listbox
        private void ToDoItemAddbtn_Click(object sender, RoutedEventArgs e)
        {
            //Initilises gui text as strings
                string title = ToDoItemTitletbx.Text;
                string ID = ToDoItemIDtbx.Text;
                string desc = ToDoItemDesctbx.Text;
                string dueDate = ToDoItemDueDatetbx.Text;
                string label = ToDoItemLabeltbx.Text;
                string priority = ToDoItemPrioritycbx.Text;
                string category = ToDoItemCategorycbx.Text;

            //Adds textboxs to an array to check if it has been left empty or not
            string[] ToDoItemContent = {ToDoItemTitletbx.Text, ToDoItemIDtbx.Text, ToDoItemDesctbx.Text, ToDoItemDueDatetbx.Text, ToDoItemLabeltbx.Text, ToDoItemPrioritycbx.Text, ToDoItemCategorycbx.Text };
            //Creates a number for the lentgh of the array
            int last = ToDoItemContent.Length;
            //starts a check at 0
            int lastCheck = 0;
            //cehcks each item in the array
            foreach (var item in ToDoItemContent)
            {
                //if the information is filled in it will add to the lastCheck and continue to the next item
                if (!string.IsNullOrWhiteSpace(item))
                {
                    lastCheck++;
                    //if the lastcheck is the same number of last meaning if the lastcheck variable is the same number as the lenght of the 
                    //Array it will add the information to the listbox
                    if (lastCheck == last)
                    {
                        //adds these gui text strings to a list
                        ListViewItem ToDoItem = new ListViewItem();
                        ToDoItem.Content = new { Category = category, Task = title + ID, Description = desc, Labels = label, Priority = priority, DueDate = dueDate };

                        //adds the list to the listbox
                        Itemsltv.Items.Add(ToDoItem);

                        //resets the boxs to an empty state
                        ToDoItemCategorycbx.SelectedItem = null;
                        ToDoItemPrioritycbx.SelectedItem = null;
                        ToDoItemLabeltbx.Clear();
                        ToDoItemDueDatetbx.Clear();
                        ToDoItemDesctbx.Clear();
                        ToDoItemIDtbx.Clear();
                        ToDoItemTitletbx.Clear();
                        break;
                    }
                    //Coninues to next item in the aray if the lastcheck dosnt equal the lentgh of the arrray
                    continue;
                }
                else
                {
                    //resets the boxs to an empty state
                    ToDoItemCategorycbx.SelectedItem = null;
                    ToDoItemPrioritycbx.SelectedItem = null;
                    ToDoItemLabeltbx.Clear();
                    ToDoItemDueDatetbx.Clear();
                    ToDoItemDesctbx.Clear();
                    ToDoItemIDtbx.Clear();
                    ToDoItemTitletbx.Clear();
                    //lets user know all information isant filled out
                    MessageBox.Show("You need to fill in all fields under the ToDoItem");
                    break;
                }
            }
            
                    
        }

       //Adds a TaskItem to the listbox
        private void TaskItembtn_Click(object sender, RoutedEventArgs e)
        {
            //Initilises gui text as strings
            string title = TaskItemTitletbx.Text;
            string ID = TaskItemIDtbx.Text;
            string desc = TaskItemDesctbx.Text;
            string category = TaskItemCategorycbx.Text;

            //Adds textboxs to an array to check if it has been left empty or not
            string[] TaskItemContent = { TaskItemTitletbx.Text, TaskItemIDtbx.Text, TaskItemDesctbx.Text, TaskItemCategorycbx.Text};
            //Creates a number for the lentgh of the array
            int last = TaskItemContent.Length;
            //starts a check at 0
            int lastCheck = 0;
            //cehcks each item in the array
            foreach (var item in TaskItemContent)
            {
                //if the information is filled in it will add to the lastCheck and continue to the next item
                if (!string.IsNullOrWhiteSpace(item))
                {
                    lastCheck++;
                    //if the lastcheck is the same number of last meaning if the lastcheck variable is the same number as the lenght of the 
                    //Array it will add the information to the listbox
                    if (lastCheck == last)
                    {
                        //adds these gui text strings to a list
                        ListViewItem TaskItem = new ListViewItem();
                        TaskItem.Content = new { Category = category, Task = title + ID, Description = desc };
                        //adds the list to the listbox
                        Itemsltv.Items.Add(TaskItem);

                        //resets the boxs to an empty state
                        TaskItemDesctbx.Clear();
                        TaskItemIDtbx.Clear();
                        TaskItemTitletbx.Clear();
                        TaskItemCategorycbx.SelectedItem = null;
                        break;
                    }
                    //Coninues to next item in the aray if the lastcheck dosnt equal the lentgh of the arrray
                    continue;
                }
                else
                {
                    //resets the boxs to an empty state
                    TaskItemDesctbx.Clear();
                    TaskItemIDtbx.Clear();
                    TaskItemTitletbx.Clear();
                    TaskItemCategorycbx.SelectedItem = null;
                    //lets user know all information isant filled out
                    MessageBox.Show("You need to fill in all fields under the TaskItem");
                    break;
                }
            }
            

            
        }

        //Adds a category to the comboboxs
        private void CategoryAddbtn_Click(object sender, RoutedEventArgs e)
        {
            //Initilises gui text as strings
            string title = CategoryTitletbx.Text;
            string ID = CategoryIDtbx.Text;

            //Adds textboxs to an array to check if it has been left empty or not
            string[] CategoryContent = { CategoryTitletbx.Text, CategoryIDtbx.Text};
            //Creates a number for the lentgh of the array
            int last = CategoryContent.Length;
            //starts a check at 0
            int lastCheck = 0;
            //cehcks each item in the array
            foreach (var item in CategoryContent)
            {
                //if the information is filled in it will add to the lastCheck and continue to the next item
                if (!string.IsNullOrWhiteSpace(item))
                {
                    lastCheck++;
                    //if the lastcheck is the same number of last meaning if the lastcheck variable is the same number as the lenght of the 
                    //Array it will add the information to the listbox
                    if (lastCheck == last)
                    {
                        //adds these gui text strings to a list
                        Category newCategory = new Category { CategoryTitle = title, CategoryID = ID };

                        //adds the list to the listbox
                        categories.Add(newCategory);

                        //Sets the ComboBox to nothing then updates the cbombox to include new items as well as old
                        TaskItemCategorycbx.ItemsSource = null;
                        TaskItemCategorycbx.ItemsSource = categories;
                        ToDoItemCategorycbx.ItemsSource = null;
                        ToDoItemCategorycbx.ItemsSource = categories;

                        //resets the boxs to an empty state
                        CategoryTitletbx.Clear();
                        CategoryIDtbx.Clear();
                        break;
                    }
                    //Coninues to next item in the aray if the lastcheck dosnt equal the lentgh of the arrray
                    continue;
                }
                else
                {
                    //resets the boxs to an empty state
                    CategoryTitletbx.Clear();
                    CategoryIDtbx.Clear();
                    //lets user know all information isant filled out
                    MessageBox.Show("You need to fill in all fields under the TaskItem");
                    break;
                }
            }

            
        }

        //Completes a task when selected in the listbox
        private void Completedbtn_Click(object sender, RoutedEventArgs e)
        {
            if (Itemsltv.SelectedItem != null)
            {
                MessageBox.Show("Removed");
                Itemsltv.Items.Remove(Itemsltv.SelectedItem);
            }
        }

        //Removes a task when selected in the listbox
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Itemsltv.SelectedItem != null)
            {
                MessageBox.Show("Completed");
                Itemsltv.Items.Remove(Itemsltv.SelectedItem);
            }
        }

        //Saves listboxx to a file
        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            //Creates a save dialopg
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt"; 

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    //Builds savefile in a specific way with commas to seperate diffferent items
                    StringBuilder sb = new StringBuilder();
                    
                    foreach (ListViewItem item in Itemsltv.Items)
                    {
                        dynamic data = item.Content;
                        sb.AppendLine($"{data.Category}, {data.Task}, {data.Description}, {data.Labels}, {data.Priority}, {data.DueDate}");
                    }

                    //Wries to savefile
                    File.WriteAllText(filePath, sb.ToString());

                    MessageBox.Show($"Data has been saved to {filePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while saving: {ex.Message}");
                }
            }
        }

        //Loads listbox from a file
        private void Loadbtn_Click(object sender, RoutedEventArgs e)
        {
            //Creates a open dialog
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt"; 

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    //If the file exists
                    if (File.Exists(filePath))
                    {
                        //Reads lines to a string array
                        string[] lines = File.ReadAllLines(filePath);

                        //Clears listbox before loading
                        Itemsltv.Items.Clear();

                        
                        foreach (string line in lines)
                        {
                            //Splits string array at each comma
                            string[] fields = line.Split(',');

                            
                            if (fields.Length >= 6)
                            {
                                //Adds each item to the corisponding feild
                                ListViewItem newItem = new ListViewItem();
                                newItem.Content = new
                                {
                                    Category = fields[0],
                                    Task = fields[1],
                                    Description = fields[2],
                                    Labels = fields[3],
                                    Priority = fields[4],
                                    DueDate = fields[5]
                                };

                                //Adds to listbox
                                Itemsltv.Items.Add(newItem);
                            }
                            else
                            {
                                MessageBox.Show("Invalid line format: " + line);
                            }
                        }

                        MessageBox.Show($"Data has been loaded from {filePath}");
                    }
                    else
                    {
                        MessageBox.Show($"File not found: {filePath}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while loading: {ex.Message}");
                }
            }
        }
    }
}