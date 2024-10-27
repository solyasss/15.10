using System;

class Main_Class
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();
        
        Academy_Group group = new Academy_Group();
        string filePath = "students.dat";

        Academy_Group new_group = null;
        while (true)
        {
            Console.WriteLine("\n-----Academy menu-----");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Remove student");
            Console.WriteLine("3. Edit student");
            Console.WriteLine("4. Print group");
            Console.WriteLine("5. Search student");
            Console.WriteLine("6. Save to file");
            Console.WriteLine("7. Load from file");
            Console.WriteLine("8. Sort students");
            Console.WriteLine("9. Exit");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice, please enter a number.");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        add(group);
                        break;
                    case 2:
                        remove(group);
                        break;
                    case 3:
                        edit(group);
                        break;
                    case 4:
                        group.print();
                        break;
                    case 5:
                        search(group);
                        break;
                    case 6:
                        group.save(filePath);
                        break;
                    case 7:
                        group.load(filePath);
                        break;
                    case 8:
                        sort(group);
                        break;
                    case 9:
                        new_group = (Academy_Group)group.Clone();
                        Console.WriteLine("Cloned!");
                        break;
                    case 10:
                        if (new_group != null)
                            new_group.print();
                        else
                            Console.WriteLine("Not found");
                        break;
                    case 11:
                        print_enum(group);
                        break;
                    case 12:
                        return;
                    default:
                        Console.WriteLine("Incorrect choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    // реализация 
    private static void print_enum(Academy_Group group)
    {
        Console.WriteLine("Students:");
        foreach (Student student in group)
        {
            student.print(); 
        }
    }
    private static void sort_average(Academy_Group group)
    {
        group.sort(null);  
        Console.WriteLine("Students sorted by average");
        group.print();
    }
    
    private static void sort(Academy_Group group)
    {
        Console.WriteLine("\nChoose sorting method:");
        Console.WriteLine("1. Sort by surname");
        Console.WriteLine("2. Sort by group number");
        Console.Write("Enter your sorting choice: ");

        if (int.TryParse(Console.ReadLine(), out int sort_choice))
        {
            switch (sort_choice)
            {
                case 1:
                    group.sort(new Student.sort_surname());
                    break;
                case 2:
                    group.sort(new Student.sort_group());
                    break;
                default:
                    Console.WriteLine("Incorrect sorting choice");
                    return;
            }

            Console.WriteLine("Students sorted");
            group.print();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    
    private static void add(Academy_Group group)
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age");
            return;
        }
        Console.Write("Enter phone: ");
        string phone = Console.ReadLine();
        Console.Write("Enter average: ");
        if (!double.TryParse(Console.ReadLine(), out double average))
        {
            Console.WriteLine("Invalid average");
            return;
        }
        Console.Write("Enter group number: ");
        if (!int.TryParse(Console.ReadLine(), out int group_num))
        {
            Console.WriteLine("Invalid group number");
            return;
        }

        Student new_student = new Student(name, surname, age, phone, average, group_num);
        group.add(new_student);
    }
    
    private static void remove(Academy_Group group)
    {
        Console.Write("Enter surname of student to remove: ");
        string remove_surname = Console.ReadLine();
        group.remove(remove_surname);
    }
    
    private static void edit(Academy_Group group)
    {
        Console.Write("Enter surname of student to edit: ");
        string edit_surname = Console.ReadLine();

        Console.Write("Enter new name: ");
        string name = Console.ReadLine();
        Console.Write("Enter new surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter new age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age");
            return;
        }
        Console.Write("Enter new phone: ");
        string phone = Console.ReadLine();
        Console.Write("Enter new average: ");
        if (!double.TryParse(Console.ReadLine(), out double average))
        {
            Console.WriteLine("Invalid average");
            return;
        }
        Console.Write("Enter new group number: ");
        if (!int.TryParse(Console.ReadLine(), out int group_num))
        {
            Console.WriteLine("Invalid group number");
            return;
        }

        Student ready_student = new Student(name, surname, age, phone, average, group_num);
        group.edit(edit_surname, ready_student);
    }
    private static void search(Academy_Group group)
    {
        Console.Write("Enter surname of student to search: ");
        string search_surname = Console.ReadLine();
        group.search(search_surname);
    }
}
