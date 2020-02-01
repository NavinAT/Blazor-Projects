function DeleteConfirmation(EmployeeId)
{
    var result = confirm('Do you want to Delete');

    if(result)
    {
        DotNet.invokeMethodAsync('EmployeeManagement.Data', 'DeleteEmployee', EmployeeId);

        alert('Employee record deleted');
    }
}