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
    private string name {set; get; } 
    private double average {set; get; } 
    private bool isScholarshipHolder {set; get; }
    private int Id {set; get; }

    public Student(string name, double average, bool isScholarshipHolder)
    {
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = isScholarshipHolder;
        this.nbStudent++;
        this.Id = nbStudent;
    }

    public Student(string name, double average)
    {
        this.name = name;
        this.average = average;
        this.nbStudent++;
        this.Id = nbStudent;
    }    
    public Student()
    {
        this.nbStudent++;
        this.Id = nbStudent;
    }
}

class Course
{
    private string name {set; get; }
    private int credit {set; get; }
    private bool isMandatory {set; get; }

    public Course(string name)
    {
        this.name = name;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Alice", 15.5, true);
        Student student2 = new Student("Bernard", 10, false);
        Student student3 = new Student("Emma", 11.5, false);
        Student student4 = new Student("Lucas", 0, true);
        Student student5 = new Student("Sarah", 10, false);
    }
}
