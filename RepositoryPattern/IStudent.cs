using System;

namespace dbAssignmnet.RepositoryPattern
{
    public interface IStudents
    {
        string CreateDB(string TableName);
        string InsertValues();
        string Update();
        string Delete();
        List<StudentModel> GetAll(); 
    }
}