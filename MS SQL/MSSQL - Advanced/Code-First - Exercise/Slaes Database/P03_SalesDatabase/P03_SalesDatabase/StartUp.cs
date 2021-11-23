using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main()
        {
            var context = new SalesContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Console.WriteLine("Success");
        }
    }
}
