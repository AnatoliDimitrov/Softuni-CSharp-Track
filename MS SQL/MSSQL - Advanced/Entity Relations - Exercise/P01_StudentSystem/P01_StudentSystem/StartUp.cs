using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.Migrate();
        }
    }
}
