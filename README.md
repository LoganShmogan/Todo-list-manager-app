# To-do list manager

To-Do List Manager
by Logan Young

This is a basic ToDoList Manager that includes a Graphical interface ToDoList and a Command-Line Interface ToDoList. 
In the Command-Line Interface ToDoList users cam add/remove/veiw todolist entrys and also categories. It is right down to the basic level of a ToDoList
with not alot of options in terms of editing and making your todo items more complex. 
Within the Graphical interface ToDoList users can add/remove/veiw/load/save and more thier todo items. Users can create different categories and asign deffernt types of todoitems to them
users can create a duedate and add labels. This type of todolist is much more complex and easier to use over the Command-Line Interface one. 

Usage
Within the Graphical interface ToDoList users can..

Add a ToDoItem 
This is an item that icludes..
- Title
- ID
- Description
- Labels
- Duedate
- Priority
- Category
This item is more complex and gives users a better idea of their task

Add a TaskItem
This icludes..
- Title
- ID
- Description
- Category
This item is very basic and just a quick jot down of a task

Create a category
this includes..
- Title
- ID
Users can add their own categories or they can use the default Home/Work

Testing
In terms of testing I had alot of issues on the base level when creating the application/s

GUI ToDoList
The listveiw box was a very new item for me as when I did the Certificate in IT Essentials we just used a normal listbox. Figuring out how to make categories and
then asign items to those categories was quite a challenge but was swiftly overcome. 
Within the textboxs I had to error check to make sure all fields were filled out before adding the items to the listview. I started out manually
writing "if (textbox != null || textbox2 !- null etc etc" but that was tedious and I new I could do better so I made all the textboxs into an array
and for a foreach loop to then check if those items had informatin in them and if not to give the user an error message. 
