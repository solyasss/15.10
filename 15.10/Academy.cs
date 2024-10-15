using System;
using System.Collections;
using System.IO;

public class Academy_Group
{
    private ArrayList students;
    private int count;

    public Academy_Group()
    {
        students = new ArrayList();
        count = 0;
    }

    public void add(Student student)
    {
        students.Add(student);
        count++;
    }

    public void remove(string surname)
    {
        foreach (Student student in students)
        {
            if (student.Surname == surname)
            {
                students.Remove(student);
                count--;
                Console.WriteLine("You removed student");
                return;
            }
        }
        Console.WriteLine("Can not find student");
    }

    public void edit(string surname, Student new_st)
    {
        for (int i = 0; i < students.Count; i++)
        {
            Student student = (Student)students[i];
            if (student.Surname == surname)
            {
                students[i] = new_st;
                Console.WriteLine("You updated student info");
                return;
            }
        }
        Console.WriteLine("Can not find student");
    }

    public void print()
    {
        Console.WriteLine("Academy Group:");
        foreach (Student student in students)
        {
            student.print();
        }
    }

    // сохраняю в бинарный файл
    public void save(string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(students.Count); // записываем количество студентов

                foreach (Student student in students)
                {
                    writer.Write(student.Name);
                    writer.Write(student.Surname);
                    writer.Write(student.Age);
                    writer.Write(student.Phone);
                    writer.Write(student.Average);
                    writer.Write(student.Number_Of_Group);
                }
            }
            Console.WriteLine("File saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with saving: {ex.Message}");
        }
    }

    // загружаю инфо из бин файла 
    public void load(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                students.Clear();
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int studentCount = reader.ReadInt32(); // принимаю количество студентов 

                    for (int i = 0; i < studentCount; i++)
                    {
                        string name = reader.ReadString();
                        string surname = reader.ReadString();
                        int age = reader.ReadInt32();
                        string phone = reader.ReadString();
                        double average = reader.ReadDouble();
                        int group_num = reader.ReadInt32();

                        Student student = new Student(name, surname, age, phone, average, group_num);
                        students.Add(student);
                    }
                }
                Console.WriteLine("File loaded");
                count = students.Count;
            }
            else
            {
                Console.WriteLine("Can not load file");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with loading: {ex.Message}");
        }
    }

    public void search(string surname)
    {
        foreach (Student student in students)
        {
            if (student.Surname == surname)
            {
                student.print();
                return;
            }
        }
        Console.WriteLine("Can not find student");
    }
}
