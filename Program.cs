using dbAssignmnet.RepositoryPattern;

namespace dbAssignmnet
{
    public class Program
    {

        static void Main()
        {
            //CreateTable.CreateDBMethod();
            //CreateTable.CreateTableMethod("CsharpStudent");
            //Insert.InsertMethod();
            //Update.UpdateMethod();
            //Delete.DeleteMethod();


            IStudents students = new Students();
            ServiceClass serviceClass = new ServiceClass(students);
            //serviceClass.ServiceMethod();
            //students.CreateDB("CsharpStudent");
            //serviceClass.InsertInfo();
            //serviceClass.UpdateValue();
            serviceClass.DeleteValue();





        }
    }
}