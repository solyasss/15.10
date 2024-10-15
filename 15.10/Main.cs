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

        while (true)
        {
            Console.WriteLine("\n-----Academy Menu-----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Edit Student");
            Console.WriteLine("4. Print Group");
            Console.WriteLine("5. Search Student");
            Console.WriteLine("6. Save to File");
            Console.WriteLine("7. Load from File");
            Console.WriteLine("8. Exit");

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
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Enter age: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("Invalid age");
                            break;
                        }
                        Console.Write("Enter phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter average: ");
                        if (!double.TryParse(Console.ReadLine(), out double average))
                        {
                            Console.WriteLine("Invalid average");
                            break;
                        }
                        Console.Write("Enter group number: ");
                        if (!int.TryParse(Console.ReadLine(), out int group_num))
                        {
                            Console.WriteLine("Invalid group number");
                            break;
                        }

                        Student new_student = new Student(name, surname, age, phone, average, group_num);
                        group.add(new_student);
                        break;
                    case 2:
                        Console.Write("Enter surname of student to remove: ");
                        string remove_surname = Console.ReadLine();
                        group.remove(remove_surname);
                        break;
                    case 3:
                        Console.Write("Enter surname of student to edit: ");
                        string edit_surname = Console.ReadLine();

                        Console.Write("Enter new name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter new surname: ");
                        surname = Console.ReadLine();
                        Console.Write("Enter new age: ");
                        if (!int.TryParse(Console.ReadLine(), out age))
                        {
                            Console.WriteLine("Invalid age");
                            break;
                        }
                        Console.Write("Enter new phone: ");
                        phone = Console.ReadLine();
                        Console.Write("Enter new average: ");
                        if (!double.TryParse(Console.ReadLine(), out average))
                        {
                            Console.WriteLine("Invalid average");
                            break;
                        }
                        Console.Write("Enter new group number: ");
                        if (!int.TryParse(Console.ReadLine(), out group_num))
                        {
                            Console.WriteLine("Invalid group number");
                            break;
                        }

                        Student ready_student = new Student(name, surname, age, phone, average, group_num);
                        group.edit(edit_surname, ready_student);
                        break;
                    case 4:
                        group.print();
                        break;
                    case 5:
                        Console.Write("Enter surname of student to search: ");
                        string search_surname = Console.ReadLine();
                        group.search(search_surname);
                        break;
                    case 6:
                        group.save(filePath);
                        break;
                    case 7:
                        group.load(filePath);
                        break;
                    case 8:
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
}
