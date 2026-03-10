using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace projet_C_;
class Student
{
    private static int nbStudent = 0;
    private string name;
    public string Name 
    { 
        get { return name; }
        set { name = value; }
    }
    private double average {set; get; } 
    public double Average
    { 
        get { return average; }
        set { average = value; }
    }
    private bool isScholarshipHolder {set; get; }
    public bool IsScholarshipHolder
    { 
        get { return isScholarshipHolder; }
        set { isScholarshipHolder = value; }
    }
    private int id;
    public int Id
    {
        get { return id; }
    }

    public Student(string name, double average, bool isScholarshipHolder)
    {
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = isScholarshipHolder;
        nbStudent++;
        this.id = nbStudent;
    }

    public Student(string name, double average)
    {
        this.name = name;
        this.average = average;
        nbStudent++;
        this.id = nbStudent;
    }    
    public void Display()
    {
        Console.WriteLine($"nom: {name}, moyenne: {average}, est boursier: {isScholarshipHolder}");
    }
}

class Course
{
    private string name {set; get; }
    public string Name 
    { 
        get { return name; }
        set { name = value; }
    }
    private int credit {set; get; }
    public int Credit
    { 
        get { return credit; }
        set { credit = value; }
    }
    private bool isMandatory {set; get; }
    public bool IsMandatory 
    { 
        get { return isMandatory; }
        set { isMandatory = value; }
    }
    private List<Student> students {set; get; }
    public List<Student> Students
    { 
        get { return students; }
        set { students = value; }
    }

    public Course(string name, int credit, bool isMandatory, List<Student> students)
    {
        this.name = name;
        this.credit = credit;
        this.isMandatory = isMandatory;
        this.students = students;
        this.students = new List<Student>();
    }
    public Course(string name)
    {
        this.name = name;
        this.students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public void Display()
    {
        Console.WriteLine($"nom: {name}, credit: {credit}, est obligatoire: {isMandatory}, nombre d'élèves: {students.Count}");
    }

    public void DisplayStudents()
    {
        Console.WriteLine("élèves:");
        foreach (Student student in students)
        {
            Console.WriteLine($"- {student.Name}, moyenne: {student.Average}, est boursier: {student.IsScholarshipHolder}");
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // -- Création des étudiants et des cours --
        //( oui j'ai mis le reste des commentaires en anglais ! et alors !)

        // Create some students
        Student student1 = new Student("Alice", 15.5, true);
        Student student2 = new Student("Bernard", 10, false);
        Student student3 = new Student("Emma", 11.5, false);
        Student student4 = new Student("Lucas", 0, true);
        Student student5 = new Student("Sarah", 10, false);

        // Create some courses
        Course courseMaths = new Course("Mathematique");
        Course courseInformatique = new Course("Informatique");
        Course courseAnglais = new Course("Anglais");
        Course courseHistoire = new Course("Histoire");
        // Add more information to courses
        courseMaths = new Course("Mathematique", 5, true, new List<Student>());
        courseInformatique = new Course("Informatique", 3, true, new List<Student>());
        courseAnglais = new Course("Anglais", 4, true, new List<Student>());
        courseHistoire = new Course("Histoire", 4, false, new List<Student>());
        // Add students to courses
        //Add in mathétatique ( my franglais is so fanstistic ;-) )
        courseMaths.AddStudent(student1);
        courseMaths.AddStudent(student2);
        courseMaths.AddStudent(student3);
        //Add in informatique
        courseInformatique.AddStudent(student2);
        courseInformatique.AddStudent(student4);
        //Add in anglais
        courseAnglais.AddStudent(student1);
        courseAnglais.AddStudent(student5);
        //Add in histoire
        courseHistoire.AddStudent(student4);

        List<Course> courses = new List<Course> { courseMaths, courseInformatique, courseAnglais, courseHistoire };
        // show each courses
        foreach (Course course in courses)
        {
            course.Display();
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        // show each courses with the students
        foreach (Course course in courses)
        {
            course.Display();
            course.DisplayStudents();
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        // show the courses mandatory
        Console.WriteLine("Cours obligatoires:");
        foreach (Course course in courses)
        {
            if (course.IsMandatory)
            {
                course.Display();
            }
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        // show the student with scolarship
        List<Student> students = new List<Student> { student1, student2, student3, student4, student5 };
        Console.WriteLine("Étudiants boursiers:");
        foreach (Student student in students)
        {
            if (student.IsScholarshipHolder)
            {
                student.Display();
            }
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        // show the student with average more than 15
        Console.WriteLine("Étudiants avec une moyenne supérieure à 15:");
        foreach (Student student in students)
        {
            if (student.Average > 15)
            {
                student.Display();
            }
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        // delete a student from a course
        Console.WriteLine("Suppression de l'étudiant Bernard du cours de Mathématiques...");
        Console.WriteLine("...");
        courseMaths.RemoveStudent(student2);
        // show the courses with the students after deletion
        Console.WriteLine("Cours après suppression de Bernard du cours de Mathématiques:");
        foreach (Course course in courses)
        {
            course.Display();
            course.DisplayStudents();
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        // show the ID of each student
        Console.WriteLine("ID de chaque étudiant:");
        foreach (Student student in students)
        {
            Console.WriteLine($"- {student.Name}, ID: {student.Id}");
        }
        //
        // -- Question du tp --
        //
        // 1) chaque étudiant a un ID unique qui est généré automatiquement lors de la création de l'étudiant. L'ID est un entier qui commence à 1 et s'incrémente à chaque nouvel étudiant créé.
        //
        // 2) la variable nbStudent est une variable static pour permettre de compter le nombre total d'étudiants créés, et ainsi générer un ID unique pour chaque étudiant. Si nbStudent n'était
        //    pas static, chaque instance de la classe Student aurait sa propre variable nbStudent.
    }
}
