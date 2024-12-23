namespace EmployeeManagment.BL.Exceptions.DepartmentExceptions;

public class EntityNotFoundException:Exception
{
    public EntityNotFoundException():base("Entity not found"){}
    
}
